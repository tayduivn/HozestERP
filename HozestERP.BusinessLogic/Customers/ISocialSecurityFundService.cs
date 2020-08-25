
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-03-01 09:19:34
** 修改人:
** 修改日期:
** 描 述: 接口类
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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.Customers
{
    public partial interface ISocialSecurityFundService
    {
        #region ISocialSecurityFundService成员
        /// <summary>
        /// Insert into SocialSecurityFund
        /// </summary>
        /// <param name="socialsecurityfund">SocialSecurityFund</param>
        void InsertSocialSecurityFund(SocialSecurityFund socialsecurityfund);

        /// <summary>
        /// Update into SocialSecurityFund
        /// </summary>
        /// <param name="socialsecurityfund">SocialSecurityFund</param>
        void UpdateSocialSecurityFund(SocialSecurityFund socialsecurityfund);

        /// <summary>
        /// get to SocialSecurityFund list
        /// </summary>
        List<SocialSecurityFund> GetSocialSecurityFundList();

        List<SocialSecurityFund> GetSocialSecurityFundListByData(int DepartmentID, List<int> DepIdList, string FullName, int Year, int Month);
        Department GetDepartmentName(int CustomerInfoID);
        List<CustomerInfo> GetCustomerInfoByIDNumber(string IDNumber);
        SocialSecurityFund GetListByYearMonthCustomerInfoID(int Year, int Month, int CustomerInfoID);

        /// <summary>
        /// get to SocialSecurityFund Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>SocialSecurityFund Page List</returns>
        PagedList<SocialSecurityFund> SearchSocialSecurityFund(int pageIndex, int pageSize, string sortExpression, string sortDirection);

        /// <summary>
        /// get a SocialSecurityFund by ID
        /// </summary>
        /// <param name="id">SocialSecurityFund ID</param>
        /// <returns>SocialSecurityFund</returns>   
        SocialSecurityFund GetSocialSecurityFundByID(int id);

        /// <summary>
        /// delete SocialSecurityFund by ID
        /// </summary>
        /// <param name="ID">SocialSecurityFund ID</param>
        void DeleteSocialSecurityFund(int id);

        /// <summary>
        /// Batch delete SocialSecurityFund by ID
        /// </summary>
        /// <param name="IDs">SocialSecurityFund ID</param>
        void BatchDeleteSocialSecurityFund(List<int> ids);

        #endregion
    }
}
