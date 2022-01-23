<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Task0.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUserDetails" runat="server" Text="Label"></asp:Label>
            </br>
            <asp:Button ID="btnViewProfile" runat="server" Text="View Profile" OnClick="btnViewProfile_Click" />
            </br>
            <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
