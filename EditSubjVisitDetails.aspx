<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSubjVisitDetails.aspx.cs" Inherits="PPT.EditSubjVisitDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style>
 .style11
        {
            width: 120px;
            font-size: 12px;
            font-weight:bold;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <table class="table">
        <tr>       
            <td class="Header" colspan="5">
                Edit Patient Details</td>
        </tr>
        <tr>
            <td class="lblError" colspan="5">
                    <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td class="style11">
                Investigator ID</td>
            <td class="requiredSign">
                <asp:Label ID="Label5" runat="server"
                    Text="*"></asp:Label>
                </td>
            <td class="control">       
               <asp:UpdatePanel ID="Upd_Pan_Sel_INV" runat="server">
                    <ContentTemplate>     
                        <asp:DropDownList ID="drpINVID" Width="100px" AutoPostBack="true" 
                            CssClass="f_weight_bold font_Size_Small" runat="server" 
                            onselectedindexchanged="drpINVID_SelectedIndexChanged" >                     
                        </asp:DropDownList>     
                         <asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToValidate="drpINVID" ErrorMessage="Required" Font-Size="X-Small" 
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
                    Patient ID</td>
                <td class="requiredSign">
                <asp:Label ID="Label1" runat="server"
                    Text="*"></asp:Label>
                </td>
                <td class="control">
                   <asp:UpdatePanel ID="Upd_Pan_Sel_Subject" runat="server">
                    <ContentTemplate>
                    <asp:DropDownList ID="drpSubject" runat="server"  CssClass="f_weight_bold font_Size_Small"                   
                        Width="100px">
                    </asp:DropDownList>
                     <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="drpSubject" ErrorMessage="Required" Font-Size="X-Small" 
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
            <td class="style13">
               
            </td>
            <td class="style12">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
     
        <tr>
            <td class="style11">
                 <asp:Button ID="Btn_GetData" Font-Bold="true" runat="server" Font-Size="X-Small" 
                     Text="Get Data" 
                     onclick="Btn_GetData_Click"/>   </td>         
                     <td>
                      &nbsp;
                     </td>    
                     <td>
                      &nbsp;
                     </td>
                     <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td>
           &nbsp;
        </td>
        <td>
       &nbsp;
        </td>
        <td>  
       
        </td>
        </tr>
       
      
        

    </table>
     <asp:Label ID="lblDemograph" runat="server" Text="DEMOGRAPHICS"  Visible="false"  ForeColor="White" Font-Size="x-small"
              Font-Names="Arial" CssClass="border3pxsolidblack bkcolor-black margin-left10"></asp:Label>   
        <asp:GridView ID="grdDemographData" CssClass="margin10px"  runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="8"  ForeColor="Black" 
            GridLines="None" Font-Size="12px" 
        onrowdatabound="grdDemographData_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Patient ID">
                    <ItemTemplate>
                          <asp:TextBox ID="txt_SubjectID" runat="server"  
                            Text='<%# Bind("SUBJID") %>'  Font-Bold="True"  Enabled="false"
                            Font-Overline="False" Font-Size="X-Small" Height="16px" Width="100px"></asp:TextBox>                                 
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Consent Date">
                    <ItemTemplate>
                          <asp:TextBox ID="txt_ConsentDate" runat="server" ToolTip="CONSENT_DATE"
                            Text='<%# Bind("CONSENT_DATE") %>'  Font-Bold="True"  CssClass="txtDate"  onfocus="myFocus(this)" onchange="myFunction(this)"
                            Font-Overline="False" Font-Size="X-Small" Height="16px" Width="100px"></asp:TextBox>                                 
                    </ItemTemplate>
                </asp:TemplateField>      
               <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>

                      <asp:DropDownList ID="DRP_Gender" runat="server"  ToolTip="GENDER"
                                    onfocus="myFocus(this)" onchange="myFunction(this)" Visible="false"  Font-Size="X-Small"
                                    font-family="Arial" Width="80px">                                  
                                     <asp:ListItem Text="Male" Value ="Male"></asp:ListItem>     
                                      <asp:ListItem Text="Female" Value ="Female"></asp:ListItem>                                    
                                </asp:DropDownList>                                        
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Date Of Birth">
                    <ItemTemplate>
                          <asp:TextBox ID="txt_DOB" runat="server" ToolTip="DOB"
                            Text='<%# Bind("DOB") %>'  Font-Bold="True" CssClass="txtDate"  onfocus="myFocus(this)" onchange="myFunction(this)"
                            Font-Overline="False" Font-Size="X-Small" Height="16px" Width="100px"></asp:TextBox>                                 
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

          <asp:Label ID="lblVisitData" runat="server" Text="DATE OF VISIT"  Visible="false"  ForeColor="White" Font-Size="x-small"
              Font-Names="Arial" CssClass="border3pxsolidblack bkcolor-black margin-left10"></asp:Label>   


        <asp:GridView ID="grdVisitData" CssClass="margin10px"  runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="8"  ForeColor="Black" 
            GridLines="None" Font-Size="12px" onrowdatabound="grdVisitData_RowDataBound" 
      >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Patient ID">
                    <ItemTemplate>
                          <asp:TextBox ID="txt_SubjectID" runat="server" 
                            Text='<%# Bind("SUBJID") %>'  Font-Bold="True" Enabled="false" 
                            Font-Overline="False" Font-Size="X-Small" Height="16px" Width="100px"></asp:TextBox>                                 
                    </ItemTemplate>
                </asp:TemplateField>
               
                  <asp:TemplateField HeaderText="Visit">
                    <ItemTemplate>
                          <asp:TextBox ID="txt_Visit" runat="server" 
                            Text='<%# Bind("VISIT") %>'  Font-Bold="True" Enabled="false"  
                            Font-Overline="False" Font-Size="X-Small" Height="16px" Width="100px"></asp:TextBox>                                 
                    </ItemTemplate>
                </asp:TemplateField>

                
                  <asp:TemplateField HeaderText="Visit NUM" ItemStyle-CssClass="disp-none" HeaderStyle-CssClass="disp-none">
                    <ItemTemplate>
                          <asp:TextBox ID="txt_VisitNUm" runat="server" 
                            Text='<%# Bind("VISITNUM") %>'  Font-Bold="True" Enabled="false"  
                            Font-Overline="False" Font-Size="X-Small" Height="16px" Width="100px"></asp:TextBox>                                 
                    </ItemTemplate>
                </asp:TemplateField>
                
                   <asp:TemplateField HeaderText="Visit Date">
                    <ItemTemplate>
                          <asp:TextBox ID="txt_VisitDate" runat="server" ToolTip="Visit Date"
                            Text='<%# Bind("ACTUAL_DATE") %>'  Font-Bold="True" CssClass="txtDate" onfocus="myFocus(this)" onchange="myFunctionVisit(this)"
                            Font-Overline="False" Font-Size="X-Small" Height="16px" Width="100px"></asp:TextBox>                                 
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
     
             
       
</asp:Content>
