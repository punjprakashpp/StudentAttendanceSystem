<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Teacher.aspx.cs" Inherits="Teacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <h2>Mark Attendance</h2>
        <form runat="server">
            <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control mb-2"></asp:DropDownList>
            <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control mb-2"></asp:DropDownList>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control mb-2">
                <asp:ListItem Text="Present" Value="Present"></asp:ListItem>
                <asp:ListItem Text="Absent" Value="Absent"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnMarkAttendance" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="MarkAttendance_Click" />
        </form>
    </div>
</asp:Content>
