﻿<%@ Page Title="Edit Timesheet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTimesheet.aspx.cs" Inherits="PFWorkTimesheet.Timesheet.EditTimesheet" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2><asp:Label ID="TitleLabel" runat="server" Text="No Timesheet Found"></asp:Label></h2>
    </hgroup>

    <article>
        <p>   
            Sumbission Status: <asp:TextBox ID="Textbox_Status" runat="server" Text="Not Submitted" Enabled="false" />
        </p>
        <p>        
            Week Ending: <asp:TextBox ID="Textbox_Week" runat="server" Text="01/10/2013" Enabled="false" />     
        </p>
            
        <p>
            Sub Contractor: <asp:TextBox ID="Textbox_Subcontractor" runat="server" Text="" />
        </p>
            
        <p>
            <!--
            <asp:SqlDataSource
                id="SqlTimesheetDataSource"
                runat="server"
                DataSourceMode="DataReader"
                ConnectionString="<%$ ConnectionStrings:TimesheetDatabaseConnection%>"
                SelectCommand="GetTimesheetByID" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="TimesheetID" DefaultValue="1" />
                </SelectParameters>
            </asp:SqlDataSource>            

            <asp:GridView ID="TimesheetGridView" runat="server" DataSourceID="SqlTimesheetDataSource"></asp:GridView>
            -->
            
            <asp:Table runat="server" ID="TableTimesheet" Visible="false">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Width ="200px" >Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell >C/L</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Wed</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Thu</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Fri</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Sat</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Sun</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Mon</asp:TableHeaderCell>
                    <asp:TableHeaderCell >Tue</asp:TableHeaderCell>
                    <asp:TableHeaderCell Width ="200px" >Comments</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </p>

        <asp:Button runat="server" ID="Button_NewRow" OnClick="Button_NewRow_Click" Text="Add New Entry" />
        <asp:Button runat="server" ID="Button_Submit" OnClick="Button_Submit_Click" Text="Sumbit To HR" />

    </article>

    <aside>
    </aside>
</asp:Content>