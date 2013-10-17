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

        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                TitleLabel.Text = "No Timesheet Found";
            }
            else
            {                
                TableTimesheet.Visible = true;

                TimesheetObject Timesheet = TBL.GetTimesheetByID(Request.QueryString["ID"]);

                Textbox_Status.Text = Timesheet.submitted;
                Textbox_Week.Text = Timesheet.weekEnding.Split(' ')[0];
                Textbox_Subcontractor.Text = Timesheet.subcontractor;

                TitleLabel.Text = Timesheet.weekEnding.Split(' ')[0];

                foreach (TimesheetEntry TE in Timesheet.Entries)
                {
                    TableTimesheet.Rows.Add(MakeTableRow(TE));
                }

                if (Timesheet.Entries.Count == 0)
                {
                    TitleLabel.Text = "No Timesheet Found";

                    TableTimesheet.Visible = false;
                    Button_Submit.Visible = false;
                    Button_NewRow.Visible = false;
                }
            }
        }

        protected void Button_NewRow_Click(object sender, EventArgs e)
        {
            TBL.AddTimesheetEntry(Request.QueryString["ID"]);
            Response.Redirect(Request.RawUrl);            
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {

        }

        public TableRow MakeTableRow(TimesheetEntry Entry)
        {
            TableRow Row = new TableRow();

            TableCell DeleteCell = new TableCell();
            Button DeleteButton = new Button();
            DeleteButton.Text = "X";
            DeleteButton.ToolTip = "Delete This Row";
            DeleteButton.OnClientClick = "DeleteRow(" + Entry.entryID + ")";
            DeleteCell.Controls.Add(DeleteButton);
            
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
            TableCell cell = new TableCell();
            TextBox TB = new TextBox();
            TB.Text = Text;
            cell.Controls.Add(TB);

            return cell;
        }

        public void DeleteRow(string ID)
        {

        }
    }
}