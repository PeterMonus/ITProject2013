using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PFWorkTimesheet.Timesheet
{
    public partial class EditTimesheet : System.Web.UI.Page
    {
        List<TableRow> TableRows = new List<TableRow>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
            if (!Page.IsPostBack)
            {
                for (int j = 0; j < 4; j++)
                {
                    TableRow CopyRow = new TableRow();
                    for (int i = 0; i < 10; i++)
                    {
                        TableCell cell = new TableCell();
                        cell.Controls.Add(new TextBox());
                        CopyRow.Cells.Add(cell);
                    }
                    TableRows.Add(CopyRow);
                }
            }
            foreach (TableRow tr in TableRows)
            {
                TableTimesheet.Rows.Add(tr);
            }
             **/
        }

        protected void Button_NewRow_Click(object sender, EventArgs e)
        {
            TableRow CopyRow = new TableRow();
            for (int i = 0; i < 10; i++)
            {
                TableCell cell = new TableCell();
                cell.Controls.Add(new TextBox());
                CopyRow.Cells.Add(cell);
            }
            TableRows.Add(CopyRow);
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {

        }
    }
}