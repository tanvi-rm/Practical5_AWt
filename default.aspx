<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
Inherits="EmployeeWebClient.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title></title>
 <link rel="stylesheet"
href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
</head>
<body>
 <form id="form1" runat="server">
 <div class="container">
 <h2>Employee Management System</h2>
 <div class="panel panel-default">
 <div class="panel-heading">Search Employees</div>
 <div class="panel-body">
     <asp:TextBox ID="txtSearch" runat="server" CssClass="formcontrol"></asp:TextBox>
 <asp:Button ID="btnSearch" runat="server" Text="Search"
 OnClick="btnSearch_Click" CssClass="btn btn-primary" />
 <asp:Button ID="btnShowAll" runat="server" Text="Show All"
 OnClick="btnShowAll_Click" CssClass="btn btn-default" />
 </div>
 </div>
 <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False"
 DataKeyNames="Id" CssClass="table table-striped"
 OnRowEditing="gvEmployees_RowEditing"
 OnRowUpdating="gvEmployees_RowUpdating"
 OnRowCancelingEdit="gvEmployees_RowCancelingEdit"
 OnRowDeleting="gvEmployees_RowDeleting">
 <Columns>
 <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
 <asp:TemplateField HeaderText="Name">
 <ItemTemplate><%# Eval("Name") %></ItemTemplate>
 <EditItemTemplate>
 <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name")
%>'></asp:TextBox>
 </EditItemTemplate>
 </asp:TemplateField>
 <asp:TemplateField HeaderText="Department">
 <ItemTemplate><%# Eval("Department") %></ItemTemplate>
 <EditItemTemplate>
 <asp:TextBox ID="txtDept" runat="server" Text='<%# Bind("Department")
%>'></asp:TextBox>
 </EditItemTemplate>
 </asp:TemplateField>
 <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
 </Columns>
 </asp:GridView>
 <div class="panel panel-default">
 <div class="panel-heading">Add New Employee</div>
 <div class="panel-body">
 <div class="form-group">
 <label>Name:</label>
 <asp:TextBox ID="txtNewName" runat="server" CssClass="formcontrol"></asp:TextBox>
 </div>
 <div class="form-group">
 <label>Department:</label>
 <asp:TextBox ID="txtNewDept" runat="server" CssClass="formcontrol"></asp:TextBox>
 </div>
     <asp:Button ID="btnAdd" runat="server" Text="Add Employee"
 OnClick="btnAdd_Click" CssClass="btn btn-success" />
 </div>
 </div>
 <asp:Label ID="lblMessage" runat="server" CssClass="alert"
Visible="false"></asp:Label>
</div>
 </form>
</body>
</html>
