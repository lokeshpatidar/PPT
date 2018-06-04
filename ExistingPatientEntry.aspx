<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExistingPatientEntry.aspx.cs" Inherits="PPT.ExistingPatientEntry" %>
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
            font-size: small;
        }
        .style11
        {
            width: 200px;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

 <%-- <asp:UpdatePanel ID="Upd_Pan_Sel_Dept" runat="server">
                    <ContentTemplate>--%>
    <table class="style5">
        <tr> 
         
            <td class="Header" colspan="5" style="text-align: center; color: #000000">
                Existing Patient Data Entry</td>
        </tr>
        <tr>
            <td class="style7" colspan="5">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                    style="color: #CC3300; font-weight: 700;"></asp:Label>
            </td>
        </tr>
         <tr>
            <td class="style11">
               Investigator ID </td>
            <td class="style8">
                <asp:Label ID="Label5" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">            
                        <asp:DropDownList ID="drpINVID" runat="server" Enabled="false" Font-Bold="true" Width="90px" Font-Size="X-Small">                     
                        </asp:DropDownList>
                                       
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
          <tr>
            <td class="style11">
                Patient ID</td>
            <td class="style8">
                <asp:Label ID="Label4" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                    </td>
            <td class="style26">                                     
                        <asp:DropDownList ID="drpSubject" runat="server" AutoPostBack="true" Width="90px" Font-Size="X-Small" 
                            onselectedindexchanged="drpSubject_SelectedIndexChanged">                    
                        </asp:DropDownList>                              
                  
            </td>                               
           
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
             <div runat="server" id="divVisitNo" visible="false">
        <tr>
            <td class="style11">
                Visit</td>
            <td class="style8">
                <asp:Label ID="Label10" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                    </td>
            <td class="style26">        
                          <asp:TextBox ID="txtVisit" runat="server"   Enabled="false" Font-Bold="true" Font-Size="X-Small" 
                            Width="90px"></asp:TextBox>                             
                         <asp:TextBox ID="txtVisitNo" runat="server"  Visible="false" Enabled="false" Font-Size="X-Small" 
                            Width="80px"></asp:TextBox>
            </td>                               
           
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </div>
    <div runat="server" id="DivScheDate" visible="false">
           <tr>
            <td class="style11">
                Scheduled Date</td>
            <td class="style8">
               <%-- <asp:Label ID="Label6" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>--%>
            <td class="style9">            
                        <asp:TextBox ID="txtScheduleDate" runat="server" Font-Bold="true" Enabled="false"  Font-Size="X-Small" 
                            Width="90px"></asp:TextBox>
                        <%--<asp:CompareValidator ID="CompareValidator2" runat="server" ValidationGroup="SaveVisit1Data"
                            ControlToValidate="drpEligible" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>--%>
                  
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </div>

          <div runat="server" id="divIsArrive" visible="false">
           <tr>
            <td class="style11">
                Did patient arrive for the study</td>
            <td class="style8">
                <asp:Label ID="Label12" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">            
                        <asp:DropDownList ID="drpIsArrive" AutoPostBack="true" runat="server"  Width="70px"
                            Font-Size="X-Small" onselectedindexchanged="drpIsArrive_SelectedIndexChanged" 
                          >
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                        <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ValidationGroup="SaveVisitOther"
                            ControlToValidate="drpIsArrive" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                  
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </div>
       
       
          <div runat="server" id="DivActualDate" visible="false">
          <tr>
            <td class="style11">
               Actual Date</td>
            <td class="style28">
                <asp:Label ID="Label7" runat="server" Font-Size="Small"  ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style29">
               
                        <asp:TextBox ID="txtActualDate" runat="server" CssClass="txtDate" Font-Size="X-Small" 
                            Width="65px"></asp:TextBox>
                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtVisitDate" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                   
            </td>
            <td class="style30">
                </td>
            <td class="style30">
                </td>
        </tr>
        </div>
         <div runat="server" id="divSubjectContinue" visible="false">
           <tr>
            <td class="style11">
                Patient Continue In Study</td>
            <td class="style8">
                <asp:Label ID="Label8" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">            
                        <asp:DropDownList ID="drpSubjectCont" AutoPostBack="true" runat="server"  Width="70px"
                            Font-Size="X-Small" onselectedindexchanged="drpSubjectCont_SelectedIndexChanged">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                        <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                        </asp:DropDownList>
                       <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" ValidationGroup="SaveVisitOther"
                            ControlToValidate="drpEligible" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>          --%>      
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </div>

         <div runat="server" id="DivEtDate" visible="false">
          <tr>
            <td class="style11">
               Early Termination Date</td>
            <td class="style28">
                <asp:Label ID="Label13" runat="server" Font-Size="Small"  ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style29">
               
                        <asp:TextBox ID="txtETDate" runat="server" CssClass="txtDate" Font-Size="X-Small" 
                            Width="65px"></asp:TextBox>
                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtVisitDate" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                   
            </td>
            <td class="style30">
                </td>
            <td class="style30">
                </td>
        </tr>
        </div>
       
         <div runat="server" id="divNotContReason" visible="false">
         <tr>
            <td class="style11">
               Select Reason For Withdrawal</td>
            <td class="style28">
                <asp:Label ID="Label9" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style29">
               

                  <asp:DropDownList ID="drpNotContReason" AutoPostBack="true" runat="server" 
                     Width="120px" Font-Size="X-Small" onselectedindexchanged="drpNotContReason_SelectedIndexChanged"
                            >
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Withdrew Consent" Value="Withdrew Consent"></asp:ListItem>
                        <asp:ListItem Text="Investigator Decision" Value="Investigator Decision"></asp:ListItem>
                         <asp:ListItem Text="Sponsor Decision" Value="Sponsor Decision"></asp:ListItem>
                        <asp:ListItem Text="Lost to Follow Up" Value="Lost to Follow Up"></asp:ListItem>
                         <asp:ListItem Text="Protocol Non-compliance" Value="Protocol Non-compliance"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>


                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtReasonWith" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                   
            </td>
            <td class="style30">
                </td>
            <td class="style30">
                </td>
        </tr>
        </div>
         <div runat="server" id="divOtherWith" visible="false">
         <tr>
            <td class="style11">
               Other Reason For Withdrawal</td>
            <td class="style28">
                <asp:Label ID="Label11" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style29">
                         
                        <asp:TextBox ID="txtNotContReason" runat="server" Font-Size="X-Small" 
                            Width="203px"></asp:TextBox>
                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtReasonWith" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                   
            </td>
            <td class="style30">
                </td>
            <td class="style30">
                </td>
        </tr>
        </div>
          <div runat="server" id="DivEligible" visible="false">
           <tr>
            <td class="style11">
                Patient Eligible</td>
            <td class="style8">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style9">            
                        <asp:DropDownList ID="drpEligible" AutoPostBack="true" runat="server" Width="70px" Font-Size="X-Small" 
                            onselectedindexchanged="drpEligible_SelectedIndexChanged">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                        <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="SaveVisit1Data"
                            ControlToValidate="drpEligible" ErrorMessage="Required" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                  
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </div>
          <div runat="server" id="divReason" visible="false">
         <tr>
            <td class="style11">
               Enter Reason For Not Eligible</td>
            <td class="style28">
                <asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style29">
               
                 <asp:DropDownList ID="drpReasonNotElig" AutoPostBack="true" runat="server" 
                     Width="120px" Font-Size="X-Small" onselectedindexchanged="drpReasonNotElig_SelectedIndexChanged" 
                            >
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Withdrew Consent" Value="Withdrew Consent"></asp:ListItem>
                        <asp:ListItem Text="Investigator Decision" Value="Investigator Decision"></asp:ListItem>
                         <asp:ListItem Text="Sponsor Decision" Value="Sponsor Decision"></asp:ListItem>
                        <asp:ListItem Text="Lost to Follow Up" Value="Lost to Follow Up"></asp:ListItem>
                         <asp:ListItem Text="Protocol Non-compliance" Value="Protocol Non-compliance"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>

                      
                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtReasonWith" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                   
            </td>
            <td class="style30">
                </td>
            <td class="style30">
                </td>
        </tr>
        </div>


          <div runat="server" id="divReasonOther" visible="false">
         <tr>
            <td class="style11">
               Other Reason</td>
            <td class="style28">
                <asp:Label ID="Label6" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style29">                             
                         <asp:TextBox ID="txtReasonNotElig" runat="server" Font-Size="X-Small" 
                            Width="203px"></asp:TextBox>
                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtReasonWith" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                   
            </td>
            <td class="style30">
                </td>
            <td class="style30">
                </td>
        </tr>
        </div>
        <div runat="server" id="Visit1date" visible="false">
          <tr>
            <td class="style11">
               Visit Date</td>
            <td class="style28">
                <asp:Label ID="Label3" runat="server" Font-Size="Small"  ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
            <td class="style29">
               
                        <asp:TextBox ID="txtVisitDate" runat="server" CssClass="txtDate"  Font-Size="X-Small" 
                            Width="65px"></asp:TextBox>
                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtVisitDate" ErrorMessage="Required" 
                            Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                   
            </td>
            <td class="style30">
                </td>
            <td class="style30">
                </td>
        </tr>
        </div>
        <div runat="server" id="divSaveVisit1" visible="false">
           <tr>
            <td class="style11">
                <asp:Button ID="btnSave" runat="server" Font-Size="X-Small" style="margin-top:10px" font-bold="true"  ValidationGroup="SaveVisit1Data"
                     Text="Save" onclick="btnSave_Click" />    </td>
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
        </div>
          <div runat="server" id="divSaveVisitother"  visible="false">
           <tr>
            <td class="style11" >
                <asp:Button ID="btnSaveVisitOther" runat="server" style="margin-top:10px" font-bold="true" Font-Size="X-Small"  ValidationGroup="SaveVisitOther"
                     Text="Save" onclick="btnSaveVisitOther_Click" /></td>
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
        </div>
        
          <tr>

            <td class="style11">
                </td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
              
                   
            </td>
            <td>
              &nbsp; </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    <asp:GridView ID="grdVisitDetail" CssClass="margin-top25"  runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="8"  ForeColor="Black" 
            GridLines="None" Font-Size="12px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Visit">
                    <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("VISIT") %>'></asp:Label>                   
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Schedule Date">
                    <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("FROM_SCH_DT") %>'></asp:Label>                   
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actual Date">
                    <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ACTUAL_DATE") %>'></asp:Label>    
                    </ItemTemplate>
                </asp:TemplateField>             
               
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
     <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>

</asp:Content>
