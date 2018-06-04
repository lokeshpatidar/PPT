<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auth.aspx.cs" Inherits="PPT.Auth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 97%;
            font-family: Arial;
            font-size: x-small;
        }
        .style3
        {
            font-weight: 700;
            text-align: left;
        }
        .style11
        {
            width: 159px;
        }
        .style12
        {
            height: 23px;
            width: 159px;
        }
        .style13
        {
            width: 92px;
            height: 23px;
            font-weight: 700;
        }
        .style21
        {
            text-align: center;
        }
        .style24
        {
            font-weight: 700;
            text-align: left;
            width: 92px;
        }
        .style25
        {
            width: 4px;
        }
        .style26
        {
            height: 23px;
            width: 4px;
        }
        .style29
        {
            text-align: center;
            height: 57px;
        }
        .style30
        {
            height: 57px;
            width: 46px;
        }
        .style31
        {
            text-align: center;
            height: 5px;
        }
        .style32
        {
            height: 5px;
            width: 46px;
        }
        .style33
        {
            width: 345px;
        }
        .style36
        {
            width: 46px;
        }
        .style37
        {
            height: 23px;
            width: 46px;
        }
        .style38
        {
            width: 337px;
            text-align: center;
        }
        .style41
        {
            height: 23px;
        }
        .style43
        {
            width: 350px;
            text-align: center;
        }
        .style44
        {
            width: 25px;
            text-align: center;
        }
        .style45
        {
            width: 420px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style43">
                    &nbsp;</td>
                <td class="style33">
                    &nbsp;</td>
                <td class="style44">
                    &nbsp;</td>
                <td class="style21">
                    &nbsp;</td>
            </tr>
            </table>
    
    </div>
    <div>
    
        <table class="style1">
            <tr>
                <td class="style31" colspan="5">
                    <asp:Literal ID="Rotator" runat="server"></asp:Literal></td>
                <td class="style32">
                    </td>
            </tr>
            <tr>
                <td class="style29" colspan="5">
                <asp:Image ID="logo"  runat="server" ImageUrl="Images/logo.png"/>
                    &nbsp;</td>
                <td class="style30">
                    </td>
            </tr>
            <tr>
                <td class="style38">
                    &nbsp;</td>
                <td class="style3" colspan="3">
                    <asp:Label ID="lblErrorMsg" runat="server" 
                        style="color: #CC3300; font-size: small;" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style38">
                    &nbsp;</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style25">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style45" 
                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                    rowspan="9">
                    &nbsp;</td>
                <td class="style13">
                    Enter User Name:</td>
                <td class="style26">
                <asp:Label ID="Lbl_UName" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
                <td class="style12">
                    <asp:TextBox ID="txt_UserName" runat="server" Font-Size="X-Small" Width="176px"></asp:TextBox>
                </td>
                <td class="style41">
                    <asp:RequiredFieldValidator ID="Req_UName" runat="server" 
                        ControlToValidate="txt_UserName" ErrorMessage="Required" Font-Size="X-Small" 
                        ForeColor="Red" style="font-family: Aharoni"></asp:RequiredFieldValidator>
                </td>
                <td class="style37">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style24">
                    Enter Password:</td>
                <td class="style25">
                <asp:Label ID="Lbl_Pwd" runat="server" Font-Size="Small" ForeColor="#FF3300" 
                    Text="*"></asp:Label>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txt_Pwd" runat="server" Font-Size="X-Small" Width="176px" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="Req_UPwd" runat="server" 
                        ControlToValidate="txt_Pwd" ErrorMessage="Required" Font-Size="X-Small" 
                        ForeColor="Red" style="font-weight: 700"></asp:RequiredFieldValidator>
                </td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style25">
                    &nbsp;</td>
                <td class="style11">
                    <asp:Button ID="Btn_Login" runat="server" Font-Size="X-Small" 
                        onclick="Btn_Login_Click" Text="Login" style="height: 21px" />
                </td>
                <td>
                    &nbsp;</td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
            <tr>
               <%-- <td class="style3" colspan="4">
                    Copyright&nbsp;©&nbsp;2016&nbsp; DiagnoSearch Life Sciences Pvt Ltd.&nbsp;&nbsp;All Rights 
                    Reserved&nbsp;</td>
                <td class="style36">
                    &nbsp;</td>--%>
            </tr>
            <tr>
                <td class="style3" colspan="4">
                    &nbsp;</td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="4">
                    &nbsp;</td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="4">
                    &nbsp;</td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
