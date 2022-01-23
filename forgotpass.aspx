<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpass.aspx.cs" Inherits="Task0.forgotpass" %>

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
                        <asp:TextBox ID="forgotUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="forgotUsernameFieldValidator" runat="server" ValidationGroup="forgotDetails" ControlToValidate ="forgotUsername" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="answer" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="answerFieldValidator" runat="server" ValidationGroup="forgotDetails" ControlToValidate = "answer" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="forgotPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="forgotPasswordFieldValidator" runat="server" ValidationGroup="forgotDetails" ControlToValidate ="forgotPassword" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="confirmPasswordFieldValidator" runat="server" ValidationGroup="forgotDetails" ControlToValidate="ConfirmPassword" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                  <tr>
                    <td>
                       
                    </td>
                    
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                 <tr>
                    <td>
                       
                    </td>
                    
                    <td>
                        <asp:label ID="lblIncorrectUsername" runat="server" Text="Incorrect username or answer to security question" forecolor="red"/>
                    </td>
                </tr>
                  <tr>
                    <td>
                       
                    </td>
                    
                    <td>
                        <asp:label ID="lblPasswordNotMatch" runat="server" Text="Please make sure new password and confirm password are the same" forecolor="red"/>
                    </td>
                </tr>
                  <tr>
                      <td>
                          <asp:CompareValidator ID="PasswordSameValidator" runat="server" ControlToCompare = "forgotPassword" ControlToValidate="ConfirmPassword" Operator="Equal" Type="String" ErrorMessage="Please make sure password and confirm passwords are the same" ForeColor="Red"></asp:CompareValidator>
                      </td>
                  </tr>
                 </table>
            
        </div>
    </form>
</body>
</html>
