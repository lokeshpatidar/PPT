<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPROJDETAILS.aspx.cs" Inherits="PPT.frmPROJDETAILS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        color: #000000;
        text-align: center;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblErrorMsg" runat="server" Font-Size="X-Small" style="color: #FF0000; font-weight: 700; font-family: Arial; font-size: small;"></asp:Label>


    <table class="style1">
        <tr>
            <td class="Header" >
                Project Details</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
</table>


    <asp:GridView ID="PROJDETAILS" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" font-family="Arial" Font-Size="X-Small" 
        style="text-align: center" Width="228px" 
        onrowdatabound="PROJDETAILS_RowDataBound" BackColor="#DEBA84" 
        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" 
        >
        <Columns>

              <asp:TemplateField HeaderText="Project ID" >
                <ItemTemplate>
                    <asp:TextBox ID="Project_ID" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("Project_ID") %>' CssClass="numeric" Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Study ID" HeaderStyle-CssClass="disp-none" ItemStyle-CssClass="disp-none">
                <ItemTemplate>
                    <asp:TextBox ID="STUDYID" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("STUDYID") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Project Name">
                <ItemTemplate>
                    <asp:TextBox ID="PROJNAME" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("PROJNAME") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>


             <asp:TemplateField HeaderText="Sponsor">
                <ItemTemplate>
                    <asp:TextBox ID="SPONSOR" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("SPONSOR") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>


             <asp:TemplateField HeaderText="Project Start Date">
                <ItemTemplate>
                    <asp:TextBox ID="PROJSTDAT" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("PROJSTDAT") %>' CssClass="txtDate" Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Project Duration">
                <ItemTemplate>
                    <asp:TextBox ID="PROJDUR" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("PROJDUR") %>' Width="100px" />
                </ItemTemplate>
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
    <table class="style1">
        <tr>
            <td>
    <asp:Button ID="bntSave" runat="server" Text="Save" onclick="bntSave_Click" font-family="Arial" 
                        Font-Size="X-Small" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
