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
                    reader[3].ToString());
            }

            sqlConnection1.Close();

            return Timesheets;
        }

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
