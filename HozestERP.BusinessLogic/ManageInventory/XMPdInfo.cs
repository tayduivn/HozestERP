
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-05-09 16:59:04
** 修改人:
** 修改日期:
** 描 述: 
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
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMPdInfo : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Ref
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the WarehouseId
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the BillStatus
        /// </summary>
        public int BillStatus { get; set; }

        /// <summary>
        /// Gets or sets the BillMemo
        /// </summary>
        public string BillMemo { get; set; }

        /// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }

        /// <summary>
        /// Gets or sets the BizDt
        /// </summary>
        public Nullable<System.DateTime> BizDt { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        #endregion
        #region Custom Properties

        public string WareHousesName
        {
            get
            {
                string wareHousesName = "";
                if (this.WarehouseId != null)
                {
                    var wareHouses = IoC.Resolve<XMWareHousesService>().GetXMWareHousesById(this.WarehouseId);
                    if (wareHouses != null)
                    {
                        wareHousesName = wareHouses.Name;
                    }
                }
                return wareHousesName;
            }
        }

        public int ProjectId
        {
            get
            {
                int projectId = 1;
                if (this.WarehouseId != null)
                {
                    var wareHouses = IoC.Resolve<XMWareHousesService>().GetXMWareHousesById(this.WarehouseId);
                    if (wareHouses != null)
                    {
                        projectId = wareHouses.ProjectId.Value;
                    }
                }
                return projectId;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_PdInfoProductDetails list
        /// </summary>
        public virtual ICollection<XMPdInfoProductDetails> XM_PdInfoProductDetails { get; set; }

        #endregion
    }
}