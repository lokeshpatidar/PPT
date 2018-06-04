<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_User_Group_Rights.aspx.cs" Inherits="PPT.Add_User_Group_Rights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style12
        {
            height: 10px;
            font-size: x-small;
        }
        .style13
        {
            width: 1px;
            height: 10px;
            font-size: x-small;
        }
        .style14
        {
            height: 10px;
            width: 190px;
        }
        .style15
        {
            height: 10px;
            width: 270px;
        }
        .style16
        {
            height: 10px;
        }
        .style17
        {
            width: 126px;
            height: 5px;
            font-size: x-small;
        }
        .style18
        {
            width: 1px;
            height: 5px;
            font-size: x-small;
        }
        .style19
        {
            height: 5px;
            width: 190px;
        }
        .style20
        {
            height: 5px;
            width: 270px;
        }
        .style21
        {
            height: 5px;
        }
        .style22
        {
            font-size: x-small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <p>
        <table class="style1">
            <tr>
                <td colspan="5" 
                    class="Header">
                    Add User Group Functions</td>
            </tr>
            <tr>
                <td class="style22" colspan="5">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                        style="color: #CC3300; font-weight: 700;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    Select Project::</td>
                <td class="style13">
                <asp:Label ID="Lbl_Dept" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
                <td class="style14">
                    <asp:UpdatePanel ID="Upd_Pan_Sel_Dep" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="Drp_Project_Name" runat="server" AutoPostBack="True" 
                                Font-Size="X-Small" 
                                onselectedindexchanged="Drp_Departments_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="Comp_Val_Sel_Dept" runat="server" 
                                ControlToValidate="Drp_Project_Name" ErrorMessage="Required" Font-Size="X-Small" 
                                ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="style15">
                    <asp:Button ID="Btn_Get_Fun" runat="server" onclick="Btn_Get_Fun_Click" 
                        Text="Get Functions" Width="90px" Font-Size="X-Small" 
                        style="margin-left: 11px" />
                </td>
                <td class="style16">
                    </td>
            </tr>
            <tr>
                <td class="style17">
                    Select User Group:</td>
                <td class="style18">
                <asp:Label ID="Lbl_UserGroup" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
                <td class="style19">
                    <asp:UpdatePanel ID="Upd_Pan_Sel_UG" runat="server">
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
                <td class="style20">
                    </td>
                <td class="style21">
                </td>
            </tr>
            <tr>
                <td class="style17">
                    &nbsp;</td>
                <td class="style18">
                    &nbsp;</td>
                <td class="style19">
                    &nbsp;</td>
                <td class="style20">
                    &nbsp;</td>
                <td class="style21">
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
                    <HeaderTemplate>
                        <asp:Button ID="Btn_Add_Fun" runat="server" Font-Size="X-Small" 
                            onclick="Btn_Add_Fun_Click" Text="Add" Width="60px" />
                    </HeaderTemplate>
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
                <asp:TemplateField HeaderText="Select Function">
                    <ItemTemplate>
                        <asp:CheckBox ID="Chk_Sel_Fun" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
          
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
        <br />
    </p>
</asp:Content>
