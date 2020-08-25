
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:28:32
** 修改人:
** 修改日期:
** 描 述: 接口实现类
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
    public partial class XMCombinationDetailsService: IXMCombinationDetailsService
    {
        #region Fields
    	/// <summary>
    	/// Object context
    	/// </summary>
    	private readonly HozestERPObjectContext _context;
    	/// <summary>
    	/// Cache manager
    	/// </summary>
    	private readonly ICacheManager _cacheManager;

        #endregion
    	
        #region Ctor
    	
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
    	public XMCombinationDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMCombinationDetailsService成员
        /// <summary>
        /// Insert into XMCombinationDetails
        /// </summary>
        /// <param name="xmcombinationdetails">XMCombinationDetails</param>
    	public void InsertXMCombinationDetails(XMCombinationDetails xmcombinationdetails)
    	{	
            if (xmcombinationdetails == null)
                return;
    
            if (!this._context.IsAttached(xmcombinationdetails))
    			
                this._context.XMCombinationDetails.AddObject(xmcombinationdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMCombinationDetails
        /// </summary>
        /// <param name="xmcombinationdetails">XMCombinationDetails</param>
        public void UpdateXMCombinationDetails(XMCombinationDetails xmcombinationdetails)
        {
            if (xmcombinationdetails == null)
                return;
    
            if (this._context.IsAttached(xmcombinationdetails))
                this._context.XMCombinationDetails.Attach(xmcombinationdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMCombinationDetails list
        /// </summary>
        public List<XMCombinationDetails> GetXMCombinationDetailsList()
        {		
            var query = from p in this._context.XMCombinationDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMCombinationDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCombinationDetails Page List</returns>
        public PagedList<XMCombinationDetails> SearchXMCombinationDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMCombinationDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMCombinationDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMCombinationDetails by Id
        /// </summary>
        /// <param name="id">XMCombinationDetails Id</param>
        /// <returns>XMCombinationDetails</returns>   
        public XMCombinationDetails GetXMCombinationDetailsById(int id)
        {
            var query = from p in this._context.XMCombinationDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMCombinationDetails by Id
        /// </summary>
        /// <param name="Id">XMCombinationDetails Id</param>
        public void DeleteXMCombinationDetails(int id)
        {
            var xmcombinationdetails = this.GetXMCombinationDetailsById(id);
            if (xmcombinationdetails == null)
                return;
    
            if (!this._context.IsAttached(xmcombinationdetails))
                this._context.XMCombinationDetails.Attach(xmcombinationdetails);
    
            this._context.DeleteObject(xmcombinationdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMCombinationDetails by Id
        /// </summary>
        /// <param name="Ids">XMCombinationDetails Id</param>
        public void BatchDeleteXMCombinationDetails(List<int> ids)
        {
    	   var query = from q in _context.XMCombinationDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmcombinationdetailss = query.ToList();
            foreach (var item in xmcombinationdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMCombinationDetails.Attach(item);  
    
                _context.XMCombinationDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}