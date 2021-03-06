
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using HozestERP.BusinessLogic.Configuration.Settings;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.Profile
{
    /// <summary>
    /// Represents a datetime helper
    /// </summary>
    public partial class DateTimeHelper
    {
        #region Methods
        /// <summary>
        /// Retrieves a System.TimeZoneInfo object from the registry based on its identifier.
        /// </summary>
        /// <param name="id">The time zone identifier, which corresponds to the System.TimeZoneInfo.Id property.</param>
        /// <returns>A System.TimeZoneInfo object whose identifier is the value of the id parameter.</returns>
        public static TimeZoneInfo FindTimeZoneById(string id)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(id);
        }

        /// <summary>
        /// Returns a sorted collection of all the time zones
        /// </summary>
        /// <returns>A read-only collection of System.TimeZoneInfo objects.</returns>
        public static ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones()
        {
            return TimeZoneInfo.GetSystemTimeZones();
        }

        /// <summary>
        /// Converts the date and time to current user date and time
        /// </summary>
        /// <param name="dt">The date and time (respesents local system time or UTC time) to convert.</param>
        /// <returns>A DateTime value that represents time that corresponds to the dateTime parameter in customer time zone.</returns>
        public static DateTime ConvertToUserTime(DateTime dt)
        {
            return ConvertToUserTime(dt, dt.Kind);
        }

        /// <summary>
        /// Converts the date and time to current user date and time
        /// </summary>
        /// <param name="dt">The date and time (respesents local system time or UTC time) to convert.</param>
        /// <param name="sourceDateTimeKind">The source datetimekind</param>
        /// <returns>A DateTime value that represents time that corresponds to the dateTime parameter in customer time zone.</returns>
        public static DateTime ConvertToUserTime(DateTime dt, DateTimeKind sourceDateTimeKind)
        {
            dt = DateTime.SpecifyKind(dt, sourceDateTimeKind);
            var currentUserTimeZoneInfo = DateTimeHelper.CurrentTimeZone;
            return TimeZoneInfo.ConvertTime(dt, currentUserTimeZoneInfo);
        }

        /// <summary>
        /// Converts the date and time to current user date and time
        /// </summary>
        /// <param name="dt">The date and time to convert.</param>
        /// <param name="sourceTimeZone">The time zone of dateTime.</param>
        /// <returns>A DateTime value that represents time that corresponds to the dateTime parameter in customer time zone.</returns>
        public static DateTime ConvertToUserTime(DateTime dt, TimeZoneInfo sourceTimeZone)
        {
            var currentUserTimeZoneInfo = DateTimeHelper.CurrentTimeZone;
            return ConvertToUserTime(dt, sourceTimeZone, currentUserTimeZoneInfo);
        }

        /// <summary>
        /// Converts the date and time to current user date and time
        /// </summary>
        /// <param name="dt">The date and time to convert.</param>
        /// <param name="sourceTimeZone">The time zone of dateTime.</param>
        /// <param name="destinationTimeZone">The time zone to convert dateTime to.</param>
        /// <returns>A DateTime value that represents time that corresponds to the dateTime parameter in customer time zone.</returns>
        public static DateTime ConvertToUserTime(DateTime dt, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone)
        {
            return TimeZoneInfo.ConvertTime(dt, sourceTimeZone, destinationTimeZone);
        }

        /// <summary>
        /// Converts the date and time to Coordinated Universal Time (UTC)
        /// </summary>
        /// <param name="dt">The date and time (respesents local system time or UTC time) to convert.</param>
        /// <returns>A DateTime value that represents the Coordinated Universal Time (UTC) that corresponds to the dateTime parameter. The DateTime value's Kind property is always set to DateTimeKind.Utc.</returns>
        public static DateTime ConvertToUtcTime(DateTime dt)
        {
            return ConvertToUtcTime(dt, dt.Kind);
        }

        /// <summary>
        /// Converts the date and time to Coordinated Universal Time (UTC)
        /// </summary>
        /// <param name="dt">The date and time (respesents local system time or UTC time) to convert.</param>
        /// <param name="sourceDateTimeKind">The source datetimekind</param>
        /// <returns>A DateTime value that represents the Coordinated Universal Time (UTC) that corresponds to the dateTime parameter. The DateTime value's Kind property is always set to DateTimeKind.Utc.</returns>
        public static DateTime ConvertToUtcTime(DateTime dt, DateTimeKind sourceDateTimeKind)
        {
            dt = DateTime.SpecifyKind(dt, sourceDateTimeKind);
            return TimeZoneInfo.ConvertTimeToUtc(dt);
        }

        /// <summary>
        /// Converts the date and time to Coordinated Universal Time (UTC)
        /// </summary>
        /// <param name="dt">The date and time to convert.</param>
        /// <param name="sourceTimeZone">The time zone of dateTime.</param>
        /// <returns>A DateTime value that represents the Coordinated Universal Time (UTC) that corresponds to the dateTime parameter. The DateTime value's Kind property is always set to DateTimeKind.Utc.</returns>
        public static DateTime ConvertToUtcTime(DateTime dt, TimeZoneInfo sourceTimeZone)
        {
            if (sourceTimeZone.IsInvalidTime(dt))
            {
                //could not convert
                return dt;
            }
            else
            {
                return TimeZoneInfo.ConvertTimeToUtc(dt, sourceTimeZone);
            }
        }

        /// <summary>
        /// Gets a customer time zone
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>Customer time zone; if customer is null, then default store time zone</returns>
        public static TimeZoneInfo GetCustomerTimeZone(Customer customer)
        {
            //registered user
            TimeZoneInfo timeZoneInfo = null;
            if (DateTimeHelper.AllowCustomersToSetTimeZone)
            {
                string timeZoneId = string.Empty;
                if (customer != null)
                    timeZoneId = customer.TimeZoneID;

                try
                {
                    if (!String.IsNullOrEmpty(timeZoneId))
                        timeZoneInfo = DateTimeHelper.FindTimeZoneById(timeZoneId);
                }
                catch (Exception exc)
                {
                    Debug.Write(exc.ToString());
                }
            }

            //default timezone
            if (timeZoneInfo == null)
                timeZoneInfo = DateTimeHelper.DefaultStoreTimeZone;

            return timeZoneInfo;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a default store time zone
        /// </summary>
        public static TimeZoneInfo DefaultStoreTimeZone
        {
            get
            {
                string defaultTimeZoneId = IoC.Resolve<ISettingManager>().GetSettingValue("Common.DefaultStoreTimeZoneId");
                TimeZoneInfo timeZoneInfo = null;
                try
                {
                    timeZoneInfo = DateTimeHelper.FindTimeZoneById(defaultTimeZoneId);
                }
                catch (Exception exc)
                {
                    Debug.Write(exc.ToString());
                }

                if (timeZoneInfo == null)
                    timeZoneInfo = TimeZoneInfo.Local;

                return timeZoneInfo;
            }
            set
            {
                string defaultTimeZoneId = string.Empty;
                if (value != null)
                {
                    defaultTimeZoneId = value.Id;
                }

                IoC.Resolve<ISettingManager>().SetParam("Common.DefaultStoreTimeZoneId", defaultTimeZoneId);
            }
        }

        /// <summary>
        /// Gets or sets the current user time zone
        /// </summary>
        public static TimeZoneInfo CurrentTimeZone
        {
            get
            {
                return GetCustomerTimeZone(HozestERPContext.Current.User);
            }
            set
            {
                if (!DateTimeHelper.AllowCustomersToSetTimeZone)
                    return;

                string timeZoneId = string.Empty;
                if (value != null)
                {
                    timeZoneId = value.Id;
                }

                //registered user only
                var customer = HozestERPContext.Current.User;
                if (customer != null)
                {
                    customer.TimeZoneID = timeZoneId;
                    IoC.Resolve<ICustomerService>().UpdateCustomer(customer);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to select theirs time zone
        /// </summary>
        public static bool AllowCustomersToSetTimeZone
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetSettingValueBoolean("Common.AllowCustomersToSetTimeZone");
            }
            set
            {
                IoC.Resolve<ISettingManager>().SetParam("Common.AllowCustomersToSetTimeZone", value.ToString());
            }
        }

        #endregion
    }
}