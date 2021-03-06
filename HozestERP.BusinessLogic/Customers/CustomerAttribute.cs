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

namespace HozestERP.BusinessLogic.CustomerManagement
{
    public partial class CustomerAttribute: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the CustomerAttributeId
        /// </summary>
        public int CustomerAttributeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerId
        /// </summary>
        public int CustomerId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Key
        /// </summary>
        public string Key { get; set; }
    
    	/// <summary>
        /// Gets or sets the Value
        /// </summary>
        public string Value { get; set; }

        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the Customer
        /// </summary>
        public virtual Customer SCustomer { get; set; }

        #endregion
    }
}
