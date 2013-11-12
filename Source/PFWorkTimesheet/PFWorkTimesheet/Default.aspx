<%@ Page Title="Pacific Formwork Timesheeting" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PFWorkTimesheet.EditTimesheet" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2></h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Getting Started:</h3>
    <ol class="round">
        <li class="one">
            <h5>Getting an Account</h5>
            Contact HR at +61 2 6260 2562 or info@pfwork.com.au to get an account
            Log in to your account <a id="A4" runat="server" href="~/Account/Login.aspx">Here</a>
        </li>
        <li class="two">
            <h5>After Logging In</h5>
            <a id="A2" runat="server" href="~/Account/Manage.aspx">Change your password</a>
            <br />
            <a id="A3" runat="server" href="~/Timesheet/MyTimesheets.aspx">Create and edit timesheets</a>
        </li>
        <li class="three">
            <h5>Admin Only</h5>
            <a id="registerLink" runat="server" href="~/Account/Register.aspx">Register User</a> - <a id="A1" runat="server" href="~/Timesheet/AllTimesheets.aspx">All Timesheets</a>
        </li>
    </ol>
</asp:Content>
