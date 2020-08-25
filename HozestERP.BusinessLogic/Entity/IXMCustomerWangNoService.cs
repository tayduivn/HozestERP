
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
    public partial interface IXMCustomerWangNoService
    {
        #region IXMCustomerWangNoService成员
        /// <summary>
        /// Insert into XMCustomerWangNo
        /// </summary>
        /// <param name="xmcustomerwangno">XMCustomerWangNo</param>
    	void InsertXMCustomerWangNo(XMCustomerWangNo xmcustomerwangno);
    	
        /// <summary>
        /// Update into XMCustomerWangNo
        /// </summary>
        /// <param name="xmcustomerwangno">XMCustomerWangNo</param>
        void UpdateXMCustomerWangNo(XMCustomerWangNo xmcustomerwangno);	
    	
        /// <summary>
        /// get to XMCustomerWangNo list
        /// </summary>
        List<XMCustomerWangNo> GetXMCustomerWangNoList();
    	       
    	/// <summary>
    	/// get to XMCustomerWangNo Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMCustomerWangNo Page List</returns>
    	PagedList<XMCustomerWangNo> SearchXMCustomerWangNo(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMCustomerWangNo by ID
        /// </summary>
        /// <param name="id">XMCustomerWangNo ID</param>
        /// <returns>XMCustomerWangNo</returns>   
        XMCustomerWangNo GetXMCustomerWangNoByID(int id);
    
    	/// <summary>
        /// delete XMCustomerWangNo by ID
        /// </summary>
        /// <param name="ID">XMCustomerWangNo ID</param>
        void DeleteXMCustomerWangNo(int id);
    	
    	/// <summary>
        /// Batch delete XMCustomerWangNo by ID
        /// </summary>
        /// <param name="IDs">XMCustomerWangNo ID</param>
        void BatchDeleteXMCustomerWangNo(List<int> ids);

        #endregion
    }
}
