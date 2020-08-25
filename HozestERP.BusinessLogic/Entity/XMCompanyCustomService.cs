
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
    public partial class XMCompanyCustomService: IXMCompanyCustomService
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
    	public XMCompanyCustomService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMCompanyCustomService成员
        /// <summary>
        /// Insert into XMCompanyCustom
        /// </summary>
        /// <param name="xmcompanycustom">XMCompanyCustom</param>
    	public void InsertXMCompanyCustom(XMCompanyCustom xmcompanycustom)
    	{	
            if (xmcompanycustom == null)
                return;
    
            if (!this._context.IsAttached(xmcompanycustom))
    			
                this._context.XMCompanyCustoms.AddObject(xmcompanycustom);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMCompanyCustom
        /// </summary>
        /// <param name="xmcompanycustom">XMCompanyCustom</param>
        public void UpdateXMCompanyCustom(XMCompanyCustom xmcompanycustom)
        {
            if (xmcompanycustom == null)
                return;
    
            if (this._context.IsAttached(xmcompanycustom))
                this._context.XMCompanyCustoms.Attach(xmcompanycustom);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMCompanyCustom list
        /// </summary>
        public List<XMCompanyCustom> GetXMCompanyCustomList()
        {		
            var query = from p in this._context.XMCompanyCustoms
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMCompanyCustom Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCompanyCustom Page List</returns>
        public PagedList<XMCompanyCustom> SearchXMCompanyCustom(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMCompanyCustoms
                        orderby p.Id
                        select p;
            return new PagedList<XMCompanyCustom>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMCompanyCustom by Id
        /// </summary>
        /// <param name="id">XMCompanyCustom Id</param>
        /// <returns>XMCompanyCustom</returns>   
        public XMCompanyCustom GetXMCompanyCustomById(int id)
        {
            var query = from p in this._context.XMCompanyCustoms
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMCompanyCustom by Id
        /// </summary>
        /// <param name="Id">XMCompanyCustom Id</param>
        public void DeleteXMCompanyCustom(int id)
        {
            var xmcompanycustom = this.GetXMCompanyCustomById(id);
            if (xmcompanycustom == null)
                return;
    
            if (!this._context.IsAttached(xmcompanycustom))
                this._context.XMCompanyCustoms.Attach(xmcompanycustom);
    
            this._context.DeleteObject(xmcompanycustom);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMCompanyCustom by Id
        /// </summary>
        /// <param name="Ids">XMCompanyCustom Id</param>
        public void BatchDeleteXMCompanyCustom(List<int> ids)
        {
    	   var query = from q in _context.XMCompanyCustoms
                    where ids.Contains(q.Id)
                    select q;
            var xmcompanycustoms = query.ToList();
            foreach (var item in xmcompanycustoms)
            {
                if (!_context.IsAttached(item))
                    _context.XMCompanyCustoms.Attach(item);  
    
                _context.XMCompanyCustoms.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
