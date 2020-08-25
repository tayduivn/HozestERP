﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderUpdateProductDetails : BaseAdministrationPage, ISearchPage
    {
        public string ManufacturersCodeRecord = "";
        public List<HozestERP.BusinessLogic.ManageProject.XMDelivery> DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
        public List<XMXLMInventory> XLMInventoryList = new List<XMXLMInventory>();
        public List<int> InventoryList = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Info = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
                if (Info != null)
                {
                    this.hidPlatformTypeId.Value = Info.PlatformTypeId.ToString();
                }
                this.BindGrid(1, Master.PageSize);
            }
        }

        /// <summary>
        /// 订单OrderCode
        /// </summary>
        public string OrderCode
        {
            get
            {
                return CommonHelper.QueryString("OrderCode");
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            //仓库绑定
            this.ddlWarehouseID.Items.Clear();
            var codeList = base.CodeService.GetCodeListInfoByCodeTypeID(227, false);
            this.ddlWarehouseID.DataSource = codeList;
            this.ddlWarehouseID.DataTextField = "CodeName";
            this.ddlWarehouseID.DataValueField = "CodeID";
            this.ddlWarehouseID.DataBind();
            this.ddlWarehouseID.Items.Insert(0, new ListItem("---所有---", "-1"));

            this.Master.SetTitleVisible = false;
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            List<XMOrderInfoProductDetails> list = new List<XMOrderInfoProductDetails>();
            var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
            if (OrderInfo != null)
            {
                var OrderProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsList(OrderInfo.ID);
                //if (OrderInfo.PlatformTypeId == 259)//判断是否唯品会订单，排除非CM开头的产品
                //{
                //    if (OrderProductDetails.Count > 0)
                //    {
                //        foreach (XMOrderInfoProductDetails item in OrderProductDetails)
                //        {
                //            if (item.PlatformMerchantCode.Length > 2)
                //            {
                //                var ddh = item.PlatformMerchantCode.Substring(0, 2);
                //                if (ddh == "CM")
                //                {
                //                    list.Add(item);
                //                }
                //            }
                //            else
                //            {
                //                list.Add(item);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        list = OrderProductDetails;
                //    }
                //}
                //else
                //{
                foreach (XMOrderInfoProductDetails item in OrderProductDetails)
                {
                    list.Add(item);
                }
                //}
            }

            var pageList = new PagedList<XMOrderInfoProductDetails>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());

            //新增编码行
            this.grdvClients.EditIndex = pageList.Count();
            pageList.Add(new XMOrderInfoProductDetails());
            this.Master.BindData(this.grdvClients, pageList);
        }

        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                #region 修改
                if (e.CommandName.Equals("OrderProductUpdate"))
                {
                    try
                    {
                        var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
                        //订单详细信息
                        var ProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsByID(Convert.ToInt32(e.CommandArgument));

                        //编辑行
                        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                        HtmlInputText lblPlatformMerchantCode = (HtmlInputText)gvr.FindControl("lblPlatformMerchantCode");//商品编码
                        HtmlInputText txtProductName = (HtmlInputText)gvr.FindControl("txtProductName");
                        HtmlInputControl lblSpecifications = (HtmlInputControl)gvr.FindControl("lblSpecifications");
                        HtmlInputControl lblManufacturersCode = (HtmlInputControl)gvr.FindControl("lblManufacturersCode");//厂家编码
                        HtmlInputText txtProductNum = (HtmlInputText)gvr.FindControl("txtProductNum");
                        TextBox txtFactoryPrice = (TextBox)gvr.FindControl("txtFactoryPrice");
                        TextBox txtTCostprice = (TextBox)gvr.FindControl("txtTCostprice");
                        TextBox txtSalesPrice = (TextBox)gvr.FindControl("txtSalesPrice");

                        if (OrderInfo != null)
                        {
                            if (ProductDetails != null)
                            {
                                //产品信息
                                var ProductDetailsList = base.XMProductService.GetXMProductListByPlatformMerchantCode(lblPlatformMerchantCode.Value.Trim(), (int)OrderInfo.PlatformTypeId);
                                if (ProductDetailsList != null && ProductDetailsList.Count > 0)
                                {
                                    OrderInfo.IsAbnormal = false;
                                    base.XMOrderInfoService.UpdateXMOrderInfo(OrderInfo);
                                }

                                if (ProductDetails.ProductNum != int.Parse(txtProductNum.Value.Trim()))
                                {
                                    ToInsertXMOrderInfoOperatingRecord("产品信息编辑-数量", ProductDetails.ProductNum.ToString(), txtProductNum.Value.Trim());
                                }
                                if (ProductDetails.FactoryPrice != decimal.Parse(txtFactoryPrice.Text.Trim()))
                                {
                                    ToInsertXMOrderInfoOperatingRecord("产品信息编辑-出厂价", ProductDetails.FactoryPrice.ToString(), txtFactoryPrice.Text.Trim());
                                }
                                if (ProductDetails.TCostprice != decimal.Parse(txtTCostprice.Text.Trim()))
                                {
                                    ToInsertXMOrderInfoOperatingRecord("产品信息编辑-特供价", ProductDetails.TCostprice.ToString(), txtTCostprice.Text.Trim());
                                }
                                if (ProductDetails.SalesPrice != decimal.Parse(txtSalesPrice.Text.Trim()))
                                {
                                    ToInsertXMOrderInfoOperatingRecord("产品信息编辑-销售价", ProductDetails.SalesPrice.ToString(), txtSalesPrice.Text.Trim());
                                }
                                if (ProductDetails.PlatformMerchantCode != lblPlatformMerchantCode.Value.Trim())
                                {
                                    ToInsertXMOrderInfoOperatingRecord("产品信息编辑-商品编码", ProductDetails.PlatformMerchantCode, lblPlatformMerchantCode.Value.Trim());
                                }
                                ProductDetails.TManufacturersCode = lblManufacturersCode.Value;
                                ProductDetails.PlatformMerchantCode = lblPlatformMerchantCode.Value;
                                ProductDetails.ProductName = txtProductName.Value.Trim();
                                ProductDetails.Specifications = lblSpecifications.Value;
                                ProductDetails.ProductNum = int.Parse(txtProductNum.Value.Trim());
                                ProductDetails.FactoryPrice = decimal.Parse(txtFactoryPrice.Text.Trim());
                                ProductDetails.TCostprice = decimal.Parse(txtTCostprice.Text.Trim());
                                ProductDetails.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                                ProductDetails.UpdateID = HozestERPContext.Current.User.CustomerID;
                                ProductDetails.UpdateDate = DateTime.Now;
                                base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(ProductDetails);

                                base.ShowMessage("操作成功！");
                            }
                            else
                            {
                                XMOrderInfoProductDetails orderproduct = new XMOrderInfoProductDetails();
                                orderproduct.OrderInfoID = OrderInfo.ID;
                                orderproduct.TManufacturersCode = lblManufacturersCode.Value;
                                orderproduct.PlatformMerchantCode = lblPlatformMerchantCode.Value;
                                orderproduct.ProductName = txtProductName.Value.Trim();
                                orderproduct.Specifications = lblSpecifications.Value;
                                orderproduct.ProductNum = int.Parse(txtProductNum.Value.Trim());
                                orderproduct.FactoryPrice = decimal.Parse(txtFactoryPrice.Text.Trim());
                                orderproduct.TCostprice = decimal.Parse(txtTCostprice.Text.Trim());
                                orderproduct.SalesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                                orderproduct.CreateID = HozestERPContext.Current.User.CustomerID;
                                orderproduct.CreateDate = DateTime.Now;
                                orderproduct.UpdateID = HozestERPContext.Current.User.CustomerID;
                                orderproduct.UpdateDate = DateTime.Now;
                                orderproduct.IsAudit = false;
                                orderproduct.IsEnable = false;
                                orderproduct.IsExpedited = false;
                                base.XMOrderInfoProductDetailsService.InsertXMOrderInfoProductDetails(orderproduct);

                                ToInsertXMOrderInfoOperatingRecord("产品信息添加", "", "商品编码-" + orderproduct.PlatformMerchantCode);

                                base.ShowMessage("添加成功！");
                                this.BindGrid(1, Master.PageSize);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        base.ShowMessage("请检查数字填写是否正确！");
                    }
                }
                #endregion

                ScriptManager.RegisterStartupScript(this.grdvClients, this.Page.GetType(), "XMOrderInfoProductDetailsEdit", "autoCompleteBind()", true);
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
            }

        }

        public void ToInsertXMOrderInfoOperatingRecord(string PropertyName, string OldValue, string NewValue)
        {
            var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
            if (OrderInfo != null)
            {
                XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                record.PropertyName = PropertyName;
                record.OldValue = OldValue;
                record.NewValue = NewValue;
                record.OrderInfoId = OrderInfo.ID;
                record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                record.UpdateTime = DateTime.Now;
                base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
            }
        }

        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var OrderInfoProductDetail = e.Row.DataItem as XMOrderInfoProductDetails;

                ImageButton imgBtnSpareAddress = (ImageButton)e.Row.FindControl("imgBtnSpareAddress");//备用地址
                ImageButton imgBtnSpareRemarks = (ImageButton)e.Row.FindControl("imgBtnSpareRemarks");//备用备注

                if (imgBtnSpareAddress != null && OrderInfoProductDetail.ID != 0)
                {
                    imgBtnSpareAddress.OnClientClick = "return ShowWindowDetail('备用地址','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMSpareAddressEdit.aspx?Id=" + OrderInfoProductDetail.ID.ToString() + "&TypeID=709', 400, 420, this, function(){});";
                }

                if (imgBtnSpareRemarks != null && OrderInfoProductDetail.ID != 0)
                {
                    imgBtnSpareRemarks.OnClientClick = "return ShowWindowDetail('备用备注','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMSpareRemarksEdit.aspx?Id=" + OrderInfoProductDetail.ID.ToString() + "', 500, 250, this, function(){});";
                }

                if (OrderInfoProductDetail.ID > 0 && OrderInfoProductDetail != null && OrderInfoProductDetail.IsSingleRow != null && OrderInfoProductDetail.IsSingleRow == true)
                {
                    ImageButton imgBtnUpdate = e.Row.FindControl("imgBtnUpdate") as ImageButton;
                    imgBtnUpdate.Visible = false;
                    ImageButton imgBtnDelete = e.Row.FindControl("imgBtnDelete") as ImageButton;
                    imgBtnDelete.Visible = false;
                    imgBtnSpareAddress.Visible = false;
                    imgBtnSpareRemarks.Visible = false;
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            if (int.TryParse(this.grdvClients.DataKeys[e.RowIndex].Value.ToString(), out Id))
            {
                //产品信息
                var XMOrderInfoProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsByID(Id);
                if (XMOrderInfoProductDetails != null)
                {
                    base.XMOrderInfoProductDetailsService.DeleteXMOrderInfoProductDetails(XMOrderInfoProductDetails.ID);
                    ToInsertXMOrderInfoOperatingRecord("产品信息删除", "商品编码-" + XMOrderInfoProductDetails.PlatformMerchantCode, "");
                }
                //GridView绑定
                BindGrid(this.Master.PageIndex, this.Master.PageSize);

                var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
                if (OrderInfo != null)
                {
                    var OrderProductDetails = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsList(OrderInfo.ID);
                    if (OrderProductDetails.Count > 0)
                    {
                        int paramnum = 0;
                        for (int i = 0; i < OrderProductDetails.Count; i++)//遍历产品明细
                        {
                            string Proname = OrderProductDetails[i].ProductName;
                            if (Proname == "无产品")
                            {
                                paramnum++;
                            }
                        }
                        if (paramnum == 0)
                        {
                            OrderInfo.IsAbnormal = false;
                            base.XMOrderInfoService.UpdateXMOrderInfo(OrderInfo);
                        }
                    }
                }
                base.ShowMessage("删除成功！");
            }
        }

        #endregion

        public void btnGetDelivery_Click(object sender, EventArgs e)
        {
            int WarehouseID = int.Parse(this.ddlWarehouseID.SelectedValue.Trim());
            if (WarehouseID == -1)
            {
                base.ShowMessage("你没有选择发货仓库！");
                return;
            }

            List<int> list = this.Master.GetSelectedIds(this.grdvClients);
            list.Remove(0);
            if (list.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                string msg = "";
                var Info = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(OrderCode);
                if (Info != null)
                {
                    int OrderInfoProductCount = 0;//有效的订单产品条数
                    int DeliveryProductCount = 0;//能排单的订单产品条数

                    DeliveryList = new List<HozestERP.BusinessLogic.ManageProject.XMDelivery>();
                    XLMInventoryList = new List<XMXLMInventory>();
                    InventoryList = new List<int>();

                    List<XMOrderInfoProductDetails> OrderInfoProductUnSpare = new List<XMOrderInfoProductDetails>();//无备用地址产品
                    List<XMOrderInfoProductDetails> OrderInfoProductSpare = new List<XMOrderInfoProductDetails>();//有备用地址产品
                    List<XMOrderInfoProductDetails> LatexPillowUnSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，无备用地址产品
                    List<XMOrderInfoProductDetails> LatexPillowSpare = new List<XMOrderInfoProductDetails>();//乳胶枕，U型枕，有备用地址产品

                    foreach (int OrderInfoProductID in list)
                    {
                        var info = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsByID(OrderInfoProductID);
                        if (info != null)
                        {
                            if (info.ProductName.IndexOf("床笠") != -1 || info.ProductName.IndexOf("运费") != -1 || info.ProductName.IndexOf("邮费") != -1 || info.ProductName.IndexOf("无产品") != -1)
                            {
                                continue;
                            }

                            if ((bool)info.IsAudit && (info.IsSingleRow == null || !(bool)info.IsSingleRow))
                            {
                                OrderInfoProductCount++;
                                var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 709);
                                if (info.ProductName.IndexOf("乳胶枕") != -1 || info.ProductName.IndexOf("U型枕") != -1 || info.ProductName.IndexOf("凝胶枕") != -1)
                                {
                                    if (spareAddress != null)
                                    {
                                        LatexPillowSpare.Add(info);
                                    }
                                    else
                                    {
                                        LatexPillowUnSpare.Add(info);
                                    }
                                }
                                else
                                {
                                    if (spareAddress != null)
                                    {
                                        OrderInfoProductSpare.Add(info);
                                    }
                                    else
                                    {
                                        OrderInfoProductUnSpare.Add(info);
                                    }
                                }
                            }
                            else
                            {
                                msg += "订单:" + Info.OrderCode + "，产品编码：" + info.TManufacturersCode + "的产品未审核或已排单！<br/>";
                            }
                        }
                    }

                    if (OrderInfoProductUnSpare.Count > 0)
                    {
                        msg = ToPlanBill(OrderInfoProductUnSpare, Info, WarehouseID, 1, msg);//无备用地址产品
                    }
                    if (LatexPillowUnSpare.Count > 0)
                    {
                        msg = ToPlanBill(LatexPillowUnSpare, Info, WarehouseID, 3, msg);//乳胶枕，U型枕，无备用地址产品
                    }
                    if (OrderInfoProductSpare.Count > 0)
                    {
                        msg = ToPlanBill(OrderInfoProductSpare, Info, WarehouseID, 2, msg);//有备用地址产品
                    }
                    if (LatexPillowSpare.Count > 0)
                    {
                        msg = ToPlanBill(LatexPillowSpare, Info, WarehouseID, 4, msg);//乳胶枕，U型枕，有备用地址产品
                    }

                    foreach (var item in DeliveryList)
                    {
                        if (item.XM_Delivery_Details != null && item.XM_Delivery_Details.Count > 0)
                        {
                            DeliveryProductCount += item.XM_Delivery_Details.Count;
                        }
                    }

                    if (OrderInfoProductCount > 0 && OrderInfoProductCount == DeliveryProductCount)
                    {
                        foreach (var item in DeliveryList)
                        {
                            base.XMDeliveryService.InsertXMDelivery(item);
                        }
                        //订单产品排单状态变为true
                        foreach (int OrderInfoProductID in list)
                        {
                            //订单信息
                            var info = base.XMOrderInfoProductDetailsService.GetXMOrderInfoProductDetailsByID(OrderInfoProductID);
                            if (info != null)
                            {
                                info.IsSingleRow = true;
                                base.XMOrderInfoProductDetailsService.UpdateXMOrderInfoProductDetails(info);
                            }
                        }
                        //减喜临门当日库存
                        for (int i = 0; i < XLMInventoryList.Count; i++)
                        {
                            XLMInventoryList[i].Inventory = InventoryList[i];
                            base.XMXLMInventoryService.UpdateXMXLMInventory(XLMInventoryList[i]);
                        }

                        //操作记录
                        XMOrderInfoOperatingRecord record = new XMOrderInfoOperatingRecord();
                        record.PropertyName = "手动排单";
                        record.OldValue = "IsSingleRow - false";
                        record.NewValue = "IsSingleRow - true";
                        record.OrderInfoId = Info.ID;
                        record.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        record.UpdateTime = DateTime.Now;
                        base.XMOrderInfoOperatingRecordService.InsertXMOrderInfoOperatingRecord(record);
                    }

                    if (msg != "")
                    {
                        base.ShowMessage(msg);
                        return;
                    }
                    else
                    {
                        BindGrid(this.Master.PageIndex, this.Master.PageSize);
                        base.ShowMessage("排单成功！");
                    }
                }
            }
        }

        public string ToPlanBill(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, int WarehouseID, int type, string msg)
        {
            if (type == 1 || type == 3)
            {
                bool ProductExist = false;
                if (GetPlanBillResult(list, Info, null, WarehouseID, type))//排单成功
                {
                    ProductExist = true;
                }

                if (!ProductExist)
                {
                    msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                }
            }
            else if (type == 2 || type == 4)
            {
                List<int?> Ids = new List<int?>();
                var IDs = list.Select(x => x.ID).ToList();
                var SpareAddressList = base.XMSpareAddressService.GetXMSpareAddressListByIDs(IDs, 709);
                foreach (var info in list)
                {
                    if (Ids.Contains(info.ID))
                    {
                        continue;
                    }
                    var spareAddress = base.XMSpareAddressService.GetXMSpareAddressByParm(info.ID, 709);
                    if (spareAddress != null)
                    {
                        //不同产品，相同地址
                        var SpareAddress = SpareAddressList.Where(x => x.FullName == spareAddress.FullName && x.Mobile == spareAddress.Mobile && x.DeliveryAddress == spareAddress.DeliveryAddress).ToList();
                        var OrderInfoProductIds = SpareAddress.Select(x => x.OtherID).ToList();
                        var List = list.Where(x => OrderInfoProductIds.Contains(x.ID)).ToList();
                        Ids.AddRange(OrderInfoProductIds);

                        bool ProductExist = false;
                        if (GetPlanBillResult(List, Info, spareAddress, WarehouseID, type))//排单成功
                        {
                            ProductExist = true;
                        }

                        if (!ProductExist)
                        {
                            msg += "订单:" + Info.OrderCode + "，" + ManufacturersCodeRecord + "商品库存不足！<br/>";
                        }
                    }
                }
            }
            return msg;
        }

        public bool GetPlanBillResult(List<XMOrderInfoProductDetails> list, XMOrderInfo Info, XMSpareAddress SpareAddress, int WarehouseID, int type)
        {
            ManufacturersCodeRecord = "";
            bool complete = true;
            HozestERP.BusinessLogic.ManageProject.XMDelivery delivery = ToInsertDelivery(Info, SpareAddress, type);
            delivery.XM_Delivery_Details = new List<XMDeliveryDetails>();

            foreach (var info in list)
            {
                if (type == 1 || type == 2)
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(WarehouseID, info.TManufacturersCode, "");
                    if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                        {
                            delivery.OrderRemarks = info.SpareRemarks;
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, WarehouseID));
                        //减喜临门当日库存
                        InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                        XLMInventoryList.Add(exist[0]);
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                    }
                }

                if (type == 3 || type == 4)//乳胶枕，U型枕，无备用地址
                {
                    var exist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(693, info.TManufacturersCode, "");//南方仓库
                    if (exist.Count > 0 && exist[0].Inventory >= info.ProductNum)
                    {
                        if (delivery.Shipper == 0)
                        {
                            var product = base.XMProductDetailsService.GetXMProductListByTManufacturersCode(info.TManufacturersCode);
                            if (product != null && product.Count > 0)
                            {
                                delivery.Shipper = product[0].Shipper;
                            }
                        }

                        if (delivery.OrderRemarks == Info.CustomerServiceRemark && !string.IsNullOrEmpty(info.SpareRemarks))
                        {
                            delivery.OrderRemarks = info.SpareRemarks;
                        }

                        delivery.XM_Delivery_Details.Add(GetDeliveryDetails(info, Info.OrderCode, 693));
                        //减喜临门当日库存
                        InventoryList.Add((int)exist[0].Inventory - (int)info.ProductNum);
                        XLMInventoryList.Add(exist[0]);
                    }
                    else
                    {
                        complete = false;
                        ManufacturersCodeRecord += "产品编码：" + info.TManufacturersCode + "，";
                    }
                }
            }

            if (complete == true && delivery.XM_Delivery_Details != null && delivery.XM_Delivery_Details.Count > 0)
            {
                DeliveryList.Add(delivery);
            }

            return complete;
        }

        public HozestERP.BusinessLogic.ManageProject.XMDelivery ToInsertDelivery(XMOrderInfo Info, XMSpareAddress SpareAddress, int type)
        {
            HozestERP.BusinessLogic.ManageProject.XMDelivery info = new HozestERP.BusinessLogic.ManageProject.XMDelivery();
            info.DeliveryTypeId = 480;//正常
            info.DeliveryNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff");//发货单号;
            info.OrderCode = Info.OrderCode;
            if (type == 1 || type == 3)
            {
                info.FullName = Info.FullName;
                info.Mobile = Info.Mobile;
                info.Tel = Info.Tel;
                info.Province = Info.Province;
                info.City = Info.City;
                info.County = Info.County;
                info.DeliveryAddress = Info.DeliveryAddress;
            }
            else if (type == 2 || type == 4)
            {
                info.FullName = SpareAddress.FullName;
                info.Mobile = SpareAddress.Mobile;
                info.Tel = SpareAddress.Tel;
                info.Province = SpareAddress.Province;
                info.City = SpareAddress.City;
                info.County = SpareAddress.County;
                info.DeliveryAddress = SpareAddress.DeliveryAddress;
            }

            info.OrderRemarks = Info.CustomerServiceRemark;
            info.Shipper = 0;
            info.Price = 0;
            info.PrintBatch = 0;
            info.PrintQuantity = 0;
            info.IsDelivery = false;
            info.IsEnabled = false;
            info.CreateDate = DateTime.Now;
            info.CreateId = HozestERPContext.Current.User.CustomerID;
            info.UpdateDate = DateTime.Now;
            info.UpdateId = HozestERPContext.Current.User.CustomerID;
            //base.XMDeliveryService.InsertXMDelivery(info);
            return info;
        }

        public XMDeliveryDetails GetDeliveryDetails(XMOrderInfoProductDetails ProductDetails, string OrderCode, int WarehouseID)
        {
            string PrdouctName = "";
            string Specifications = "";

            XMDeliveryDetails detail = new XMDeliveryDetails();
            //detail.DeliveryId = DeliveryIDType;
            detail.DetailsTypeId = (int)StatusEnum.NormalOrder;//正常订单
            detail.OrderNo = OrderCode;
            var ProductDetail = base.XMProductDetailsService.GetXMProductDetailsByPlatformMerchantCode(ProductDetails.PlatformMerchantCode, (int)ProductDetails.XM_OrderInfo.PlatformTypeId);
            if (ProductDetail != null && ProductDetail.Count > 0)
            {
                detail.ProductlId = ProductDetail[0].ProductId;
                var product = base.XMProductService.GetXMProductById((int)detail.ProductlId);
                if (product != null)
                {
                    PrdouctName = product.ProductName;
                    Specifications = product.Specifications;
                }
            }
            detail.PlatformMerchantCode = ProductDetails.PlatformMerchantCode;
            detail.PrdouctName = PrdouctName;
            detail.Specifications = Specifications;
            detail.ProductNum = (int)ProductDetails.ProductNum;
            detail.WarehouseID = WarehouseID;
            detail.IsEnabled = false;
            detail.CreateDate = DateTime.Now;
            detail.CreateID = HozestERPContext.Current.User.CustomerID;
            detail.UpdateDate = DateTime.Now;
            detail.UpdateID = HozestERPContext.Current.User.CustomerID;
            //IoC.Resolve<IXMDeliveryDetailsService>().InsertXMDeliveryDetails(detail);
            return detail;
        }
    }
}