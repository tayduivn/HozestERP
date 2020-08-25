﻿using Ext.Net;
using HozestERP.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HozestERP.Web.ManagePortlet
{
    public partial class ProductMinPriceDetails : BaseAdministrationPage, ISearchPage
    {
        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            
        }

        public void Face_Init()
        {
            
        }

        public void SetTrigger()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            var data = XMProductService.getProductByMinPriceUnSet(brandTypeId);
            StoreWorker.DataSource = data;
            StoreWorker.DataBind();
        }

        protected void Data_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            BindGrid();
        }

        private int brandTypeId
        {
            get
            {
                return CommonHelper.QueryStringInt("brandTypeId");
            }
        }
    }
}