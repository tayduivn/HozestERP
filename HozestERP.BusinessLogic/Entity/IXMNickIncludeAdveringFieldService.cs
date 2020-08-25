
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
    public partial interface IXMNickIncludeAdveringFieldService
    {
        #region IXMNickIncludeAdveringFieldService成员
        /// <summary>
        /// Insert into XMNickIncludeAdveringField
        /// </summary>
        /// <param name="xmnickincludeadveringfield">XMNickIncludeAdveringField</param>
    	void InsertXMNickIncludeAdveringField(XMNickIncludeAdveringField xmnickincludeadveringfield);
    	
        /// <summary>
        /// Update into XMNickIncludeAdveringField
        /// </summary>
        /// <param name="xmnickincludeadveringfield">XMNickIncludeAdveringField</param>
        void UpdateXMNickIncludeAdveringField(XMNickIncludeAdveringField xmnickincludeadveringfield);	
    	
        /// <summary>
        /// get to XMNickIncludeAdveringField list
        /// </summary>
        List<XMNickIncludeAdveringField> GetXMNickIncludeAdveringFieldList();
    	       
    	/// <summary>
    	/// get to XMNickIncludeAdveringField Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>XMNickIncludeAdveringField Page List</returns>
    	PagedList<XMNickIncludeAdveringField> SearchXMNickIncludeAdveringField(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a XMNickIncludeAdveringField by Id
        /// </summary>
        /// <param name="id">XMNickIncludeAdveringField Id</param>
        /// <returns>XMNickIncludeAdveringField</returns>   
        XMNickIncludeAdveringField GetXMNickIncludeAdveringFieldById(int id);
    
    	/// <summary>
        /// delete XMNickIncludeAdveringField by Id
        /// </summary>
        /// <param name="Id">XMNickIncludeAdveringField Id</param>
        void DeleteXMNickIncludeAdveringField(int id);
    	
    	/// <summary>
        /// Batch delete XMNickIncludeAdveringField by Id
        /// </summary>
        /// <param name="Ids">XMNickIncludeAdveringField Id</param>
        void BatchDeleteXMNickIncludeAdveringField(List<int> ids);

        #endregion
    }
}
