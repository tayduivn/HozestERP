﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPages/Root.Master" 
CodeBehind="BusinessDataB2C.aspx.cs" Inherits="HozestERP.Web.ManageBusiness.BusinessDataB2C" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<%@ Register Src="~/Modules/ImageButtonSelectSingleCustomerControl.ascx" TagName="ImageButtonSelectSingleCustomerControl"  TagPrefix="CRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
   <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script> 
   <script src="../Script/CommonManager.js" type="text/javascript"></script>

   <style type="text/css">
  
       .headbackground
        { 
            border-top-color:transparent;
            border-bottom-color:transparent;
            border-left-color:transparent;
            border-right-color:transparent; 
        }
        
        .gridlist {
            background: none repeat 0% 0% #FFF;
            color:#444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border:0px;
        }
          
</style> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 100px" align="right">
                合同编号：
            </td>
            <td style="width: 200px;" align="left">
                <asp:TextBox ID="txtContractNumber" Width="100%" runat="server"></asp:TextBox>
            </td>
            <td style="width: 20px">
            </td>
            <td style="width: 100px" align="right">   
                客户公司：
            </td>
            <td style="width: 200px" align="left">
                <asp:TextBox ID="txtClientCompany" Width="100%" runat="server"></asp:TextBox>
            </td> 
            
            <td style="width: 20px">
            </td>
            <td style="width: 100px" align="right">
                归属人：
            </td>
            <td style="width: 200px" align="left">
                <asp:TextBox ID="txtBelongingPeople" Width="100%" runat="server"></asp:TextBox>
            </td>  
             <td style="width: 20px">
            </td>
            
            <td style="width: 100px" align="right">
                财务审核：
            </td>
            <td style="width: 200px" align="left">
               <asp:DropDownList ID="ddlFinancialStatus" Width="100%" runat="server">
                    <asp:ListItem Value="-1">--所有--</asp:ListItem>
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:DropDownList>
            </td>  
             <td style="width: 20px">
            </td>

            <td style="text-align: right" colspan="11">
                 <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />  
                 <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"  
                OnClick="btnRefresh_Click" /> 
            </td> 
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" src="../Script/jquery1.9.1/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript"></script>

    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
    SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand" OnRowDataBound="grdvClients_RowDataBound" ShowFooter="true">
    <Columns>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
        </asp:TemplateField> 

           <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>  
                </ItemTemplate>
            </asp:TemplateField> 
              
         <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNumber">
            <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <%# Eval("ContractNumber")%>
            </ItemTemplate> 
         </asp:TemplateField> 

         <asp:TemplateField HeaderText="合同金额"  SortExpression="ContractAmount">
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                 <%# Eval("ContractAmount")%>
            </ItemTemplate> 
         </asp:TemplateField>

         <asp:TemplateField HeaderText="客户公司"  SortExpression="ClientCompany">
            <HeaderStyle Width="160px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
                <%# Eval("ClientCompany")%>
            </ItemTemplate> 
        </asp:TemplateField>

        <asp:TemplateField HeaderText="提交年限"  SortExpression="SubmitLimit">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("SubmitLimit")%>
            </ItemTemplate> 
        </asp:TemplateField>

        <asp:TemplateField HeaderText="提交时间"  SortExpression="SubmitDate">
            <HeaderStyle Width="85px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("SubmitDate")%>
            </ItemTemplate> 
        </asp:TemplateField>

        <asp:TemplateField HeaderText="实际到款金额"  SortExpression="ActualAmount">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("ActualAmount")%>
            </ItemTemplate> 
        </asp:TemplateField>

        <asp:TemplateField HeaderText="归属人"  SortExpression="BelongingName">
            <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("BelongingName")%>
            </ItemTemplate> 
        </asp:TemplateField>

        <asp:TemplateField HeaderText="提交人"  SortExpression="AuthorName">
            <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
            <ItemTemplate>
             <%# Eval("AuthorName")%>
            </ItemTemplate> 
        </asp:TemplateField>

         <asp:TemplateField HeaderText="财务审核" HeaderStyle-HorizontalAlign="Center" SortExpression="FinancialStatus">
               <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="FinancialStatus" runat="server" Checked='<%# Eval("FinancialStatus")%>' /> 
                </ItemTemplate>
            </asp:TemplateField>

        <asp:TemplateField HeaderText="操作"> 
             <HeaderStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
            <ItemTemplate>
                <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2C.Edit %>" />

                <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif" CommandArgument='<%#Eval("ID")%>'
                        ToolTip="删除" CommandName="Del" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2C.Delete %>" />
            </ItemTemplate>
        </asp:TemplateField>
           
    </Columns>
</asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
       <tr>
            <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnAdd" SkinID="button4"  runat="server" Text="新增"  
                     Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2C.Add %>"  />
            </td>

            <%--<td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnImportBusinessDataB2B" SkinID="button4"  runat="server" Text="导入数据"  
                     Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2C.ImportBusinessDataB2B %>"  />
            </td>--%>

            <td style="width: 4px">
            </td>
            <td> 
                <asp:Button ID="btnDelete" runat="server" SkinID="button4" Text="批量删除" 
                 Visible="<% $CRMIsActionAllowed:ManageBusiness.BusinessDataB2C.AllDelete %>" 
                OnClientClick="return CheckSelect(this,99);"  OnClick="btnDelete_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
