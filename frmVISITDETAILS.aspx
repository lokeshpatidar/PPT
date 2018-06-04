<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVISITDETAILS.aspx.cs" Inherits="PPT.frmVISITDETAILS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="lblErrorMsg" runat="server" Font-Size="X-Small" style="color: #FF0000; font-weight: 700; font-family: Arial; font-size: small;"></asp:Label>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <table class="style1">
        <tr>
            <td class="Header">
                &nbsp;Visit Details</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    
    <asp:GridView ID="VISITDETAILS" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" font-family="Arial" Font-Size="X-Small" ForeColor="#333333" 
        GridLines="None" style="text-align: center" Width="228px" 
            onrowdatabound="VISITDETAILS_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            
            <asp:TemplateField HeaderText="STUDYID" HeaderStyle-CssClass="disp-none" ItemStyle-CssClass="disp-none">
                <ItemTemplate>
                    <asp:TextBox ID="STUDYID" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("STUDYID") %>' Width="10px" />
                </ItemTemplate>
                <HeaderStyle CssClass="disp-none" />
                <ItemStyle CssClass="disp-none" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Visit No.">
                <ItemTemplate>
                    <asp:TextBox ID="VISITNUM" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("VISITNUM") %>' Width="30px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Visit Code">
                <ItemTemplate>
                    <asp:TextBox ID="VISIT" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("VISIT") %>' Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="UPDATE_FLAG" HeaderStyle-CssClass="disp-none" ItemStyle-CssClass="disp-none">
                <ItemTemplate>
                    <asp:TextBox ID="UPDATE_FLAG" runat="server" font-family="Arial" 
                        Font-Size="X-Small" Text='<%# Bind("UPDATE_FLAG") %>' Width="10px" />
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

