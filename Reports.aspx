<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <h2>Attendance Reports</h2>
        <form runat="server">
            <asp:DropDownList ID="ddlStudents" runat="server" CssClass="form-control mb-2"></asp:DropDownList>
            <asp:Button ID="btnGenerateReport" runat="server" CssClass="btn btn-primary" Text="Generate Report" OnClick="GenerateReport_Click" />
        </form>
        <table class="table table-bordered mt-4">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Subject</th>
                    <th>Status</th>
                </tr>
            </thead>
            <asp:Table ID="reportTable" runat="server" CssClass="table"></asp:Table>
        </table>
    </div>
</asp:Content>
