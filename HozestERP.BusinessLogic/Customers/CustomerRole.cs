//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Security;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial class CustomerRole : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the CustomerRoleID
        /// </summary>
        public int CustomerRoleID { get; set; }

        /// <summary>
        /// Gets or sets the ParentCustomerRoleID
        /// </summary>
        public int ParentCustomerRoleID { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Gets or sets the Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }
        /// <summary>
        ///  Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///  Gets or sets the CreateStaff
        /// </summary>
        public int CreateStaff { get; set; }

        /// <summary>
        ///  Gets or sets the CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; }

        #endregion

        #region Customer Properties
        /// <summary>
        ///  Gets the CreateStaff
        /// </summary>
        public Customer Creater
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetCustomerById(this.CreateStaff);
            }
        }

        public CustomerRole ParentCustomerRole
        {
            get
            {
                return IoC.Resolve<ICustomerService>().GetCustomerRoleById(this.ParentCustomerRoleID);
            }
        }
        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the ACL list
        /// </summary>
        public virtual ICollection<ACL> SACLs { get; set; }

        /// <summary>
        /// Gets or sets the ACLPerObject list
        /// </summary>
        public virtual ICollection<ACLModule> SACLModules { get; set; }

        /// <summary>
        /// Gets or sets the Customer list
        /// </summary>
        public virtual ICollection<Customer> SCustomers { get; set; }


        /// <summary>
        /// Gets or sets the Customer list
        /// </summary>
        public virtual ICollection<Department> SDepartments { get; set; }

        /// <summary>
        /// �����û�
        /// </summary>
        public virtual ICollection<Customer> SCustomerRoleStaffPrivileges { get; set; }

        #endregion
    }
}
