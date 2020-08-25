
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-04-26 15:27:24
** 修改人:
** 修改日期:
** 描 述: 
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace HozestERP.BusinessLogic.Entity
{
    public partial class BannedIpAddress: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the BannedIpAddressID
        /// </summary>
        public int BannedIpAddressID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Address
        /// </summary>
        public string Address { get; set; }
    
    	/// <summary>
        /// Gets or sets the Comment
        /// </summary>
        public string Comment { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatedOn
        /// </summary>
        public System.DateTime CreatedOn { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatedOn
        /// </summary>
        public System.DateTime UpdatedOn { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}