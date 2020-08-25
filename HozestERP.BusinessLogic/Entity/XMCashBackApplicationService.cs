
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
    public partial class XMCashBackApplicationService: IXMCashBackApplicationService
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
    	public XMCashBackApplicationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMCashBackApplicationService成员
        /// <summary>
        /// Insert into XMCashBackApplication
        /// </summary>
        /// <param name="xmcashbackapplication">XMCashBackApplication</param>
    	public void InsertXMCashBackApplication(XMCashBackApplication xmcashbackapplication)
    	{	
            if (xmcashbackapplication == null)
                return;
    
            if (!this._context.IsAttached(xmcashbackapplication))
    			
                this._context.XMCashBackApplications.AddObject(xmcashbackapplication);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMCashBackApplication
        /// </summary>
        /// <param name="xmcashbackapplication">XMCashBackApplication</param>
        public void UpdateXMCashBackApplication(XMCashBackApplication xmcashbackapplication)
        {
            if (xmcashbackapplication == null)
                return;
    
            if (this._context.IsAttached(xmcashbackapplication))
                this._context.XMCashBackApplications.Attach(xmcashbackapplication);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMCashBackApplication list
        /// </summary>
        public List<XMCashBackApplication> GetXMCashBackApplicationList()
        {		
            var query = from p in this._context.XMCashBackApplications
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMCashBackApplication Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCashBackApplication Page List</returns>
        public PagedList<XMCashBackApplication> SearchXMCashBackApplication(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMCashBackApplications
                        orderby p.Id
                        select p;
            return new PagedList<XMCashBackApplication>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMCashBackApplication by Id
        /// </summary>
        /// <param name="id">XMCashBackApplication Id</param>
        /// <returns>XMCashBackApplication</returns>   
        public XMCashBackApplication GetXMCashBackApplicationById(int id)
        {
            var query = from p in this._context.XMCashBackApplications
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMCashBackApplication by Id
        /// </summary>
        /// <param name="Id">XMCashBackApplication Id</param>
        public void DeleteXMCashBackApplication(int id)
        {
            var xmcashbackapplication = this.GetXMCashBackApplicationById(id);
            if (xmcashbackapplication == null)
                return;
    
            if (!this._context.IsAttached(xmcashbackapplication))
                this._context.XMCashBackApplications.Attach(xmcashbackapplication);
    
            this._context.DeleteObject(xmcashbackapplication);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMCashBackApplication by Id
        /// </summary>
        /// <param name="Ids">XMCashBackApplication Id</param>
        public void BatchDeleteXMCashBackApplication(List<int> ids)
        {
    	   var query = from q in _context.XMCashBackApplications
                    where ids.Contains(q.Id)
                    select q;
            var xmcashbackapplications = query.ToList();
            foreach (var item in xmcashbackapplications)
            {
                if (!_context.IsAttached(item))
                    _context.XMCashBackApplications.Attach(item);  
    
                _context.XMCashBackApplications.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
