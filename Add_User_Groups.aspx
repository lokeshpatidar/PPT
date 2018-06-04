<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_User_Groups.aspx.cs" Inherits="PPT.Add_User_Groups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
    {
        width: 100%;
    }
    .style2
    {
        text-align: center;
            font-weight: 700;
            height: 21px;
        }
    .style4
    {
            width: 137px;
        }
    .style5
    {
        color: #000000;
        background-color: #6699FF;
    }
        .style6
        {
            text-align: left;
            width: 132px;
            font-size: x-small;
        }
        .style7
        {
            text-align: left;
            width: 5px;
            font-size: x-small;
        }
        .style8
        {
            text-align: left;
            font-size: x-small;
            height: 8px;
        }
        .style9
        {
            text-align: left;
            width: 5px;
            font-size: x-small;
            height: 8px;
        }
        .style10
        {
            width: 75px;
            height: 8px;
        }
        .style11
        {
            width: 137px;
            height: 8px;
        }
        .style12
        {
            height: 8px;
        }
        .style15
        {
            width: 75px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="style1">
    <tr>
        <td class="Header" colspan="5">
            Add User Groups</td>
    </tr>
    <tr>
        <td class="style8" colspan="5">
            <asp:Label ID="lblErrorMsg" runat="server" 
                style="color: #FF0000; font-weight: 700;"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style8">
            Select Project:</td>
        <td class="style9">
                <asp:Label ID="Lbl_Project_Name" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
        <td class="style10">
            <asp:UpdatePanel ID="Upd_Pan_Sel_Country" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="Drp_Project_Name" 
    runat="server" Height="16px" 
                Width="212px" Font-Size="X-Small">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="style11">
                            <asp:CompareValidator ID="Comp_Val_Sel_Project" runat="server" 
                                ControlToValidate="Drp_Project_Name" ErrorMessage="Required" Font-Size="X-Small" 
                                ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
        <td class="style12">
            </td>
    </tr>
    <tr>
        <td class="style6">
            Enter User Group Name:</td>
        <td class="style7">
                <asp:Label ID="Lbl_Dept1" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                    </td>
        <td class="style15">
            <asp:TextBox ID="txt_User_Group" runat="server" Width="259px" 
                Font-Size="X-Small"></asp:TextBox>
        </td>
        <td class="style4">
                    <asp:RequiredFieldValidator ID="Req_Dep_Prefix" runat="server" 
                        ControlToValidate="txt_User_Group" ErrorMessage="Required" Font-Size="X-Small" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
        <td>
            </td>
    </tr>
    <tr>
        <td class="style6">
            </td>
        <td class="style7">
            </td>
        <td class="style15">
            <asp:Button ID="Add_User_Group" runat="server" onclick="Add_User_Group_Click" 
                Text="Add" Width="50px" Font-Size="X-Small" />
        </td>
        <td class="style4">
            </td>
        <td>
            </td>
    </tr>
    <tr>
        <td class="style2" colspan="5">
            &nbsp;</td>
    </tr>
</table>

<table>
 
</table>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    </asp:UpdatePanel>


</asp:Content>
