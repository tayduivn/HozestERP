﻿
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectBusinessCustomerControl.ascx.cs" 
Inherits="HozestERP.Web.Modules.SelectBusinessCustomerControl" %>

    <script language="javascript" type="text/javascript">
        function Show<asp:Literal ID="lblScript" runat="server"></asp:Literal>CustomerDetail(URL) {
            var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:650px;dialogHeight:400px;center:yes;");
            return true;
        }
    </script>
     
<table border="0" cellpadding="0" cellspacing="0"  style="width:100%">
    <tr>
        <td>
            <asp:TextBox ID="txtFullName" runat="server"  Width="95%"  SkinID="ReadOnlyText" ReadOnly="true"></asp:TextBox>
        </td>
        <td style="width:14px;">
            <asp:ImageButton ID="iBtnSelect" ImageUrl="~/App_Themes/Blue/Image/icon_select.gif"
                runat="server" onclick="iBtnSelect_Click"  />
        </td> 
    </tr>
</table>

<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="txtFullName" Font-Name="verdana"
    Font-Size="9pt" runat="server" Display="None">*</asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />

