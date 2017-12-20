<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Next_Reslt_Demo.aspx.cs" Inherits="Next_Reslt_Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridProducts" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:GridView ID="gridCategories" runat="server">
            </asp:GridView>
            <br />
            <asp:GridView ID="gridEmployees" runat="server">
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
