<%@ Page Title="My Timesheets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyTimesheets.aspx.cs" Inherits="PFWorkTimesheet.Timesheet.MyTimesheets" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <article>
        <asp:Button runat="server" Text="New Timesheet" ID="Button_NewTimesheet" OnClick="Button_NewTimesheet_Click" />
        <asp:DropDownList runat="server" ID="DDL_WeekEnding" />

        <asp:Table runat="server" ID="TableTimesheets" Width="100%">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell >Timesheet ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Jobsite</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Week Ending</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Date Submitted</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
    </article>

    <aside>
    </aside>
</asp:Content>
