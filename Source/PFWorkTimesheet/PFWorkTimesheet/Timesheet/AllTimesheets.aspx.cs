/* 
 * FileName:    AllTimesheets.aspx.cs
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
    public partial class AllTimesheets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.Identity.Name.ToLower() == "admin")
                {
                    TimesheetBusinessLogic TBL = new TimesheetBusinessLogic();

                    List<TimesheetListItem> Timesheets = TBL.GetTimesheetList();

                    foreach (TimesheetListItem sheet in Timesheets)
                    {
                        TableRow tr = new TableRow();

                        TableCell tc0 = new TableCell();
                        HyperLink hl = new HyperLink();
                        hl.Text = "TS-" + sheet.timesheetID;
                        hl.Style["font-weight"] = "bold";
                        hl.NavigateUrl = "EditTimesheet.aspx?ID=" + sheet.timesheetID;
                        tc0.Controls.Add(hl);
                        tr.Cells.Add(tc0);
                         
                        TableCell tc1 = new TableCell();
                        tc1.Text = sheet.foremanID;
                        tr.Cells.Add(tc1);

                        TableCell tc2 = new TableCell();
                        tc2.Text = sheet.dateEnding.Split(' ')[0];
                        tr.Cells.Add(tc2);

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
                    //If not Admin redirect to login page
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
            else
            {
                //If not logged in redirect to login page
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}