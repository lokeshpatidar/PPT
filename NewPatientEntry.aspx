<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPatientEntry.aspx.cs" Inherits="PPT.NewPatientEntry" %>
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
             font-size: 12px;
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
            width: 130px;
            font-size: 12px;
            font-weight:bold;
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





 
    <table class="style5">
        <tr> 
         
            <td class="Header" colspan="5" style="text-align: center; color: #000000">
                New Patient Data Entry</td>
        </tr>
        <tr>
            <td class="style7" colspan="5">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                    style="color: #CC3300; font-weight: 700;"></asp:Label>
            </td>
        </tr>
         <tr>
            <td class="style11">
                Investigator ID</td>
            <td class="style8">
                <asp:Label ID="Label5" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">            
                        <asp:DropDownList ID="drpINVID" Width="70px" Enabled="false" Font-Bold="true" runat="server" Font-Size="X-Small">                     
                        </asp:DropDownList>
                                       
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
          <%--<tr>
            <td class="style11">
                Subject Id</td>
            <td class="style8">
                <asp:Label ID="Label4" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                    </td>
            <td class="style26">          
                        <asp:TextBox ID="txt_SubjectId" Enabled="false" runat="server" Font-Size="X-Small" 
                            Width="207px"></asp:TextBox>                                       
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>--%>
       
       
     
        <tr>
            <td class="style11">
                Date of Consent</td>
            <td class="style8">
                <asp:Label ID="Lbl_User_Name" runat="server"  Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                    </td>
            <td class="style26">
               
                        <asp:TextBox ID="txt_DOC" runat="server" CssClass="txtDate" Font-Size="X-Small" 
                            Width="65px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req_User_Name" runat="server"  ValidationGroup="GenerateSub"
                            ControlToValidate="txt_DOC" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                  
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
            <tr>
            <td class="style11">
                Gender</td>
            <td class="style8">
                <asp:Label ID="Lbl_Site_ID" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">            
                        <asp:DropDownList ID="drp_Gender" runat="server" Width="70px" Font-Size="X-Small">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CompareValidator ID="Comp_Val_Sel_Site_ID" runat="server"  
                            ControlToValidate="drp_Gender" ErrorMessage="Required" Font-Size="X-Small" ValidationGroup="GenerateSub"
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                  
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
               Date Of Birth</td>
            <td class="style28">
                <asp:Label ID="Lbl_User_Dis_Name" runat="server"  Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style29">
               
                        <asp:TextBox ID="txt_DOB" runat="server" CssClass="txtDate" Font-Size="X-Small" 
                            Width="65px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Req_User_Dis_Name" runat="server"  ValidationGroup="GenerateSub"
                            ControlToValidate="txt_DOB" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>
                   
            </td>
            <td class="style30">
                </td>
            <td class="style30">
                </td>
        </tr>
     
       
      <tr>
            <td class="style13">
               
            </td>
            <td class="style12">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
     
        <tr>
            <td class="style11">
                 <asp:Button ID="Btn_Update" Font-Bold="true" runat="server" Font-Size="X-Small" 
                     Text="Save" onclick="Btn_Update_Click"  ValidationGroup="GenerateSub"/>   </td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                   &nbsp;            
            </td>
            <td>
              &nbsp; </td>
            <td>
                &nbsp;</td>
        </tr>
       
    </table>

</asp:Content>
