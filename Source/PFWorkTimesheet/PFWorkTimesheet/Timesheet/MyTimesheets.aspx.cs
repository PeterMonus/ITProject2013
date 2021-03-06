﻿/* 
 * FileName:    MyTimesheets.aspx.cs
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
    public partial class MyTimesheets : System.Web.UI.Page
    {

        TimesheetBusinessLogic TBL = new TimesheetBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                List<TimesheetListItem> Timesheets = TBL.GetTimesheetList(User.Identity.Name.ToLower());

                //Populate table of list of timesheets
                foreach (TimesheetListItem sheet in Timesheets)
                {
                    //New row for each timesheet
                    TableRow tr = new TableRow();

                    //Column 1: Timesheet ID is link to edit timesheet page for timesheet
                    TableCell tc0 = new TableCell();
                    HyperLink hl = new HyperLink();
                    hl.Text = "TS-" + sheet.timesheetID;
                    hl.Style["font-weight"] = "bold";
                    hl.NavigateUrl = "EditTimesheet.aspx?ID=" + sheet.timesheetID;
                    tc0.Controls.Add(hl);
                    tr.Cells.Add(tc0);

                    //Column 2: Jobsite
                    TableCell tc1 = new TableCell();
                    tc1.Text = sheet.jobsite;
                    tr.Cells.Add(tc1);

                    //Column 3: Date Ending
                    TableCell tc2 = new TableCell();
                    tc2.Text = sheet.dateEnding.Split(' ')[0];
                    tr.Cells.Add(tc2);

                    //Column 4: Time submitted or "Not Submitted"
                    TableCell tc3 = new TableCell();
                    if (sheet.submitted == string.Empty)
                        tc3.Text = "Not Submitted";
                    else
                        tc3.Text = sheet.submitted.Split(' ')[0];
                    tr.Cells.Add(tc3);

                    TableTimesheets.Rows.Add(tr);
                }
            }
            else
            {
                //If not logged in redirect to login page
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void Button_NewTimesheet_Click(object sender, EventArgs e)
        {
            //Create new timesheet with selected foreman and date ending
            DateTime SelectedDate;
            if (DateTime.TryParse(Textbox_DateWeekEnding.Text, out SelectedDate))
            {
                if (SelectedDate.DayOfWeek != DayOfWeek.Tuesday)
                {
                    Label_Error.Text = "Please select a Tuesday";
                }
                else
                {
                    int NewTimesheetID = TBL.AddNewTimesheet(User.Identity.Name.ToLower(), SelectedDate);

                    //Add three new entries to new timesheet
                    for (int i = 1; i <= 3; i++)
                        TBL.AddTimesheetEntry(NewTimesheetID.ToString());

                    //Redirect user to edit new timesheet
                    Response.Redirect("EditTimesheet.aspx?ID=" + NewTimesheetID.ToString());
                }
            }
            else
            {
                Label_Error.Text = "Please select a Tuesday";
            }
        }
    }
}