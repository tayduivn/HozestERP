﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="AllocateAdd.aspx.cs" Inherits="HozestERP.Web.ManageInventory.AllocateAdd" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
         <script type="text/javascript">
             function autoCompleteBind() {
                 $(".ProductName").autocomplete({
                     source: function (request, response) {
                         jQuery.ajax({
                             url: "ProductList.ashx?action=PdInfo",
                             data: "q=" + encodeURI(request.term),
                             type: "GET",
                             dataType: "json",
                             success: function (data) {
                                 response($.map(data, function (item) {
                                     return {
                                         label: item.ProductName + ", 编码:" + item.ManufacturersCode + ", 尺寸:" + item.Specifications,
                                         value: item.ProductName,
                                         order: item
                                     }
                                 }));
                             }
                         });
                     }
                 }, {
                     select: function (e, i, j) {
                         var list = $(".ProductName");
                         if (list != null && list.length > 0) {
                             var productcode = $(this).parent().prev().find("input[id=txtProductCode]");      //获取商品名称控件
                             productcode.val(i.item.order.ManufacturersCode);                                       //赋值
                             var Specifications = productcode.parent().next().next().find("input[id=lblSpecifications]");     //
                             Specifications.val(i.item.order.Specifications);
                             var unit = Specifications.parent().next().next().find("input[id=txtUnit]");
                             unit.val(i.item.order.ProductUnit);
                         }
                     }
                 });
             }
    </script>
    <style type="text/css">
        .table
        {
            width: 100%;
            border-collapse: collapse;
            font-size: 13px;
            height: 24px;
            line-height: 24px;
            color: #9BC2DB;
            text-align: center;
        }
        .table tr th
        {
            border: solid 1px #9BC2DB;
            background: #9BC2DB;
            color: #FFF;
            font-size: 13px;
            height: 24px;
            line-height: 24px;
        }
        .table tr th.th_border
        {
            border-right: solid 1px #9BC2DB;
            border-left: solid 1px #9BC2DB;
        }
        .table tr td
        {
            border: solid 1px #9BC2DB;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdfJsonContent" runat="server" />
    <asp:Label ID="lblTitle" runat="server">  <span class="detailTitle" style="float: left;"></span></asp:Label>
    <hr size="1" style="color: #cccccc; clear: both;" />
    <table class="detailTable" width="100%" border="0" cellspacing="0" cellpadding="3">
        <tbody>
            <tr>
                <td style="width: 140px" align="right">
                    调拨单号
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <asp:Label ID="lblMessage" runat="server">  <font color="red">保存后自动生成</font></asp:Label>
                    <asp:Literal ID="lblRef" runat="server"></asp:Literal>
                </td>
                <td style="width: 140px" align="right">
                    业务日期
                </td>
                <td style="width: 218px; border-right: 1px soild red;">
                    <input id="txtDeliveryDate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"
                        runat="server" style="width: 60%;" />
                </td>
            </tr>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />

    <ext:Store  ID="WareHoursesoutStore" runat="server" AutoLoad="false" OnRefreshData="WareHoursesoutRefresh">
        <DirectEventConfig>
            <EventMask ShowMask="false" />
        </DirectEventConfig>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="id" Type="String" Mapping="Id" />
                    <ext:RecordField Name="name" Type="String" Mapping="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{WareHoursesout}.setValue(#{WareHoursesout}.store.getAt(0).get('id'));" />
        </Listeners>
    </ext:Store>
    <tr>
    <td style="width: 140px" align="right">
                    调出项目
                </td>
    <td>
    <ext:ComboBox 
        ID="ProjectOut" 
        runat="server" 
        Editable="false" 
        TypeAhead="true" 
        Mode="Local"
        ForceSelection="true" 
        TriggerAction="All" 
        SelectOnFocus="true" 
        EmptyText="请选择项目">
        <Listeners>
            <Select Handler="#{WareHoursesout}.clearValue(); #{WareHoursesoutStore}.reload();" />
        </Listeners>  
        <DirectEvents>
        <BeforeRender OnEvent="WareHoursesoutLoad"></BeforeRender>
        </DirectEvents>      
    </ext:ComboBox>
    </td>
    <td style="width: 140px" align="right">
                    调出仓库
                </td>
    <td>
    <ext:ComboBox 
        ID="WareHoursesout" 
        runat="server" 
        StoreID="WareHoursesoutStore" 
        Editable="false" 
        TypeAhead="true" 
        Mode="Local"
        ForceSelection="true" 
        TriggerAction="All" 
        DisplayField="name" 
        ValueField="id"
        EmptyText="请选择仓库" 
        ValueNotFoundText="请选择仓库"
        />
        </td>
        </tr>

    <ext:Store  ID="WareHoursesinStore" runat="server" AutoLoad="false" OnRefreshData="WareHoursesinRefresh">
        <DirectEventConfig>
            <EventMask ShowMask="false" />
        </DirectEventConfig>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="id" Type="String" Mapping="Id" />
                    <ext:RecordField Name="name" Type="String" Mapping="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{WareHoursesin}.setValue(#{WareHoursesin}.store.getAt(0).get('id'));" />
        </Listeners>
    </ext:Store>
    <tr>
    <td style="width: 140px" align="right">
                    调入项目
                </td>
    <td>
    <ext:ComboBox 
        ID="ProjectIn" 
        runat="server" 
        Editable="false" 
        TypeAhead="true" 
        Mode="Local"
        ForceSelection="true" 
        TriggerAction="All" 
        SelectOnFocus="true" 
        EmptyText="请选择项目">
        <Listeners>
            <Select Handler="#{WareHoursesin}.clearValue(); #{WareHoursesinStore}.reload();" />
        </Listeners>        
        <DirectEvents>
        <BeforeRender OnEvent="WareHoursesinLoad"></BeforeRender>
        </DirectEvents>  
    </ext:ComboBox>
    </td>
    <td style="width: 140px" align="right">
                    调入仓库
                </td>
    <td>
    <ext:ComboBox 
        ID="WareHoursesin" 
        runat="server" 
        StoreID="WareHoursesinStore" 
        Editable="false" 
        TypeAhead="true" 
        Mode="Local"
        ForceSelection="true" 
        TriggerAction="All" 
        DisplayField="name" 
        ValueField="id"
        EmptyText="请选择仓库" 
        ValueNotFoundText="请选择仓库"
        />
        </td>
        </tr>
            <tr>
                <td style="width: 140px" align="right">
                    备注
                </td>
                <td style="width: 218px; border-right: 1px soild red;" colspan="3">
                    <asp:TextBox ID="txtNote" runat="server" Text="" Width="80%" TextMode="MultiLine"
                        Height="60px"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <%=TableStr %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" ValidationGroup="ClientValidationGroup"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.AllocateAdd.Save %>" OnClick="btnSave_Click"
                    OnClientClick="on_buttonClientClick();" />
            </td>
            <td style="width: 10px">
            </td>
            <td>
                  <asp:Button ID="btnSingleSubmitAllocate" SkinID="button6" runat="server" Text="提交调拨单" OnClick="btnSingleSubmitAllocate_Click"
                    Visible="<% $CRMIsActionAllowed:ManageInventory.AllocateList.SubmitAllocateInfo %>" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(document).ready(function () {
            //autoCopleteBind();
            //新增一行
            $(document).on("click", "#imgAdd", function () {
                var tr = "<tr  id=\"mytr\"><td><input  id=\"txtProductCode\" class=\"TextBox ProductCode\" style=\"text-align: left;width: 90%\" type=\"text\" value=''  readonly=\"readonly\" /></td><td><input  id=\"txtProductName\" class=\"TextBox ProductName\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><input style=\"background: transparent; border: 0; width: 95px;\" readonly=\"readonly\"  id=\"lblSpecifications\" value='' /></td><td><input  id=\"txtProductCount\" class=\"TextBox\" style=\"text-align: left;width: 90%\" type=\"text\" value='' /></td><td><input  id=\"txtUnit\" class=\"TextBox\" style=\"text-align: left; width: 55px;\" value='' readonly=\"readonly\" /></td><td><img src=\"../images/icons/add.png\" title=\"添加\" id=\"imgAdd\" alt=\"添加\"  /><img src=\"../images/icons/delete.png\" title=\"删除\" id=\"imgDelete\" alt=\"删除\" onclick=\"DeleteItem(this)\" /></td></tr>";
                $("#MyPurchaseProductList").append(tr);
                // jQuery 1.7+
            });
            //删除
            $(document).on("click", "#imgDelete", function () {
                if ($(this).parent().parent().prev().attr("id") == 'mytr') {
                    $(this).parent().parent().remove();
                }
            });
            $(document).on("keyup", "#txtProductName", function () {
                autoCompleteBind();
            });
        });

        function on_buttonClientClick() {
            getJsonContent();
        }

        function getJsonContent() {
            var json = '[';
            $("#MyPurchaseProductList").find("tr[id=mytr]").each(function (i, val) {
                if (i == 0) {
                    json = json + '{';
                }
                else {
                    json = json + ',{';
                }
                $(this).find("input").each(function () {
                    var t = $(this).val();
                    var id = $(this).attr("id");
                    json = json + '"' + id + '"' + ':' + '"' + t + '",';
                });
                json = json.substring(0, json.length - 1);
                json = json + '}';
            });
            json = json + ']';
            document.getElementById("<%=hdfJsonContent.ClientID %>").value = json;
        }
    </script>
</asp:Content>
