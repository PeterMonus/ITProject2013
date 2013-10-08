using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetBusiness
{
    public class TimesheetObject
    {
        public List<TimesheetEntry> Entries = new List<TimesheetEntry>();

        public string timesheetID { get; set; }
        
        public string foremanID { get; set; }

        public string submitted { get; set; }

        public string weekEnding { get; set; }

        public string jobsite { get; set; }

        public string subcontractor { get; set; }

        public string signature { get; set; }
    }
}
