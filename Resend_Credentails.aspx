<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resend_Credentails.aspx.cs" Inherits="PPT.Resend_Credentails" %>
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
                Reset/Resend Credentials</td>
        </tr>
        <tr>
            <td class="style15" colspan="5">
             <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                    <asp:Label ID="lblErrorMsg2" runat="server" 
                        style="color: #CC3300; font-weight: 700;"></asp:Label>
                        </ContentTemplate>
                        </asp:UpdatePanel>
            </td>
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
                           text="Get Data"  Visible="false"/>
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
                        <asp:DropDownList ID="Drp_User" runat="server" Font-Size="X-Small"  AutoPostBack="true"
                            onselectedindexchanged="Drp_User_SelectedIndexChanged" style="height: 19px">
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
                User Email ID:</td>
            <td class="style14">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style5">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                       <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" Font-Size="X-Small" Width="200px" ></asp:TextBox>
                     
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
        <tr>
            <td class="style12"> <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
               <asp:Button ID="btnResendC" runat="server" Text="Resend Credential"  Font-Size="X-Small" 
                            Visible="false" onclick="btnResendC_Click"   />
               </ContentTemplate>
               </asp:UpdatePanel> </td>
            <td class="style14">
                       
                </td>
            <td class="style5" align="center"> <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                  <asp:Button ID="btnResetPass" runat="server" Text="Forgot Password"  
                            Font-Size="X-Small"  Visible="false" onclick="btnResetPass_Click" />  
                  </ContentTemplate>
                  </asp:UpdatePanel>
                  
                                               
            </td>
            <td class="style11">
             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <asp:Button ID="btnUnLock" runat="server" Font-Size="X-Small"  
                             width="100px" onclick="btnUnLock_Click"  Visible="false" /> 
                </ContentTemplate></asp:UpdatePanel>   
                    </td>
            <td>
                &nbsp;</td>
        </tr>
        

        <tr>

            <td colspan="2"> <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate><asp:Label  runat="server" ID="lblLock" Visible="false"  Font-Size="X-Small"  ForeColor="Red" ></asp:Label>
                    </ContentTemplate></asp:UpdatePanel></td>
             <td class="style11">
                </td>
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
        
        
     
         
        </table>
&nbsp;&nbsp;&nbsp; 
</asp:Content>