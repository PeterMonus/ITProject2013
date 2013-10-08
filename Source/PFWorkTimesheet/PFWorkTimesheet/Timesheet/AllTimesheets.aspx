<%@ Page Title="All Timesheets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllTimesheets.aspx.cs" Inherits="PFWorkTimesheet.Timesheet.AllTimesheets" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <article>
        <asp:Table runat="server" ID="TableTimesheets" Width="100%">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell >Timesheet ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Foreman ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Week Ending</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Date Submitted</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
    </article>

    <aside>
    </aside>
</asp:Content>
