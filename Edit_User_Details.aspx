<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit_User_Details.aspx.cs" Inherits="PPT.Edit_User_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style5
        {
            width: 100%;
        }
        .style6
        {
            background-color: #6699FF;
        }
        .style7
        {
            font-size: x-small;
        }
        .style8
        {
            width: 1px;
        }
        .style9
        {
            width: 252px;
        }
        .style11
        {
            width: 100px;
            font-size: x-small;
        }
        .style26
        {
            width: 411px;
            font-size: x-small;
            height: 4px;
        }
        .style27
        {
            width: 119px;
            font-size: x-small;
            height: 25px;
        }
        .style28
        {
            width: 1px;
            height: 25px;
        }
        .style29
        {
            width: 252px;
            height: 25px;
        }
        .style30
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

 
    <table class="style5">
        <tr> 
         
            <td class="Header" colspan="5" style="text-align: center; color: #000000">
                Edit User Details</td>
        </tr>
        <tr>
            <td class="style7" colspan="5">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                    style="color: #CC3300; font-weight: 700;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                Select Project</td>
            <td class="style8">
                <asp:Label ID="Lbl_Dept" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">
                <asp:UpdatePanel ID="Upd_Pan_Sel_Dept" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Drp_Project_Name"  Width="130px" runat="server" AutoPostBack="True" 
                            Font-Size="X-Small" 
                            onselectedindexchanged="Drp_Project_Name_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_Proj_Name" runat="server" 
                            ControlToValidate="Drp_Project_Name" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                Select User Group:</td>
            <td class="style8">
                <asp:Label ID="Lbl_User_Group" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">
                <asp:UpdatePanel ID="Upd_Pan_Sel_UG" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Drp_User_Group" Width="130px" runat="server" AutoPostBack="True" 
                            Font-Size="X-Small" 
                            onselectedindexchanged="Drp_User_Group_SelectedIndexChanged" 
                            style="margin-bottom: 1px">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_UG" runat="server" 
                            ControlToValidate="Drp_User_Group" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
       
        <tr>
            <td class="style11">
                Select User:</td>
            <td class="style8">
                <asp:Label ID="Lbl_User" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">
                <asp:UpdatePanel ID="Upd_Pan_Sel_User" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Drp_User" Width="130px" runat="server" AutoPostBack="True" 
                            Font-Size="X-Small" 
                            onselectedindexchanged="Drp_User_SelectedIndexChanged" 
                            style="margin-bottom: 1px">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_User" runat="server" 
                            ControlToValidate="Drp_User" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <%-- <tr>
            <td class="style11">
                Select Site ID</td>
            <td class="style8">
                <asp:Label ID="Lbl_Site_ID" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">
                <asp:UpdatePanel ID="Upd_Pan_Sel_Site_ID" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Drp_Site_ID" runat="server" Font-Size="X-Small" 
                             
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_Site_ID" runat="server" 
                            ControlToValidate="Drp_Site_ID" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>--%>
        <tr>
            <td class="style11">
                Edit User Name</td>
            <td class="style8">
                <asp:Label ID="Lbl_User_Name" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                    </td>
            <td class="style26">
                <asp:UpdatePanel ID="Up_User_Name" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_User_Name" runat="server" Font-Size="X-Small" 
                            Width="207px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req_User_Name" runat="server" 
                            ControlToValidate="txt_User_Name" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style27">
                Edit User Display Name</td>
            <td class="style28">
                <asp:Label ID="Lbl_User_Dis_Name" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style29">
                <asp:UpdatePanel ID="Up_User_Dis_Name" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_User_Dis_Name" runat="server" Font-Size="X-Small" 
                            Width="203px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req_User_Dis_Name" runat="server" 
                            ControlToValidate="txt_User_Dis_Name" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="style30">
                </td>
            <td class="style30">
                </td>
        </tr>
        <tr>
            <td class="style11">
                Edit Email ID</td>
            <td class="style8">
                <asp:Label ID="Lbl_Email" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">
                <asp:UpdatePanel ID="Up_Email" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_EmailID" runat="server" Font-Size="X-Small" Width="203px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req_EmailID" runat="server" 
                            ControlToValidate="txt_EmailID" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
       
        <tr>
            <td class="style11">
                Edit User Group:</td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                <asp:UpdatePanel ID="Upd_Pan_Sel_UG1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="Drp_User_Group1" Width="130px" runat="server" AutoPostBack="True" 
                            Font-Size="X-Small" 
                            style="margin-bottom: 1px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
                          
               <tr>
            <td class="style11">
              Edit Site ID:   </td>
            <td class="style8">
                &nbsp;</td>
            <td class="style11" width="150">Select All:
                <asp:CheckBox ID="Chk_Select_All" runat="server" AutoPostBack="True" 
                    oncheckedchanged="Chk_Select_All_CheckedChanged" style="font-size: x-small" />
                    </td>
          </tr>
          <tr>
            <td class="style11">
              </td>
            <td class="style8">
                &nbsp;</td>
       <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
               <asp:GridView ID="grdINV1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" ShowFooter="True" Font-Size="X-Small" 
                            onrowdatabound="grdINV1_RowDataBound" style="text-align: left" Width="266px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>               
                <asp:TemplateField HeaderText="Investigator ID">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_INVID" runat="server" Text='<%# Bind("INVID") %>' 
                            BorderStyle="None" Enabled="False" Font-Overline="False" Font-Size="X-Small" 
                            Height="16px" Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Investigator Name">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_INVNAME" runat="server" 
                            Text='<%# Bind("INVNAME") %>' Enabled="False" Font-Bold="True" 
                            Font-Overline="False" Font-Size="X-Small" Height="16px" Width="100px"></asp:TextBox>
                        &nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Select Investigator">            
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
              </ContentTemplate>
                </asp:UpdatePanel>     
            </td>     
                            
        </tr>
          

        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                <asp:Button ID="Btn_Update" runat="server" Font-Size="X-Small" 
                    onclick="Btn_Update_Click" Text="Update" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
