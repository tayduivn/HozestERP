
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
** 修改人:
** 修改日期:
** 描 述: 接口类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Entity
{
    public partial interface ICustomerActionService
    {
        #region ICustomerActionService成员
        /// <summary>
        /// Insert into CustomerAction
        /// </summary>
        /// <param name="customeraction">CustomerAction</param>
    	void InsertCustomerAction(CustomerAction customeraction);
    	
        /// <summary>
        /// Update into CustomerAction
        /// </summary>
        /// <param name="customeraction">CustomerAction</param>
        void UpdateCustomerAction(CustomerAction customeraction);	
    	
        /// <summary>
        /// get to CustomerAction list
        /// </summary>
        List<CustomerAction> GetCustomerActionList();
    	       
    	/// <summary>
    	/// get to CustomerAction Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CustomerAction Page List</returns>
    	PagedList<CustomerAction> SearchCustomerAction(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CustomerAction by CustomerActionID
        /// </summary>
        /// <param name="customeractionid">CustomerAction CustomerActionID</param>
        /// <returns>CustomerAction</returns>   
        CustomerAction GetCustomerActionByCustomerActionID(int customeractionid);
    
    	/// <summary>
        /// delete CustomerAction by CustomerActionID
        /// </summary>
        /// <param name="CustomerActionID">CustomerAction CustomerActionID</param>
        void DeleteCustomerAction(int customeractionid);
    	
    	/// <summary>
        /// Batch delete CustomerAction by CustomerActionID
        /// </summary>
        /// <param name="CustomerActionIDs">CustomerAction CustomerActionID</param>
        void BatchDeleteCustomerAction(List<int> customeractionids);

        #endregion
    }
}
