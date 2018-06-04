<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="eCRF_Templete.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
     .style1
        {
            width: 100%;
            margin-right: 142px;
        } 
        .style3
        {
            font-family: Arial;
            font-size: small;
            font-weight: bold;
        }
        .style4
        {
            width: 792px;
        }
        .style6
        {
            font-family: Arial;
            font-size: x-small;
        }
        .style7
        {
            width: 91px;
            font-family: Arial;
            font-size: x-small;
            font-weight: bold;
        }
        .style9
        {
            width: 91px;
            font-family: Arial;
            font-size: x-small;
            font-weight: bold;
            height: 24px;
        }
        .style10
        {
            width: 161px;
            height: 24px;
        }
        .style11
        {
            height: 24px;
        }
        .style12
        {
            width: 161px;
        }
        .style13
        {
            width: 91px;
        }
         .style28
        {
            width: 1px;
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table class="style1">          
          <tr>
            <td class="style11">
           <asp:Button ID="cmdSendEmail" runat="server"  Visible="false"
        Text="Send Email" onclick="cmdSendEmail_Click" style="font-size: x-small" />
         </td>
            <td class="style8">
              
                     </td>
            <td>
               
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

    </table>
 
</asp:Content>
