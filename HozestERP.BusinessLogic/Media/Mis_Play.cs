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

namespace CRM.BusinessLogic.Media
{
    public partial class Mis_Play: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the MusicName
        /// </summary>
        public string MusicName { get; set; }
    
    	/// <summary>
        /// Gets or sets the MusicUrl
        /// </summary>
        public string MusicUrl { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlayUserId
        /// </summary>
        public string PlayUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlayUserName
        /// </summary>
        public string PlayUserName { get; set; }

        #endregion
    }
}
