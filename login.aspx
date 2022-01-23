<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Task0.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin:auto;border:3px solid">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ValidationGroup="login" ControlToValidate="txtUsername" ErrorMessage="Cannot leave username field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="login" ErrorMessage="Cannot leave password field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>
                       
                    </td>
                    
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="login" OnClick="btnLogin_Click" />
                    </td>
                </tr>
                 <tr>
                    <td>
                       
                    </td>
                    
                    <td>
                        <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot Password?" OnClick="btnForgotPassword_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                       
                    </td>
                    
                    <td>
                        <asp:label ID="lblErrorMessage" runat="server" Text="Incorrect user/password" forecolor="red"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
