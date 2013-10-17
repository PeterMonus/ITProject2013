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
            if(string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                TitleLabel.Text = "No Timesheet Found";
            }
            else
            {
                TableTimesheet.Visible = true;

                Timesheet = TBL.GetTimesheetByID(Request.QueryString["ID"]);

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

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < TableTimesheet.Rows.Count; i++)
            {
                TextBox tb = (TextBox)TableTimesheet.Rows[i].Cells[0].Controls[0];
                Timesheet.Entries[i-1].employeeName = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[1].Controls[0];
                Timesheet.Entries[i-1].employeeType = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[2].Controls[0];
                Timesheet.Entries[i-1].hoursWednesday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[3].Controls[0];
                Timesheet.Entries[i-1].hoursThursday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[4].Controls[0];
                Timesheet.Entries[i-1].hoursFirday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[5].Controls[0];
                Timesheet.Entries[i-1].hoursSaturday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[6].Controls[0];
                Timesheet.Entries[i-1].hoursSunday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[7].Controls[0];
                Timesheet.Entries[i-1].hoursMonday = tb.Text;

                tb = (TextBox)TableTimesheet.Rows[i].Cells[8].Controls[0];
                Timesheet.Entries[i-1].hoursTuesday = tb.Text;
                
                tb = (TextBox)TableTimesheet.Rows[i].Cells[9].Controls[0];
                Timesheet.Entries[i-1].comments = tb.Text;
            }
            
            
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

            DeleteButton.Command += DeleteRow;
            DeleteButton.CommandName = "DeleteRow";
            DeleteButton.CommandArgument = Entry.entryID;
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

        public void DeleteRow(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.CommandName == "DeleteRow")
            {
                TBL.DeleteTimesheetEntry(btn.CommandArgument.ToString());
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}