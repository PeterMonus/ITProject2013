/* 
 * FileName:    TimesheetListItem.cs
 * Author:      Peter Monus
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetBusiness
{
    public class TimesheetListItem
    {
        public string timesheetID { get; set; }      

        public string foremanID { get; set; }

        public string dateEnding { get; set; }

        public string submitted { get; set; }
        
    }
}
