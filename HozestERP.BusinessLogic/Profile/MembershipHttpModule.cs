
using System;
using System.Diagnostics;
using System.Globalization;
using System.Web;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.SEO;
using HozestERP.Common.Utils;

namespace HozestERP.BusinessLogic.Profile
{
    /// <summary>
    /// nopCommerce membership module
    /// </summary>
    public class MembershipHttpModule : IHttpModule
    {
        #region Utilities
        /// <summary>
        /// Logout customer
        /// </summary>
        private void logout()
        {
            IoC.Resolve<ICustomerService>().Logout();
            string loginURL = string.Empty;
            if (HozestERPContext.Current != null)
            {
                if (HozestERPContext.Current.IsAdmin)
                    loginURL = SEOHelper.GetAdminAreaLoginPageUrl();
                else
                    loginURL = SEOHelper.GetLoginPageUrl();
                HttpContext.Current.Response.Redirect(loginURL);
            }
        }

        /// <summary>
        /// Handlers the AuthenticateRequest event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //exit if a request for a .net mapping that isn't a content page is made i.e. axd
            if (!CommonHelper.IsContentPageRequested())
                return;

            //authentication
            bool authenticated = false;
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null)
                authenticated = HttpContext.Current.User.Identity.IsAuthenticated;

            if (authenticated)
            {
                Customer customer = null;
                string name = HttpContext.Current.User.Identity.Name;
                if (IoC.Resolve<ICustomerService>().UsernamesEnabled)
                {
                    customer = IoC.Resolve<ICustomerService>().GetCustomerByUsername(name);
                }
                else
                {
                    customer = IoC.Resolve<ICustomerService>().GetCustomerByEmail(name);
                }

                if (customer != null)
                {
                    if (!String.IsNullOrEmpty(HttpContext.Current.User.Identity.Name)
                        && customer.Active
                        && !customer.Deleted && !customer.IsGuest)
                    {
                        //impersonate user if required (currently used for 'phone order' support)
                        //and validate that the current user is admin
                        //and validate that we're in public store
                        if (customer.IsAdmin &&
                            !CommonHelper.IsAdmin())
                        {
                                //set current customer
                                HozestERPContext.Current.User = customer;
                        }
                        else
                        {
                            //set current customer
                            HozestERPContext.Current.User = customer;
                        }

                        //set current customer session
                        var customerSession = IoC.Resolve<ICustomerService>().GetCustomerSessionByCustomerId(HozestERPContext.Current.User.CustomerID);
                        if (customerSession == null)
                        {
                            customerSession = HozestERPContext.Current.GetSession(true);
                            customerSession.IsExpired = false;
                            customerSession.LastAccessed = DateTime.UtcNow;
                            customerSession.CustomerID = HozestERPContext.Current.User.CustomerID;
                            customerSession = IoC.Resolve<ICustomerService>().SaveCustomerSession(customerSession.CustomerSessionGUID, customerSession.CustomerID, customerSession.LastAccessed, customerSession.IsExpired);
                        }
                        HozestERPContext.Current.Session = customerSession;
                    }
                    else
                    {
                        logout();
                    }
                }
                else
                {
                    logout();
                }
            }
            else
            {
                if (HozestERPContext.Current.Session != null)
                {
                    var guestCustomer = HozestERPContext.Current.Session.Customer;
                    if (guestCustomer != null && guestCustomer.Active && !guestCustomer.Deleted && guestCustomer.IsGuest)
                    {
                        HozestERPContext.Current.User = guestCustomer;
                    }
                }
            }
            
            //set current culture (after current user is loaded)
            //var currentLanguage = CRMContext.Current.WorkingLanguage;
            //if (currentLanguage != null)
            //{
            //    CRMContext.Current.SetCulture(new CultureInfo(currentLanguage.LanguageCulture));
            //}
        }

        /// <summary>
        /// Handlers the BeginRequest event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_BeginRequest(object sender, EventArgs e)
        {
            //exit if a request for a .net mapping that isn't a content page is made i.e. axd
            if (!CommonHelper.IsContentPageRequested())
                return;

            //update session last access time
            if (HozestERPContext.Current.Session != null)
            {
                var dtNow = DateTime.UtcNow;
                if (HozestERPContext.Current.Session.LastAccessed.AddMinutes(1.0) < dtNow)
                {
                    HozestERPContext.Current.Session.LastAccessed = dtNow;
                    HozestERPContext.Current.Session = IoC.Resolve<ICustomerService>().SaveCustomerSession(
                        HozestERPContext.Current.Session.CustomerSessionGUID,
                        HozestERPContext.Current.Session.CustomerID,
                        HozestERPContext.Current.Session.LastAccessed,
                        false);
                }
            }
        }

        /// <summary>
        /// Handlers the EndRequest event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_EndRequest(object sender, EventArgs e)
        {
            //exit if a request for a .net mapping that isn't a content page is made i.e. axd
            if (!CommonHelper.IsContentPageRequested())
                return;

            try
            {

                //session workflow
                bool sessionReseted = false;
                if (HozestERPContext.Current["CRM.SessionReseted"] != null)
                {
                    sessionReseted = Convert.ToBoolean(HozestERPContext.Current["CRM.SessionReseted"]);
                }
                if (!sessionReseted)
                {
                    HozestERPContext.Current.SessionSaveToClient();
                }
            }
            catch (Exception exc)
            {
                //LogManager.InsertLog(LogTypeEnum.Unknown, exc.Message, exc);
                Debug.WriteLine(exc.Message);
            }
        }

        /// <summary>
        /// Handlers the PostAcquireRequestState event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handlers the PostRequestHandlerExecute event of the application
        /// </summary>        
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handlers the PreSendRequestContent event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void application_PreSendRequestContent(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handlers the ReleaseRequestState event of the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The instance containing the event data.</param>
        private void Application_ReleaseRequestState(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Methods
        /// <summary>
        ///  Initializes the NopCommerceFilter object
        /// </summary>
        /// <param name="application">The application</param>
        public void Init(HttpApplication application)
        {
            application.BeginRequest += new EventHandler(this.Application_BeginRequest);
            application.EndRequest += new EventHandler(this.Application_EndRequest);
            application.PostAcquireRequestState += new EventHandler(this.Application_PostAcquireRequestState);
            application.ReleaseRequestState += new EventHandler(this.Application_ReleaseRequestState);
            application.AuthenticateRequest += new EventHandler(this.Application_AuthenticateRequest);
            application.PreSendRequestContent += new EventHandler(this.application_PreSendRequestContent);
            application.PostRequestHandlerExecute += new EventHandler(this.application_PostRequestHandlerExecute);
        }

        /// <summary>
        /// Disposes the object
        /// </summary>
        public void Dispose()
        {
        }
        #endregion
    }
}
