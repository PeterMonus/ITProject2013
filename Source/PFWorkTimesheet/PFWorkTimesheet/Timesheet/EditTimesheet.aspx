<%@ Page Title="Edit Timesheet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTimesheet.aspx.cs" Inherits="PFWorkTimesheet.Timesheet.EditTimesheet" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Week ending 01/10/2013</h2>
    </hgroup>

    <article>
        <p>        
            Use this area to provide additional information.
        </p>

        <p>
            <asp:Table runat="server" ID="TableTimesheet">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell >Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell >C/L</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Wed</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Thu</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Fri</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Sat</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Sun</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Mon</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Tue</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Comments</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </p>
        <asp:Button runat="server" ID="Button_NewRow" OnClick="Button_NewRow_Click" Text="Add New Entry" />
    </article>

    <aside>
    </aside>
</asp:Content>