<%@ Page Title="Edit Timesheet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTimesheet.aspx.cs" Inherits="PFWorkTimesheet.Timesheet.EditTimesheet" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2><asp:Label ID="TitleLabel" runat="server" Text="No Timesheet Found"></asp:Label></h2>
    </hgroup>

    <article>
        <asp:Table runat="server" ID="TableTimesheetInfo" Visible="false">
            <asp:TableRow>
                <asp:TableCell><b>Submission Status:</b></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label_Status" runat="server" Text=""  /></asp:TableCell><asp:TableCell><b>Week Ending:</b></asp:TableCell><asp:TableCell><asp:Label ID="Label_Week" runat="server" Text="" Enabled="false" /></asp:TableCell></asp:TableRow><asp:TableRow>  
                <asp:TableCell><b>Subcontractor (if app.):</b></asp:TableCell><asp:TableCell><asp:TextBox ID="Textbox_Subcontractor" runat="server" Text="" /></asp:TableCell><asp:TableCell><b>Jobsite:</b></asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="TextBox_Jobsite" runat="server"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender 
                        runat="server" 
                        ServicePath="EditTimesheet.aspx.cs" 
                        ServiceMethod="GetJobsites" 
                        ContextKey="every value" 
                        DelimiterCharacters="" 
                        Enabled="True" 
                        TargetControlID="TextBox_Jobsite" 
                        ID="TextBox_Jobsite_AutoCompleteExtender">
                    </ajaxToolkit:AutoCompleteExtender>
                </asp:TableCell></asp:TableRow></asp:Table><asp:Table runat="server" ID="TableTimesheet" Visible="false">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width ="200px" >Name</asp:TableHeaderCell><asp:TableHeaderCell >C/L</asp:TableHeaderCell><asp:TableHeaderCell >Wed</asp:TableHeaderCell><asp:TableHeaderCell >Thu</asp:TableHeaderCell><asp:TableHeaderCell >Fri</asp:TableHeaderCell><asp:TableHeaderCell >Sat</asp:TableHeaderCell><asp:TableHeaderCell >Sun</asp:TableHeaderCell><asp:TableHeaderCell >Mon</asp:TableHeaderCell><asp:TableHeaderCell >Tue</asp:TableHeaderCell><asp:TableHeaderCell Width ="200px" >Comments</asp:TableHeaderCell></asp:TableHeaderRow></asp:Table><asp:Button runat="server" ID="Button_NewRow" OnClick="Button_NewRow_Click" Text="Add New Entry" Visible="false"/>
        
        <asp:Button runat="server" ID="Button_Save" OnClick="Button_Save_Click" Text="Save Changes" Visible="false"/>
        <asp:Button runat="server" ID="Button_Submit" OnClick="Button_Submit_Click" Text="Submit To HR" Visible="false"/>
        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label></article><aside>
    </aside>
</asp:Content>