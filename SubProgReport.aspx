<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubProgReport.aspx.cs" Inherits="PPT.SubProgReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
        }
        .style6
        {
            width: 153px;
        }
        .style7
        {
            width: 550px;
        }
        .style23
        {
            font-family: Arial;
            font-size: small;
            width: 130px;
        }
        .style24
        {
            width: 130px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="pnlFilter" runat="server" >
        <table class="style1">
           
             <tr> 
         
            <td class="Header" colspan="5" style="text-align: center; color: #000000">
              Patient Progression Report</td>
        </tr>
         <tr>
                <td class="style3" colspan="3">
                 <asp:Label ID="lblErrorMsg" runat="server" 
                    style="color: #CC3300; font-weight: 700;"></asp:Label>
                    &nbsp;</td>
            </tr>
           
            <tr>
                <td class="style23">
                    Investigator ID</td>
                <td class="style7">
                    <asp:DropDownList ID="drpInvID" runat="server" Font-Size="X-Small" Width="90px" 
                        onselectedindexchanged="drpInvID_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                       <asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToValidate="drpInvID" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style23">
                    Patient ID</td>
                <td class="style7">
                    <asp:DropDownList ID="drpSubject" runat="server" 
                        Font-Size="X-Small" 
                        Width="90px">
                    </asp:DropDownList>
                      <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="drpSubject" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style24">
                     <asp:Button ID="bntGetReport" runat="server" onclick="bntGetReport_Click" 
                        style="font-family: Arial; font-size: small" Text="Get Report" 
                        Width="90px" /></td>
                <td class="style7">
                   
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
        </table>

    </asp:Panel>


    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1134px">
        
    </rsweb:ReportViewer>



    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetData" 
        TypeName="PPT.PPTDataSetTableAdapters.SubProgRptTableAdapter">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetData" 
        TypeName="PPT.PPTDataSetTableAdapters.SP_SubProgReportTableAdapter">
    </asp:ObjectDataSource>



    </asp:Content>
