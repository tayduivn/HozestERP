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

using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.Configuration.Settings
{
    public partial class Sys_AlertTimeSet: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public Nullable<int> CustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the AlertID
        /// </summary>
        public Nullable<int> AlertID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Cycletime
        /// </summary>
        public Nullable<int> Cycletime { get; set; }
    
    	/// <summary>
        /// Gets or sets the Spare1
        /// </summary>
        public string Spare1 { get; set; }
    
    	/// <summary>
        /// Gets or sets the Spare2
        /// </summary>
        public string Spare2 { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the SAlertSettings
        /// </summary>
        public virtual Sys_AlertSettings SAlertSettings { get; set; }

        /// <summary>
        /// ͨ��AlertID��ȡRmdname
        /// </summary>
        public Sys_AlertSettings AlertSettings
        {
            get
            {
                return IoC.Resolve<ISettingManager>().GetAlertSettingsByID(this.AlertID.Value);
            }
        }
    }
}