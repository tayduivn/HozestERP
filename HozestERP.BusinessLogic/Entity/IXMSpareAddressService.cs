
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
    public partial interface IXMSpareAddressService
    {
        #region IXMSpareAddressService成员
        /// <summary>
        /// Insert into XMSpareAddress
        /// </summary>
        /// <param name="xmspareaddress">XMSpareAddress</param>
    	void InsertXMSpareAddress(XMSpareAddress xmspareaddress);
    	
        /// <summary>
        /// Update into XMSpareAddress
        /// </summary>
        /// <param name="xmspareaddress">XMSpareAddress</param>
        void UpdateXMSpareAddress(XMSpareAddress xmspareaddress);	
    	
        /// <summary>
        /// get to XMSpareAddress list
        /// </summary>
        List<XMSpareAddress> GetXMSpareAddressList();
    	       
    	/// <summary>
    	/// get to XMSpareAddress Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMSpareAddress Page List</returns>
    	PagedList<XMSpareAddress> SearchXMSpareAddress(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMSpareAddress by ID
        /// </summary>
        /// <param name="id">XMSpareAddress ID</param>
        /// <returns>XMSpareAddress</returns>   
        XMSpareAddress GetXMSpareAddressByID(int id);
    
    	/// <summary>
        /// delete XMSpareAddress by ID
        /// </summary>
        /// <param name="ID">XMSpareAddress ID</param>
        void DeleteXMSpareAddress(int id);
    	
    	/// <summary>
        /// Batch delete XMSpareAddress by ID
        /// </summary>
        /// <param name="IDs">XMSpareAddress ID</param>
        void BatchDeleteXMSpareAddress(List<int> ids);

        #endregion
    }
}
