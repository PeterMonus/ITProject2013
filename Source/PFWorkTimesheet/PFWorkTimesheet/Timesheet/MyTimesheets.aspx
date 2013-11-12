<%@ Page Title="My Timesheets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyTimesheets.aspx.cs" Inherits="PFWorkTimesheet.Timesheet.MyTimesheets" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <article>
        <asp:Table runat="server" ID="Table1" Width="400px">
            <asp:TableRow>
                <asp:TableCell>
                    <b><u>Create New Timesheet</u></b>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Date Week Ending:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="Textbox_DateWeekEnding" MaxLength="10" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender TargetControlID="Textbox_DateWeekEnding" ID="Calender_DateWeekEnding" Format="dd/MM/yyyy" runat="server"></ajaxToolkit:CalendarExtender>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button runat="server" Text="New Timesheet" ID="Button_NewTimesheet" OnClick="Button_NewTimesheet_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="Label_Error"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        

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
