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
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageProtal
{
    public partial class PortalColumn: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ColumnNumberID
        /// </summary>
        public int ColumnNumberID { get; set; }
    
    	/// <summary>
        /// Gets or sets the PortalID
        /// </summary>
        public int PortalID { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsExpand
        /// </summary>
        public int IsExpand { get; set; }
    
    	/// <summary>
        /// Gets or sets the SortIndex
        /// </summary>
        public int SortIndex { get; set; }

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SPortal
        /// </summary>
        public virtual Portal SPortal { get; set; }

        /// <summary>
        /// Gets or sets the SPortalColumnNumbers list
        /// </summary>
        public virtual PortalColumnNumber SPortalColumnNumber { get; set; }

        #endregion
    }
}
