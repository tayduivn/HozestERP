
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
    public partial interface IXMWareHousesService
    {
        #region IXMWareHousesService成员
        /// <summary>
        /// Insert into XMWareHouses
        /// </summary>
        /// <param name="xmwarehouses">XMWareHouses</param>
    	void InsertXMWareHouses(XMWareHouses xmwarehouses);
    	
        /// <summary>
        /// Update into XMWareHouses
        /// </summary>
        /// <param name="xmwarehouses">XMWareHouses</param>
        void UpdateXMWareHouses(XMWareHouses xmwarehouses);	
    	
        /// <summary>
        /// get to XMWareHouses list
        /// </summary>
        List<XMWareHouses> GetXMWareHousesList();
    	       
    	/// <summary>
    	/// get to XMWareHouses Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMWareHouses Page List</returns>
    	PagedList<XMWareHouses> SearchXMWareHouses(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMWareHouses by Id
        /// </summary>
        /// <param name="id">XMWareHouses Id</param>
        /// <returns>XMWareHouses</returns>   
        XMWareHouses GetXMWareHousesById(int id);
    
    	/// <summary>
        /// delete XMWareHouses by Id
        /// </summary>
        /// <param name="Id">XMWareHouses Id</param>
        void DeleteXMWareHouses(int id);
    	
    	/// <summary>
        /// Batch delete XMWareHouses by Id
        /// </summary>
        /// <param name="Ids">XMWareHouses Id</param>
        void BatchDeleteXMWareHouses(List<int> ids);

        #endregion
    }
}
