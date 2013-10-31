/* 
 * FileName:    TimesheetEntry.cs
 * Author:      Peter Monus
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetBusiness
{
    public class TimesheetEntry
    {
        public string entryID { get; set; }

        public string timesheetID { get; set; }

        public string employeeID { get; set; }

        public string employeeName { get; set; }

        public string comments { get; set; }

        public string employeeType { get; set; }

        public string hoursWednesday { get; set; }
        public string hoursThursday { get; set; }
        public string hoursFirday { get; set; }
        public string hoursSaturday { get; set; }
        public string hoursSunday { get; set; }
        public string hoursMonday { get; set; }
        public string hoursTuesday { get; set; }
    }
}
