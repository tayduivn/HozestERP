
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
    public partial class XMSaleDeliveryService: IXMSaleDeliveryService
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
    	public XMSaleDeliveryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMSaleDeliveryService成员
        /// <summary>
        /// Insert into XMSaleDelivery
        /// </summary>
        /// <param name="xmsaledelivery">XMSaleDelivery</param>
    	public void InsertXMSaleDelivery(XMSaleDelivery xmsaledelivery)
    	{	
            if (xmsaledelivery == null)
                return;
    
            if (!this._context.IsAttached(xmsaledelivery))
    			
                this._context.XMSaleDeliveries.AddObject(xmsaledelivery);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMSaleDelivery
        /// </summary>
        /// <param name="xmsaledelivery">XMSaleDelivery</param>
        public void UpdateXMSaleDelivery(XMSaleDelivery xmsaledelivery)
        {
            if (xmsaledelivery == null)
                return;
    
            if (this._context.IsAttached(xmsaledelivery))
                this._context.XMSaleDeliveries.Attach(xmsaledelivery);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMSaleDelivery list
        /// </summary>
        public List<XMSaleDelivery> GetXMSaleDeliveryList()
        {		
            var query = from p in this._context.XMSaleDeliveries
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMSaleDelivery Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleDelivery Page List</returns>
        public PagedList<XMSaleDelivery> SearchXMSaleDelivery(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSaleDeliveries
                        orderby p.Id
                        select p;
            return new PagedList<XMSaleDelivery>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMSaleDelivery by Id
        /// </summary>
        /// <param name="id">XMSaleDelivery Id</param>
        /// <returns>XMSaleDelivery</returns>   
        public XMSaleDelivery GetXMSaleDeliveryById(int id)
        {
            var query = from p in this._context.XMSaleDeliveries
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMSaleDelivery by Id
        /// </summary>
        /// <param name="Id">XMSaleDelivery Id</param>
        public void DeleteXMSaleDelivery(int id)
        {
            var xmsaledelivery = this.GetXMSaleDeliveryById(id);
            if (xmsaledelivery == null)
                return;
    
            if (!this._context.IsAttached(xmsaledelivery))
                this._context.XMSaleDeliveries.Attach(xmsaledelivery);
    
            this._context.DeleteObject(xmsaledelivery);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMSaleDelivery by Id
        /// </summary>
        /// <param name="Ids">XMSaleDelivery Id</param>
        public void BatchDeleteXMSaleDelivery(List<int> ids)
        {
    	   var query = from q in _context.XMSaleDeliveries
                    where ids.Contains(q.Id)
                    select q;
            var xmsaledeliverys = query.ToList();
            foreach (var item in xmsaledeliverys)
            {
                if (!_context.IsAttached(item))
                    _context.XMSaleDeliveries.Attach(item);  
    
                _context.XMSaleDeliveries.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
