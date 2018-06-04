<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataEntry.aspx.cs" Inherits="PPT.DataEntry" %>
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
            font-size: 12px;
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
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
  
    <table class="style1">
        <tr>
            <td class="Header" colspan="8">
                Data Entry
            </td>
        </tr>
          <tr>
            <td class="style16">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                    style="color: #CC3300; font-weight: 700;"></asp:Label>
            </td>
        </tr>
        <tr>
        <div runat="server" id ="DivINV" >
            <td class="style9">
                Investigator ID
            </td>         
                
             
            <td class="style10">     
            <asp:Label ID="Label3" runat="server" Font-Size="Small"  ForeColor="#FF3300" 
                    Text="*"></asp:Label>         
                        <asp:DropDownList ID="drpInvID" runat="server" 
                            CssClass="style6" Height="16px" Width="70px">
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="drpInvID" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>
                   
            </td>
            <td class="style11">           
            </td>
            </div>
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
             <asp:Button ID="btn_New" runat="server" Font-Size="X-Small" 
                    Text="New Patient" Font-Bold="true" onclick="btn_New_Click" />
         </td>
            <td class="style8">
                
                  <asp:Button ID="btnExist" runat="server" Font-Size="X-Small" 
                     Text="Existing Patient" Font-Bold="true" onclick="btnExist_Click" />

                     </td>
            <td>
               
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

    </table>
      </ContentTemplate>
      </asp:UpdatePanel>
</asp:Content>
