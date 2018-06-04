<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Remove_User_Rights.aspx.cs" Inherits="BZ_eCRF.Remove_User_Rights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            background-color: #6699FF;
        }
        .style4
        {
            width: 7px;
        }
        .style5
        {
            width: 195px;
        }
        .style6
        {
            height: 28px;
            font-size: x-small;
        }
        .style8
        {
            width: 195px;
            height: 28px;
        }
        .style9
        {
            height: 28px;
        }
        .style10
        {
            height: 28px;
            width: 283px;
        }
        .style11
        {
            width: 283px;
        }
        .style12
        {
            font-size: x-small;
            width: 99px;
        }
        .style13
        {
            width: 4px;
            height: 28px;
        }
        .style14
        {
            width: 4px;
        }
        .style15
        {
            font-size: x-small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="style1">
        <tr>
            <td class="Header" colspan="5" >
                Remove User Rights</td>
        </tr>
        <tr>
            <td class="style15" colspan="5">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                        style="color: #CC3300; font-weight: 700;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Select Project:</td>
            <td class="style13">
                <asp:Label ID="Lbl_Sel_Dept" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style8">
                <asp:UpdatePanel ID="Upd_Pan_Sel_Dept" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Drp_Project_Name" runat="server" AutoPostBack="True" 
                            Font-Size="X-Small" 
                            onselectedindexchanged="Drp_Project_Name_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_Proj_Name" runat="server" 
                            ControlToValidate="Drp_Project_Name" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style10">
                        <asp:Button ID="btn_Get_Fun" runat="server" Font-Size="X-Small" 
                            onclick="btn_Get_Doc_List_Click" Text="Get Functions" />
            </td>
            <td class="style9">
            </td>
        </tr>
        <tr>
            <td class="style12">
                Select User Group:</td>
            <td class="style14">
                <asp:Label ID="Lbl_Sel_UserGroup" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style5">
                <asp:UpdatePanel ID="Upd_Pan_Sel_UG" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Drp_User_Group" runat="server" AutoPostBack="True" 
                            Font-Size="X-Small" 
                            onselectedindexchanged="Drp_User_Group_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_UG" runat="server" 
                            ControlToValidate="Drp_User_Group" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                Select User:</td>
            <td class="style14">
                <asp:Label ID="Lbl_Sel_User" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style5">
                <asp:UpdatePanel ID="Upd_Pan_Sel_User" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Drp_User" runat="server" Font-Size="X-Small">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_User" runat="server" 
                            ControlToValidate="Drp_User" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style14">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style11">
                    &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>

        <table>
        
        
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#A55129" 
            GridLines="None" Font-Size="X-Small">
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
                <asp:TemplateField HeaderText="Add">
                    <HeaderTemplate>
                        <asp:Button ID="Btn_Add_Fun" runat="server" Font-Size="X-Small" 
                            onclick="Btn_Add_Fun_Click" Text="Delete" Width="60px" />
                    </HeaderTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        
        
        </table>
&nbsp;&nbsp;&nbsp; 
</asp:Content>
