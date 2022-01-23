<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEdit.aspx.cs" Inherits="Task0.AddEdit" %>

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
                        <asp:Label ID="AddEditEmpId" runat="server" Text="Employee ID"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="AEEmpId" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="lblAEEID" runat="server" ControlToValidate ="AEEmpId" ValidationGroup="ADDEDIT" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="AddEditUsername" runat="server" Text="Username"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="AEUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="lblAEUsername" runat="server" ControlToValidate ="AEUsername" ValidationGroup="ADDEDIT" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="AddEditLocation" runat="server" Text="Location"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="AELocation" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="lblAEL" runat="server" ControlToValidate ="AELocation" ValidationGroup="ADDEDIT" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="AddEditPassword" runat="server" Text="Password"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="AEPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="lblAEPassword" runat="server" ControlToValidate ="AEPassword" ValidationGroup="ADDEDIT" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="AddEditConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="AECPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="lblAECPassword" runat="server" ControlToValidate ="AECPassword" ValidationGroup="ADDEDIT" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="AddEditIsActive" runat="server" Text="IsActive"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="AEIsActive" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="lblIsActive" runat="server"  ControlToValidate ="AEIsActive" ValidationGroup="ADDEDIT" ErrorMessage="Cannot leave this field empty" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>
                        
                    </td>
                    
                    <td>
                        <asp:Button ID="AddEditSubmit" runat="server" Text="Submit" OnClick="AddEditSubmit_Click"  ValidationGroup="ADDEDIT"/>
                    </td>
                </tr>
                 <tr>
                     <td>
                         <asp:Label ID="passwordMatch" runat="server" Text="Please make sure passwords match" ForeColor="Red"></asp:Label>
                     </td>
                 </tr>
                  <tr>
                      <td>
                          <asp:CompareValidator ID="PasswordSameValidator" runat="server" ControlToCompare = "AEPassword" ControlToValidate="AECPassword" Operator="Equal" Type="String" ErrorMessage="Please make sure password and confirm passwords are the same" ForeColor="Red"></asp:CompareValidator>
                      </td>
                  </tr>
               </table>
        </div>
    </form>
</body>
</html>
