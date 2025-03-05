<%@ Page Title="Admin Panel" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <h2>Admin Panel - Manage Students & Subjects</h2>

        <h4>Add Student</h4>
        <form id="form1" runat="server">
            <asp:TextBox ID="txtName" runat="server" placeholder="Student Name" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtName" runat="server" ForeColor="Red" ErrorMessage="Name is required!" Display="Dynamic"></asp:RequiredFieldValidator>

            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtEmail" runat="server" ForeColor="Red" ErrorMessage="Email is required!" Display="Dynamic"></asp:RequiredFieldValidator>

            <asp:TextBox ID="txtEnrollment" runat="server" placeholder="Enrollment No" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtEnrollment" runat="server" ForeColor="Red" ErrorMessage="Enrollment No is required!" Display="Dynamic"></asp:RequiredFieldValidator>

            <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" CssClass="btn btn-primary" OnClick="AddStudent_Click" />
            <asp:Label ID="lblStudentMsg" runat="server" ForeColor="Green"></asp:Label>

        <h4 class="mt-4">Add Subject</h4>
            <asp:TextBox ID="txtSubject" runat="server" placeholder="Subject Name" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtSubject" runat="server" ForeColor="Red" ErrorMessage="Subject name is required!" Display="Dynamic"></asp:RequiredFieldValidator>

            <asp:Button ID="btnAddSubject" runat="server" Text="Add Subject" CssClass="btn btn-primary" OnClick="AddSubject_Click" />
            <asp:Label ID="lblSubjectMsg" runat="server" ForeColor="Green"></asp:Label>
        </form>
    </div>
</asp:Content>
