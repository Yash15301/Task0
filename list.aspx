<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="Task0.list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewList" runat="server" BorderWidth="2px" CellPadding="2"  AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging">
                
                <Columns>
                    <asp:BoundField  DataField="Id" HeaderText="ID" />
                    <asp:BoundField  DataField="EmpId" HeaderText="EMP ID" />
                    <asp:BoundField  DataField="Username" HeaderText="USERNAME" />
                    <asp:BoundField  DataField="Password" HeaderText="PASSWORD" />
                    <asp:BoundField  DataField="isActive" HeaderText="IS ACTIVE" />
                    <asp:BoundField  DataField="LastModified" HeaderText="LAST MODIFIED" />
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="AddEdit.aspx?id={0}" Text="Edit" />
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="AddEdit.aspx?DelId={0}" Text="Delete" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="AddRecord" runat="server" Text="Add Record" OnClick="btn_AddRecord" style="margin-left: 250px"/>
        </div>
    </form>
</body>
</html>