<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSUBJDETAILS.aspx.cs" Inherits="PPT.frmSUBJDETAILS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 431px;
        }
        .style6
        {
            width: 111px;
        }
        .style8
        {
            font-size: small;
            font-family: "Helvetica Neue", "Lucida Grande", "Segoe UI", Arial, Helvetica, Verdana, sans-serif;
            text-align: center;
            color: #000000;
            background-color: #6699FF;
        }
        .style11
        {
            width: 111px;
            height: 22px;
        }
        .style12
        {
            height: 22px;
        }
        .style13
        {
            width: 134px;
            height: 22px;
        }
        .style14
        {
            width: 134px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="style1">
        <tr>
            <td class="Header" colspan="3" >
                Subject Details </td>
        </tr>
          <tr>
            <td>
           <asp:Label ID="lblErrorMsg" runat="server" Font-Size="X-Small" 
        style="color: #FF0000; font-weight: 700; font-family: Arial; font-size: x-small;"></asp:Label></td>
        </tr>
        
        <tr>
            <td class="style13" >
                <span class="styleGrid"><strong>Select Investigator ID:&nbsp;</strong>&nbsp;&nbsp;&nbsp;&nbsp; </span>
            </td>
            <td class="style11" >
                
                        <asp:DropDownList ID="drp_InvID" runat="server" 
                    
                    style="font-family: Arial; font-size: x-small; font-weight: 700; margin-left: 0px;" 
                    Height="17px" Width="104px" 
    AutoPostBack="True" onselectedindexchanged="drp_InvID_SelectedIndexChanged">
                        </asp:DropDownList>
                
            </td>
            <td class="style12" >
                <asp:CompareValidator ID="Comp_Val_Sel_Proj_Name" runat="server" 
                            ControlToValidate="drp_InvID" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style14" >
                &nbsp;</td>
            <td class="style6" >
                
                        &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        </table>

    <asp:GridView ID="SUBJDETAILS" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" font-family="Arial" Font-Size="X-Small" 
        style="text-align: left ; margin-left: 5px" Width="120px" BackColor="#DEBA84" BorderColor="#DEBA84" 
        BorderStyle="None" BorderWidth="1px" CellSpacing="2">
        <Columns>
            <asp:TemplateField HeaderText="STUDYID" HeaderStyle-CssClass="disp-none"  ItemStyle-CssClass="disp-none">
                <ItemTemplate>
                    <asp:TextBox ID="STUDYID" runat="server" style="text-align: left" font-family="Arial" Font-Size="X-Small"
                        Text='<%# Bind("STUDYID") %>' Width="41px" Height="16px" />
                </ItemTemplate>

 <HeaderStyle CssClass="disp-none"></HeaderStyle>

 <ItemStyle CssClass="disp-none"></ItemStyle>
            </asp:TemplateField>

<%--            <asp:TemplateField HeaderText="INVID">
                <ItemTemplate>
                    <asp:TextBox ID="INVID" runat="server" font-family="Arial" Font-Size="X-Small" 
                        Text='<%# Bind("INVID") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Subject ID" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:TextBox ID="SUBJID" runat="server" style="text-align: left" font-family="Arial" Font-Size="X-Small"
                        Text='<%# Bind("SUBJID") %>' Width="70px"  />
                    <%--<asp:RequiredFieldValidator ID="RFV_SUBJID" runat="server" ErrorMessage="Required" ControlToValidate="SUBJID" ></asp:RequiredFieldValidator>--%>

                </ItemTemplate>
            </asp:TemplateField>

<%--            <asp:TemplateField HeaderText="RECYN">
                <ItemTemplate>
                    <asp:CheckBox ID="RECYN" runat="server" font-family="Arial" Font-Size="X-Small"
                        Checked='<%# Checked("RECYN") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>--%>

            <asp:TemplateField HeaderText="UPDATE_FLAG" HeaderStyle-CssClass="disp-none" ItemStyle-CssClass="disp-none" >
                <ItemTemplate>
                    <asp:TextBox ID="UPDATE_FLAG" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("UPDATE_FLAG") %>' Width="22px" />
                </ItemTemplate>

<HeaderStyle CssClass="disp-none"></HeaderStyle>

<ItemStyle CssClass="disp-none"></ItemStyle>
            </asp:TemplateField>
              <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Button ID="bntAdd" runat="server" onclick="bntAdd_Click" 
                        style="font-family: Arial; font-size: x-small" Text="Add" />
                </HeaderTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <asp:Button ID="bntSave" runat="server" Text="Save" onclick="bntSave_Click" font-family="Arial" 
                        Font-Size="X-Small" style="margin-left: 5px ;margin-top: 5px" />
</asp:Content>
