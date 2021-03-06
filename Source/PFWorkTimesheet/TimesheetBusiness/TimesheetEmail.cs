﻿/* 
 * FileName:    TimesheetEmail.cs
 * Author:      Peter Monus
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Configuration;

namespace TimesheetBusiness
{
    public class TimesheetEmail
    {
        public void SendEmail(TimesheetObject Timesheet)
        {

            //Build the body of the email
            string EmailBody =
                @"<table border=""1"">

                <tr>
                <td>TimesheetID: </td>
                <td>" + Timesheet.timesheetID + @"</td>
                </tr>

                <tr>
                <td>Foreman: </td>
                <td>" + Timesheet.foremanID + @"</td>
                </tr>

                <tr>
                <td>Week Ending: </td>
                <td>" + Timesheet.weekEnding + @"</td>
                </tr>

                <tr>
                <td>Submitted On: </td>
                <td>" + Timesheet.submitted + @"</td>
                </tr>

                <tr>
                <td>Contractor: </td>
                <td>" + Timesheet.subcontractor + @"</td>
                </tr>

                <tr>
                <td>Jobsite: </td>
                <td>" + Timesheet.jobsite + @"</td>
                </tr>

                </table>
                
                <table border=""1"">
                <tr>
                <td>Name</td>
                <td>C/L</td>
                <td>Wed</td>
                <td>Thu</td>
                <td>Fri</td>
                <td>Sat</td>
                <td>Sun</td>
                <td>Mon</td>
                <td>Tue</td>
                <td>Comments</td>
                </tr>
                ";

            foreach (TimesheetEntry TE in Timesheet.Entries)
            {
                EmailBody +=
                    @"
                    <tr>
                    <td>" + TE.employeeName + @"</td>
                    <td>" + TE.employeeType + @"</td>
                    <td>" + TE.hoursWednesday + @"</td>
                    <td>" + TE.hoursThursday + @"</td>
                    <td>" + TE.hoursFirday + @"</td>
                    <td>" + TE.hoursSaturday + @"</td>
                    <td>" + TE.hoursSunday + @"</td>
                    <td>" + TE.hoursMonday + @"</td>
                    <td>" + TE.hoursTuesday + @"</td>
                    <td>" + TE.comments + @"</td>
                    </tr>
                    ";
            }

            EmailBody += @"</table>";

            //create the message
            MailMessage objMail = new MailMessage();

            string[] toEmails = ConfigurationManager.AppSettings["ToEmailAddress"].Split(',');

            foreach (string email in toEmails)
            {
                objMail.To.Add(email);
            }

            objMail.From = new MailAddress(ConfigurationManager.AppSettings["FromEmailAddress"]);
            objMail.Subject = "Timesheeting: New Timesheet From " + Timesheet.foremanID;
            objMail.Body = EmailBody;

            objMail.IsBodyHtml = true;
            NetworkCredential objNC = new NetworkCredential(ConfigurationManager.AppSettings["EmailUsername"], ConfigurationManager.AppSettings["EmailPassword"]);
            SmtpClient objsmtp = new SmtpClient(ConfigurationManager.AppSettings["EmailSMTPServer"], int.Parse(ConfigurationManager.AppSettings["EmailServerPort"]));
            objsmtp.EnableSsl = true;
            objsmtp.Credentials = objNC;
            objsmtp.Send(objMail);
        }
    }
}
