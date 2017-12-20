<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Disconnected_Data_Model_Demo.aspx.cs" Inherits="Disconnected_Data_Model_Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGetDataDB" runat="server" Text="Get Data From DB" OnClick="btnGetDataDB_Click" />
            <br />
            <asp:GridView ID="gridStudents" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="StudentID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnPageIndexChanged="gridStudents_PageIndexChanged" OnPageIndexChanging="gridStudents_PageIndexChanging" OnRowCancelingEdit="gridStudents_RowCancelingEdit" OnRowCommand="gridStudents_RowCommand" OnRowDeleted="gridStudents_RowDeleted" OnRowDeleting="gridStudents_RowDeleting" OnRowEditing="gridStudents_RowEditing" OnRowUpdated="gridStudents_RowUpdated" OnRowUpdating="gridStudents_RowUpdating" OnSelectedIndexChanged="gridStudents_SelectedIndexChanged" OnSorting="gridStudents_Sorting" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="StudentID" HeaderText="Student ID" InsertVisible="False" ReadOnly="True" SortExpression="StudentID" />
                    <asp:BoundField DataField="StudentName" HeaderText="Student Name" SortExpression="StudentName" />
                    <asp:BoundField DataField="StudentGrade" HeaderText="Grade Level" SortExpression="StudentGrade" />
                    <asp:BoundField DataField="StudentTotalMarks" HeaderText="Total Marks" SortExpression="StudentTotalMark" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Record(s)" OnClick="btnUpdate_Click" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
