<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmINVDETAILS.aspx.cs" Inherits="PPT.frmINVDETAILS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style2
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:Label ID="lblErrorMsg" runat="server" Font-Size="X-Small" style="color: #FF0000; font-weight: 700; font-family: Arial; font-size: small;"></asp:Label>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>



    <table class="style1">
        <tr>
            <td class="Header" >
                &nbsp;Investigator Details</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
</table>



    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    <asp:GridView ID="INVDETAILS" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" font-family="Arial" Font-Size="X-Small" 
            style="text-align: center" Width="228px" 
            onrowdatabound="INVDETAILS_RowDataBound" BackColor="#DEBA84" 
            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
        <Columns>
            <asp:TemplateField HeaderText="Study ID" HeaderStyle-CssClass="disp-none" ItemStyle-CssClass="disp-none">
                <ItemTemplate>
                    <asp:TextBox ID="STUDYID" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("STUDYID") %>' Width="100px" />
                </ItemTemplate>
                <HeaderStyle CssClass="disp-none" />
                <ItemStyle CssClass="disp-none" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="INVESTIGATOR ID">
                <ItemTemplate>
                    <asp:TextBox ID="INVID" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("INVID") %>' Width="80px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="INVESTIGATOR NAME">
                <ItemTemplate>
                    <asp:TextBox ID="INVNAME" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("INVNAME") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ADDRESS">
                <ItemTemplate>
                    <asp:TextBox ID="ADDRESS" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("ADDRESS") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderText="TEL NO">
                <ItemTemplate>
                    <asp:TextBox ID="TELNO" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("TELNO") %>' Width="80px" />
                </ItemTemplate>
            </asp:TemplateField>


                  <asp:TemplateField HeaderText="FAX NO">
                <ItemTemplate>
                    <asp:TextBox ID="FAXNO" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("FAXNO") %>' Width="60px" />
                </ItemTemplate>
            </asp:TemplateField>


                <asp:TemplateField HeaderText="EMAIL ID">
                <ItemTemplate>
                    <asp:TextBox ID="EMAILID" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("EMAILID") %>' Width="150px" />
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="CC EMAIL ID">
                <ItemTemplate>
                    <asp:TextBox ID="CCEMAILID" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("CCEMAILID") %>' Width="400px" />
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="STATUS" visible = "false">
                <ItemTemplate>
                    <asp:TextBox ID="STATUS" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("STATUS") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="DEACTIVATEDON" visible = "false">
                <ItemTemplate>
                    <asp:TextBox ID="DEACTIVATEDON" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("DEACTIVATEDON") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="UPDATE_FLAG"  HeaderStyle-CssClass="disp-none" ItemStyle-CssClass="disp-none">
                <ItemTemplate>
                    <asp:TextBox ID="UPDATE_FLAG" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("UPDATE_FLAG") %>' Width="100px" />
                </ItemTemplate>
                <HeaderStyle CssClass="disp-none" />
                <ItemStyle CssClass="disp-none" />
            </asp:TemplateField>
            
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Button ID="bntAdd" runat="server" onclick="bntAdd_Click" 
                        style="font-family: Arial; font-size: x-small" Text="Add" />
                </HeaderTemplate>
            </asp:TemplateField>
            
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
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
    
     
     <asp:Button ID="bntSave" runat="server" Text="Save" font-family="Arial"           Font-Size="X-Small"  onclick="bntSave_Click" />

</asp:Content>
