
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
    public partial class XMProduct: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the BrandTypeId
        /// </summary>
        public Nullable<int> BrandTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string ManufacturersCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManufacturersInventory
        /// </summary>
        public Nullable<int> ManufacturersInventory { get; set; }
    
    	/// <summary>
        /// Gets or sets the WarningQuantity
        /// </summary>
        public Nullable<int> WarningQuantity { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductColors
        /// </summary>
        public string ProductColors { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductUnit
        /// </summary>
        public string ProductUnit { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductWeight
        /// </summary>
        public string ProductWeight { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductVolume
        /// </summary>
        public string ProductVolume { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsPremiums
        /// </summary>
        public Nullable<bool> IsPremiums { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the Series
        /// </summary>
        public string Series { get; set; }
    
    	/// <summary>
        /// Gets or sets the Shipper
        /// </summary>
        public Nullable<int> Shipper { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsMoveCargo
        /// </summary>
        public Nullable<bool> IsMoveCargo { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}