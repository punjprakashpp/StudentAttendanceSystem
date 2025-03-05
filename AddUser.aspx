<%@ Page Title="Add New User" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container mt-4">
        <h2>Add New User</h2>
        <form runat="server">
            <div class="mb-3">
                <label class="form-label">Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Required="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Required="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Role</label>
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                    <asp:ListItem Text="Teacher" Value="Teacher"></asp:ListItem>
                    <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnAddUser" runat="server" CssClass="btn btn-primary" Text="Add User" OnClick="btnAddUser_Click" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
        </form>
    </div>
</asp:Content>
