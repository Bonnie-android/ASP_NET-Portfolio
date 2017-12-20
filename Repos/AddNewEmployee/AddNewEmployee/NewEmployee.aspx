<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewEmployee.aspx.cs" Inherits="NewEmployee" %>

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
                    <td><asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
                    <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlTitle" runat="server">
                            <asp:ListItem>Programmer I</asp:ListItem>
                            <asp:ListItem>Programmer II</asp:ListItem>
                            <asp:ListItem>Manager</asp:ListItem>
                            <asp:ListItem>Project Manager</asp:ListItem>
                            <asp:ListItem>Director</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblSalary" runat="server" Text="Salary"></asp:Label></td>
                    <td><asp:TextBox ID="txtSalary" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
                    
                </tr>
                <tr>
                    <td colspan ="2"><asp:Label ID="lblMessage" runat="server" ></asp:Label></td>
                </tr>              
            </table>
        </div>
    </form>
</body>
</html>
