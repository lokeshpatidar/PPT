<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete_User_Group.aspx.cs" Inherits="PPT.Delete_User_Group" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style6
        {
            width: 165px;
        }
        .style7
        {
            width: 106px;
        }
        .style10
        {
            width: 165px;
            height: 13px;
        }
        .style11
        {
            width: 106px;
            height: 13px;
        }
        .style12
        {
            height: 13px;
        }
        .style9
        {
            font-size: x-small;
            }
        .style18
        {
            font-size: x-small;
            width: 12px;
        }
        .style19
        {
            height: 13px;
            width: 12px;
        }
        .style20
        {
            font-size: x-small;
            width: 91px;
        }
        .style21
        {
            width: 91px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="style1">
        <tr>
            <td colspan="5" 
                class="Header">
                Delete User Group</td>
        </tr>
        <tr>
            <td class="style9" colspan="5">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                    style="color: #CC3300; font-weight: 700;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style20">
                Select Project</td>
            <td class="style18">
                <asp:Label ID="Lbl_Sel_Dept" runat="server" Font-Size="Small" 
                    ForeColor="#FF3300" Text="*"></asp:Label>
                </td>
            <td class="style6">
                                 
                        <asp:DropDownList ID="Drp_Project_Name" runat="server" 
                            Font-Size="X-Small" >
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_Dept" runat="server" 
                            ControlToValidate="Drp_Project_Name" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                   
            
            </td>
            <td style="font-weight: 700" class="style7">
                <asp:Button ID="Btn_Get_UG" runat="server" Font-Size="X-Small" Text="Get User Group" 
                    onclick="Btn_Get_UG_Click" />
            </td>
            <td style="font-weight: 700">
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style21">
                </td>
            <td class="style19">
                </td>
            <td class="style10">
                </td>
            <td class="style11">
                </td>
            <td class="style12">
                </td>
        </tr>
        </table>

        <table>
        
                        <asp:GridView ID="Grd_User_List" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" Font-Size="X-Small" ForeColor="#333333" GridLines="None" 
                            Width="196px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="User Group_ID">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_UserUG_ID" runat="server" Enabled="False" 
                                            Font-Size="X-Small" Text='<%# Bind("UserGroup_ID") %>' Height="19px" 
                                            Width="70px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Group Name">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_UG_Name" runat="server" Enabled="False" 
                                            Font-Size="X-Small" Text='<%# Bind("UserGroup_Name") %>' Height="19px" 
                                            Width="113px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No. of Users">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_User_ID_Count" runat="server" Enabled="False" 
                                            Font-Size="X-Small" Text='<%# Bind("User_ID") %>' Width="50px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk_UG" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <HeaderTemplate>
                                        <asp:Button ID="Bth_Delete" runat="server" Font-Size="X-Small" Text="Delete" 
                                            onclick="Bth_Delete_Click" />
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
