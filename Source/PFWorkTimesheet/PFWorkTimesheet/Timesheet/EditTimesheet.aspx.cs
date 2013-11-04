﻿/* 
 * FileName:    EditTimesheet.aspx.cs
 * Author:      Peter Monus
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimesheetBusiness;

namespace PFWorkTimesheet.Timesheet
{
    public partial class EditTimesheet : System.Web.UI.Page
    {
        TimesheetBusinessLogic TBL = new TimesheetBusinessLogic();
        TimesheetObject Timesheet = new TimesheetObject();

        protected void Page_Load(object sender, EventArgs e)
        {            
            int isNumber;

            //If query string (?ID=1234 at end of URL) is empty or not a number then return "No Timesheet Found"
            if (string.IsNullOrEmpty(Request.QueryString["ID"]) || !int.TryParse(Request.QueryString["ID"], out isNumber))
            {
                TitleLabel.Text = "No Timesheet Found";
            }
            else
            {
                Timesheet = TBL.GetTimesheetByID(Request.QueryString["ID"]);

                //If query was a number but no timesheet was returned then "No Timesheet Found"
                if (string.IsNullOrEmpty(Timesheet.timesheetID))
                {
                    TitleLabel.Text = "No Timesheet Found";
                }
                //Timesheet was found and info was returned
                else
                {

                    if (!IsPostBack)
                    {
                        //Displays all the UI controls
                        TableTimesheetInfo.Visible = true;
                        TableTimesheet.Visible = true;

                        TableTimesheet.Visible = true;
                        Button_Submit.Visible = true;
                        Button_NewRow.Visible = true;
                        Button_Save.Visible = true;

                        //Fills textboxes with information
                        if (Timesheet.submitted == string.Empty)
                            Textbox_Status.Text = "Not Submitted";
                        else
                            Textbox_Status.Text = Timesheet.submitted;

                        Textbox_Status.Text = Timesheet.submitted;
                        Textbox_Week.Text = Timesheet.weekEnding.Split(' ')[0];
                        Textbox_Subcontractor.Text = Timesheet.subcontractor;
                        TextBox_Jobsite.Text = Timesheet.jobsite;

                        TitleLabel.Text = "Ending Tuesday, " + Timesheet.weekEnding.Split(' ')[0];
                    }

                    //Add row for each timesheet entry
                    foreach (TimesheetEntry TE in Timesheet.Entries)
                    {
                        TableTimesheet.Rows.Add(MakeTableRow(TE));
                    }
                }
                
            }
        }

        protected void Button_NewRow_Click(object sender, EventArgs e)
        {
            //Add new timesheet entry
            TBL.AddTimesheetEntry(Request.QueryString["ID"]);
            //Save any changes and refresh page
            SaveAllChanges();
            Response.Redirect(Request.RawUrl);
        }

        protected void SaveAllChanges()
        {
            //Updates the timesheet object with any changes
            Timesheet.signature = Textbox_Subcontractor.Text;
            Timesheet.jobsite = TextBox_Jobsite.Text;
            Timesheet.subcontractor = Textbox_Subcontractor.Text;

            //Cycles through each row of the table
            for (int i = 1; i < TableTimesheet.Rows.Count; i++)
            {
                TextBox tb = (TextBox)TableTimesheet.Rows[i].Cells[0].Controls[0];
                Timesheet.Entries[i - 1].employeeName = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[1].Controls[0];
                Timesheet.Entries[i - 1].employeeType = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[2].Controls[0];
                Timesheet.Entries[i - 1].hoursWednesday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[3].Controls[0];
                Timesheet.Entries[i - 1].hoursThursday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[4].Controls[0];
                Timesheet.Entries[i - 1].hoursFirday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[5].Controls[0];
                Timesheet.Entries[i - 1].hoursSaturday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[6].Controls[0];
                Timesheet.Entries[i - 1].hoursSunday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[7].Controls[0];
                Timesheet.Entries[i - 1].hoursMonday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[8].Controls[0];
                Timesheet.Entries[i - 1].hoursTuesday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[9].Controls[0];
                Timesheet.Entries[i - 1].comments = tb.Text;
            }

            TBL.UpdateTimesheet(Timesheet);
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            SaveAllChanges();
            Response.Redirect(Request.RawUrl);
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            Timesheet.submitted = DateTime.Now.ToString();
            SaveAllChanges();
            TBL.SubmitTimesheet(Timesheet);            
            Response.Redirect(Request.RawUrl);
        }

        public TableRow MakeTableRow(TimesheetEntry Entry)
        {
            TableRow Row = new TableRow();

            //The delete button has its own row with a button
            TableCell DeleteCell = new TableCell();
            Button DeleteButton = new Button();
            DeleteButton.Text = "X";
            DeleteButton.ToolTip = "Delete This Row";
            DeleteButton.Command += DeleteRow;
            DeleteButton.CommandName = "DeleteRow";
            DeleteButton.CommandArgument = Entry.entryID; //This tells the deleterow function which entry to delete
            DeleteCell.Controls.Add(DeleteButton);
            
            //Makes the row
            //Each column in the row has a textbox with the relevant data
            Row.Cells.Add(MakeTableCell(Entry.employeeName));
            Row.Cells.Add(MakeTableCell(Entry.employeeType));
            Row.Cells.Add(MakeTableCell(Entry.hoursWednesday));
            Row.Cells.Add(MakeTableCell(Entry.hoursThursday));
            Row.Cells.Add(MakeTableCell(Entry.hoursFirday));
            Row.Cells.Add(MakeTableCell(Entry.hoursSaturday));
            Row.Cells.Add(MakeTableCell(Entry.hoursSunday));
            Row.Cells.Add(MakeTableCell(Entry.hoursMonday));
            Row.Cells.Add(MakeTableCell(Entry.hoursTuesday));
            Row.Cells.Add(MakeTableCell(Entry.comments));
            Row.Cells.Add(DeleteCell);

            return Row;
        }

        public TableCell MakeTableCell(string Text)
        {
            //This takes a string and puts it inside a textbox inside a tablecell
            TableCell cell = new TableCell();
            TextBox TB = new TextBox();
            TB.Text = Text;
            cell.Controls.Add(TB);

            return cell;
        }

        public void DeleteRow(Object sender, EventArgs e)
        {
            //If button clicked was a delete button
            Button btn = (Button)sender;
            if (btn.CommandName == "DeleteRow")
            {
                //Save changes, Delete Timesheet, Refreshpage
                SaveAllChanges();
                TBL.DeleteTimesheetEntry(btn.CommandArgument.ToString()); //CommandArgument = Timesheet EntryID
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}