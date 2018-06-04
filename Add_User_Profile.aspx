<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_User_Profile.aspx.cs" Inherits="PPT.Add_User_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style10
        {
            width: 3px;
            font-size: x-small;
        }
        .style16
        {
            font-size: x-small;
            text-align: left;
        }
        .style18
        {
            width: 411px;
            font-size: x-small;
        }
        .style19
        {
            width: 124px;
            font-size: x-small;
            height: 12px;
            text-align: left;
        }
        .style21
        {
            width: 411px;
            font-size: x-small;
            height: 12px;
        }
        .style22
        {
            width: 3px;
            font-size: x-small;
            height: 12px;
        }
        .style23
        {
            height: 12px;
        }
        .style24
        {
            width: 124px;
            font-size: x-small;
            height: 4px;
            text-align: left;
        }
        .style25
        {
            width: 3px;
            font-size: x-small;
            height: 4px;
        }
        .style26
        {
            width: 411px;
            font-size: x-small;
            height: 4px;
        }
        .style27
        {
            height: 4px;
        }
        .style37
        {
            width: 124px;
            font-size: x-small;
            text-align: left;
            height: 25px;
        }
        .style38
        {
            height: 25px;
        }
        .style39
        {
            width: 3px;
            font-size: x-small;
            height: 25px;
        }
        .style40
        {
            width: 411px;
            font-size: x-small;
            height: 25px;
        }
        .style41
        {
            width: 124px;
            font-size: x-small;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

   

    <table class="style1">
        <tr>
            <td colspan="4" 
               class="Header">
                Add User Profile</td>
        </tr>
        <tr>
            <td class="style16" colspan="4">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                    style="color: #CC3300; font-weight: 700;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style41">
                Select Project</td>
            <td class="style10">
                <asp:Label ID="Lbl_Dept" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style18">
               
                        <asp:DropDownList ID="Drp_Project_Name" runat="server" AutoPostBack="True" 
                            Font-Size="X-Small" 
                            onselectedindexchanged="Drp_Project_Name_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_Proj_Name" runat="server" 
                            ControlToValidate="Drp_Project_Name" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                   
            </td>
            <td>
                    &nbsp;</td>
        </tr>
        <tr>
            <td class="style19">
                Select User Group:</td>
            <td class="style22">
                <asp:Label ID="Lbl_User_Group" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style21">               
                        <asp:DropDownList ID="Drp_User_Group" runat="server" Font-Size="X-Small" 
                           >
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_UG" runat="server" 
                            ControlToValidate="Drp_User_Group" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                   
            </td>
            <td class="style23">
                </td>
        </tr>
       
        <tr>
            <td class="style24">
                Enter User Name:</td>
            <td class="style25">
                <asp:Label ID="Lbl_User_Name" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                    </td>
            <td class="style26">
                <asp:TextBox ID="txt_User_Name" runat="server" Font-Size="X-Small" 
                    Width="207px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Req_User_Name" runat="server" 
                        ControlToValidate="txt_User_Name" ErrorMessage="Required" Font-Size="X-Small" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="style27">
                </td>
        </tr>
        <tr>
            <td class="style37">
                Enter User Display Name</td>
            <td class="style39">
                <asp:Label ID="Lbl_User_Dis_Name" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style40">
                <asp:TextBox ID="txt_User_Dis_Name" runat="server" Font-Size="X-Small" 
                    Width="207px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Req_User_Dis_Name" runat="server" 
                        ControlToValidate="txt_User_Dis_Name" ErrorMessage="Required" Font-Size="X-Small" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="style38">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style37">
                Email ID</td>
            <td class="style39">
                <asp:Label ID="Lbl_Email" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style40">
                <asp:TextBox ID="txt_EmailID" runat="server" Font-Size="X-Small" Width="203px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Req_EmailID" runat="server" 
                        ControlToValidate="txt_EmailID" ErrorMessage="Required" Font-Size="X-Small" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="Reg_Exp_Email_ID" runat="server" 
                    ControlToValidate="txt_EmailID" ErrorMessage="Invalid Email ID" 
                    Font-Size="X-Small" ForeColor="#CC3300" style="font-weight: 700" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
            <td class="style38">
                </td>
        </tr>
       

            <tr>
            <td class="style41"> Select Site ID
                </td>
            <td>
                 <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label></td>
            <td class="style41">Select All
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
               <asp:GridView ID="grdINV" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" ShowFooter="True" Font-Size="X-Small">
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
                                 
            </td>        
        </tr>
        <tr>
            <td class="style41">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style18">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style41">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>

            <td class="style18">
                <asp:Button ID="Btn_Add" runat="server" Font-Size="X-Small" 
                    onclick="Btn_Add_Click" Text="Save" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
