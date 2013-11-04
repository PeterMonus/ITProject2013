/* 
 * FileName:    LevesysDA.cs
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
    public class LevesysDA
    {
        /// <summary>GetEmployeeList
        /// <para>
        /// Input: None
        /// Output: Performs SQL Query on Levesys Database
        /// Return: String List of employees
        /// </para>
        /// </summary>
        public List<string> GetEmployeeList()
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["LevesysDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT [FIRST_NAME],[SURNAME] FROM [Lev_PacificFormworkAust_GL].[dbo].[G110] WHERE [FINISH_DATE] IS NULL ORDER BY [SURNAME]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            List<string> Employees = new List<string>();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employees.Add(
                    reader[0].ToString() + " " +
                    reader[1].ToString());
            }

            sqlConnection1.Close();

            return Employees;
        }

        /// <summary>GetJobsiteList
        /// <para>
        /// Input: None
        /// Output: Performs SQL Query on Levesys Database
        /// Return: String List of jobsites
        /// </para>
        /// </summary>
        public List<string> GetJobsiteList()
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["LevesysDatabaseConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT [JOB_NAME] FROM [Lev_PacificFormworkAust_GL].[dbo].[G30] WHERE [FINISH_DATE] IS NULL ORDER BY [JOB_NAME]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            List<string> Jobsites = new List<string>();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Jobsites.Add(
                    reader[0].ToString());
            }

            sqlConnection1.Close();

            return Jobsites;
        }
    }
}
