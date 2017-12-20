<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SqlCommandBuilderDemo.aspx.cs" Inherits="SqlCommandBuilderDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblStudentID" runat="server" Text="Student ID"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlYear" runat="server">
                            <asp:ListItem>Freshman</asp:ListItem>
                            <asp:ListItem>Sophomore</asp:ListItem>
                            <asp:ListItem>Junior</asp:ListItem>
                            <asp:ListItem>Senior</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMarks" runat="server" Text="Total Marks"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtMarks" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /></td>
                    <td colspan ="2"><asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
