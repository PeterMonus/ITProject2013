/* 
 * FileName:    TimesheetDA.cs
 * Author:      Peter Monus
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;

namespace TimesheetDataAccess
{
    public class TimesheetDA
    {
        /// <summary>AddNewTimesheet
        /// <para>
        /// Input: Foreman, WeekEnding
        /// Output: Adds new timesheet
        /// Return: Timesheet ID of new timesheet
        /// </para>
        /// </summary>
        public int AddNewTimesheet(string Foreman, DateTime WeekEnding)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "AddNewTimesheet";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Foreman", SqlDbType.NVarChar).Value = Foreman;
            cmd.Parameters.Add("@WeekEnding", SqlDbType.DateTime).Value = WeekEnding;

            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            int TimesheetID = 0;

            while (reader.Read())
            {
                TimesheetID = int.Parse(reader[0].ToString());
            }

            sqlConnection1.Close();

            return TimesheetID;
        }

        /// <summary>UpdateTimeSheet
        /// <para>
        /// Input: TimesheetIDdate, Submitted, subcontractor, signature
        /// Output: Updates all fields within the specified Timesheet ID
        /// Return: None
        /// </para>
        /// </summary>
        public void UpdateTimesheetInfo(string TimesheetID, string dateSubmitted, string subcontractor, string jobsite, string signature)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "UpdateTimesheetByID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@iTimesheetID", SqlDbType.Int).Value = int.Parse(TimesheetID);
            //Date time doesn't accept NULL strings. Use MinValue instead
            if (string.IsNullOrEmpty(dateSubmitted))
            {
                cmd.Parameters.Add("@DateSubmitted", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@DateSubmitted", SqlDbType.DateTime).Value = DateTime.Parse(dateSubmitted);
            }
            cmd.Parameters.Add("@sSubContractor", SqlDbType.NVarChar).Value = subcontractor;
            cmd.Parameters.Add("@sJobsite", SqlDbType.NVarChar).Value = jobsite;
            cmd.Parameters.Add("@Signature", SqlDbType.VarBinary).Value = Encoding.Default.GetBytes(subcontractor);

            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            sqlConnection1.Close();
        }

        /// <summary>UpdateTimeSheetEntry
        /// <para>
        /// Input: EntryID,TimesheetID,EmployeeID,EmployeeName,EmployeeType,HoursWednesday,HoursThursday,HoursFriday,HoursSaturday,HoursSunday,HoursMonday,HoursTuesday,Comments
        /// Output: Updates all fields within the specified entry ID
        /// Return: None
        /// </para>
        /// </summary>
        public void UpdateTimesheetEntry(string EntryID,
                                            string TimesheetID,
                                            string EmployeeID,
                                            string EmployeeName,
                                            string EmployeeType,
                                            string HoursWednesday,
                                            string HoursThursday,
                                            string HoursFriday,
                                            string HoursSaturday,
                                            string HoursSunday,
                                            string HoursMonday,
                                            string HoursTuesday,
                                            string Comments)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "UpdateTimesheetEntryByID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EntryID", SqlDbType.Int).Value = int.Parse(EntryID);
            cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = int.Parse(TimesheetID);
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = EmployeeID;
	        cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = EmployeeName;
            cmd.Parameters.Add("@EmployeeType", SqlDbType.NVarChar).Value = EmployeeType;
            cmd.Parameters.Add("@HoursWednesday", SqlDbType.NVarChar).Value = HoursWednesday;
            cmd.Parameters.Add("@HoursThursday", SqlDbType.NVarChar).Value = HoursThursday;
            cmd.Parameters.Add("@HoursFriday", SqlDbType.NVarChar).Value = HoursFriday;
            cmd.Parameters.Add("@HoursSaturday", SqlDbType.NVarChar).Value = HoursSaturday;
            cmd.Parameters.Add("@HoursSunday", SqlDbType.NVarChar).Value = HoursSunday;
            cmd.Parameters.Add("@HoursMonday", SqlDbType.NVarChar).Value = HoursMonday;
            cmd.Parameters.Add("@HoursTuesday", SqlDbType.NVarChar).Value = HoursTuesday;
            cmd.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = Comments;

            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            sqlConnection1.Close();
        }

        /// <summary>DeleteTimesheetEntry
        /// <para>
        /// Input: Entry ID
        /// Output: Calls database procedure to delete a timesheet entry
        /// Return: None
        /// </para>
        /// </summary>
        public void DeleteTimesheetEntry(string ID)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "DeleteTimesheetEntry";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EntryID", SqlDbType.Int).Value = int.Parse(ID);
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            sqlConnection1.Close();
        }

        /// <summary>AddNewTimesheetEntry
        /// <para>
        /// Input: Timesheet ID
        /// Output: Calls database procedure to add a new timesheet entry into specified timesheet
        /// Return: None
        /// </para>
        /// </summary>
        public void AddNewTimesheetEntry(string ID)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "AddNewTimesheetEntry";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = int.Parse(ID);
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            sqlConnection1.Close();
        }

        /// <summary>GetTimesheetList
        /// <para>
        /// Input: None/ForemanID
        /// Output: Calls stored procedure to get a list of all timesheets or timesheets with specified foreman ID
        /// Returns: semicolon (;) delimeted string list of timesheets
        /// </para>
        /// </summary>
        public List<string> GetTimesheetList()
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetListTimesheets";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            List<string> Timesheets = new List<string>();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Timesheets.Add(
                    reader[0].ToString() + ";" +
                    reader[1].ToString() + ";" +
                    reader[2].ToString() + ";" +
                    reader[3].ToString() + ";" +
                    reader[4].ToString());
            }

            sqlConnection1.Close();

            return Timesheets;
        }

        /// <summary>GetTimesheetList
        /// <para>
        /// Input: None/ForemanID
        /// Output: Calls stored procedure to get a list of all timesheets or timesheets with specified foreman ID
        /// Returns: semicolon (;) delimeted string list of timesheets
        /// </para>
        /// </summary>
        public List<string> GetTimesheetList(string ForemanID)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetListTimesheetsByForeman";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sForemanID", SqlDbType.NVarChar).Value = ForemanID;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            List<string> Timesheets = new List<string>();

            while (reader.Read())
            {
                Timesheets.Add(
                    reader[0].ToString() + ";" +
                    reader[1].ToString() + ";" +
                    reader[2].ToString() + ";" +
                    reader[3].ToString() + ";" +
                    reader[4].ToString());
            }

            sqlConnection1.Close();

            return Timesheets;
        }

        /// <summary>GetTimesheetEntriesByID
        /// <para>
        /// Input: Timesheet ID
        /// Output: Calls stored procedure to get all entries within specified timesheet
        /// Returns: Semicolon (;) delimited string list of timesheet entries
        /// </para>
        /// </summary>
        public List<string> GetTimesheetEntriesByID(string ID)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetTimesheetEntriesByID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = int.Parse(ID);
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            List<string> TimesheetsEntries = new List<string>();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            { 
                TimesheetsEntries.Add(
                    reader[0].ToString() + ";" + 
                    reader[1].ToString() + ";" + 
                    reader[2].ToString() + ";" +
                    reader[3].ToString() + ";" +
                    reader[4].ToString() + ";" +
                    reader[5].ToString() + ";" +
                    reader[6].ToString() + ";" +
                    reader[7].ToString() + ";" +
                    reader[8].ToString() + ";" +
                    reader[9].ToString() + ";" +
                    reader[10].ToString() + ";" +
                    reader[11].ToString() + ";" + 
                    reader[12].ToString());
            }

            sqlConnection1.Close();

            return TimesheetsEntries;
        }

        /// <summary>GetTimesheetDataByID
        /// <para>
        /// Input: Timesheet ID
        /// Output: Calls stored procedure to get information about specified timesheet
        /// Returns: Semicolon (;) delimited string list of timesheet info
        /// </para>
        /// </summary>
        public List<string> GetTimesheetDataByID(string ID)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetTimesheetByID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = int.Parse(ID);
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            List<string> TimesheetData = new List<string>();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TimesheetData.Add(
                    reader[0].ToString() + ";" +
                    reader[1].ToString() + ";" +
                    reader[2].ToString() + ";" +
                    reader[3].ToString() + ";" +
                    reader[4].ToString() + ";" +
                    reader[5].ToString() + ";" +
                    reader[6].ToString());
            }

            sqlConnection1.Close();

            return TimesheetData;
        }
    }
}
