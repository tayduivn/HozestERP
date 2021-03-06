﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CommonEdit.Master"
    AutoEventWireup="true" CodeBehind="ImportLogisticsCostData.aspx.cs" Inherits="HozestERP.Web.ManageProject.ImportLogisticsCostData" %>

<%@ MasterType VirtualPath="~/MasterPages/CommonEdit.Master" %>
<%@ Register Src="~/Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;">
                选择源EXCEL
            </td>
            <td style="width: 400px;">
                <asp:FileUpload ID="DataFilePath" runat="server" Width="100%" />
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
                &nbsp;
            </td>
            <td style="width: 80px;">
                &nbsp;
            </td>
            <td style="width: 400px;">
                <asp:HyperLink ID="DownTemp" runat="server" ForeColor="Red" NavigateUrl="~/Template/物流费用模板.xls">下载物流费用模板</asp:HyperLink>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
      
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
        </tr>
        <tr>
            <td style="width: 8px; height: 8px">
            </td>
            <td style="width: 80px;">
                导入结果
            </td>
            <td>
                <asp:TextBox ID="txtResult" runat="server" Width="100%" Height="80px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contentplaceholder2" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnImport" SkinID="Button2" runat="server" Text="导入" OnClick="btnImport_Click"
                            Visible="<% $CRMIsActionAllowed:ManageProject.ImportLogisticsCostData.ImportLogisticsCost %>" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnImport" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 10px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
