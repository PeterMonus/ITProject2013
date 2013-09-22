using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetBusiness
{
    class TimesheetRow
    {


        public void TimesheetObject()
        {
        }

        public string jobsite
        {
            get{ return jobsite; }
            set { jobsite = value; }
        }

        public string employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public string date
        {
            get { return date; }
            set { date = value; }
        }

        public string code
        {
            get { return code; }
            set { code = value; }
        }

        public string comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public string hoursWednesday
        {
            get { return hoursWednesday; }
            set { hoursWednesday = value; }
        }
        public string hoursThursday
        {
            get { return hoursThursday; }
            set { hoursThursday = value; }
        }
        public string hoursFirday
        {
            get { return hoursFirday; }
            set { hoursFirday = value; }
        }
        public string hoursSaturday
        {
            get { return hoursSaturday; }
            set { hoursSaturday = value; }
        }
        public string hoursabc
        {
            get { return hoursabc; }
            set { hoursabc = value; }
        }



    }
}
