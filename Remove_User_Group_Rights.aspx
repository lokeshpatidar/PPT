<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Remove_User_Group_Rights.aspx.cs" Inherits="PPT.Remove_User_Group_Rights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            color: #000000;
            background-color: #6699FF;
        }
        .style4
        {
            font-size: x-small;
        }
        .style5
        {
            width: 216px;
        }
        .style6
        {
            font-size: x-small;
            width: 145px;
        }
        .style7
        {
            font-size: x-small;
            height: 1px;
        }
        .style8
        {
            width: 7px;
            height: 1px;
        }
        .style9
        {
            width: 216px;
            height: 1px;
        }
        .style10
        {
            height: 1px;
        }
        .style11
        {
            width: 7px;
        }
        .style12
        {
            font-size: x-small;
            width: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="style1">
        <tr>
            <td class="Header" colspan="4" >
                Remove User Group Rights</td>
           
        </tr>
        <tr>
            <td class="style7" colspan="5">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                        style="color: #CC3300; font-weight: 700;"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style7">
                Select Project:</td>
            <td class="style8">
                <asp:Label ID="Lbl_Sel_Dept" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">
            <asp:UpdatePanel ID="Upd_Pan_Sel_Dept" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="Drp_Project_Name" runat="server" AutoPostBack="True" 
                        Font-Size="X-Small" 
                        onselectedindexchanged="Drp_Project_Name_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="Comp_Val_Sel_Prj_Name" runat="server" 
                        ControlToValidate="Drp_Project_Name" ErrorMessage="Required" Font-Size="X-Small" 
                        ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
            <td class="style10">
                    <asp:Button ID="Btn_Get_Fun" runat="server" onclick="Btn_Get_Fun_Click" 
                        Text="Get Functions" Width="90px" Font-Size="X-Small" 
                        style="margin-left: 11px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style6">
                Select User Group:</td>
            <td class="style11">
                <asp:Label ID="Lbl_Sel_UserGroup" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style5">
            <asp:UpdatePanel ID="Upd_Pan_Sel_Dept0" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="Drp_User_Group" runat="server" Font-Size="X-Small" 
                        style="margin-left: 0px">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="Comp_Val_Sel_UG" runat="server" 
                        ControlToValidate="Drp_User_Group" ErrorMessage="Required" Font-Size="X-Small" 
                        ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>

        <table>
        
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" ShowFooter="True" Font-Size="X-Small">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Function ID">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_Fun_ID" runat="server" Text='<%# Bind("FunctionID") %>' 
                            Enabled="False" Height="16px"  
                            Width="48px" Font-Size="X-Small"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Parent Function">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_Parent" runat="server" Text='<%# Bind("Parent") %>' 
                            BorderStyle="None" Enabled="False" Font-Overline="False" Font-Size="X-Small" 
                            Height="16px" Width="147px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Function Name">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_Fun_Name" runat="server" 
                            Text='<%# Bind("FunctionName") %>' Enabled="False" Font-Bold="True" 
                            Font-Overline="False" Font-Size="X-Small" Height="16px" Width="178px"></asp:TextBox>
                        &nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="Chk_Sel_Fun" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <HeaderTemplate>
                        <asp:Button ID="Btn_Delete" runat="server" Font-Size="X-Small" Text="Delete" 
                            onclick="Btn_Delete_Click" />
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
        
        </table>
</asp:Content>
