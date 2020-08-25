
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-03-04 11:37:57
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMCommunicationRecord: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the QuestionID
        /// </summary>
        public Nullable<int> QuestionID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContactTime
        /// </summary>
        public Nullable<System.DateTime> ContactTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContactTheme
        /// </summary>
        public string ContactTheme { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContactContent
        /// </summary>
        public string ContactContent { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateId
        /// </summary>
        public Nullable<int> CreateId { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateId
        /// </summary>
        public Nullable<int> UpdateId { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateTime { get; set; }

        #endregion
        #region Custom Properties


        /// <summary>
        /// 创建人
        /// </summary>
        public CustomerInfo CreateName
        {
            get
            {
                if (this.CreateId != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.CreateId.Value);
                }
                else
                {

                    return null;
                }
            }
        }



        #endregion
    }
}
