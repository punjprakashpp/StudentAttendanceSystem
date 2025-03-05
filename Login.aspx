<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <h2>Login</h2>
        <form id="form1" runat="server">
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtEmail" runat="server" ForeColor="Red" ErrorMessage="Email is required!" Display="Dynamic"></asp:RequiredFieldValidator>

            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server" ForeColor="Red" ErrorMessage="Password is required!" Display="Dynamic"></asp:RequiredFieldValidator>

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="Login_Click" />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </form>
    </div>
</asp:Content>
