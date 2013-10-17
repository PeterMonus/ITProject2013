using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetDataAccess;

namespace TimesheetBusiness
{
    public class TimesheetBusinessLogic
    {
        TimesheetDA TDA = new TimesheetDA();

        public void DeleteTimesheetEntry(string entryID)
        {            
            TDA.DeleteTimesheetEntry(entryID);
        }

        public void AddTimesheetEntry(string timesheetID)
        {            
            TDA.AddNewTimesheetEntry(timesheetID);
        }

        public List<TimesheetListItem> GetTimesheetList()
        {
            List<TimesheetListItem> Timesheets = new List<TimesheetListItem>();

            foreach (string ts in TDA.GetTimesheetList())
            {
                TimesheetListItem sheet = new TimesheetListItem();
                string[] words = ts.Split(';');

                sheet.timesheetID = words[0];
                sheet.foremanID = words[1];
                sheet.dateEnding = words[2];
                sheet.submitted = words[3];

                Timesheets.Add(sheet);
            }

            return Timesheets;
        }

        public TimesheetObject GetTimesheetByID(string timesheetID)
        {
            TimesheetObject TSO = new TimesheetObject();

            foreach (string ts in TDA.GetTimesheetDataByID(timesheetID))
            {
                string[] words = ts.Split(';');

                TSO.timesheetID = words[0];
                TSO.foremanID = words[1];
                TSO.submitted = words[2];
                TSO.weekEnding = words[3];
                TSO.jobsite = words[4];
                TSO.subcontractor = words[5];
                TSO.signature = words[6];                                
            }

            foreach (string ts in TDA.GetTimesheetEntriesByID(timesheetID))
            {
                string[] words = ts.Split(';');

                TimesheetEntry TSE = new TimesheetEntry();

                TSE.entryID = words[0];
                TSE.timesheetID = words[1];
                TSE.employeeID = words[2];
                TSE.employeeName = words[3];
                TSE.employeeType = words[4];
                TSE.hoursWednesday = words[5];
                TSE.hoursThursday = words[6];
                TSE.hoursFirday = words[7];
                TSE.hoursSaturday = words[8];
                TSE.hoursSunday = words[9];
                TSE.hoursMonday = words[10];
                TSE.hoursTuesday = words[11];
                TSE.comments = words[12];

                TSO.Entries.Add(TSE);                
            }
            return TSO;
        }
    }
}
