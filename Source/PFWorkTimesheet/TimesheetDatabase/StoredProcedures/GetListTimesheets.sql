CREATE PROCEDURE [dbo].[GetListTimesheets]
AS

BEGIN
SELECT iTimesheetID, ForemanID, DateWeekEnding, DateSubmitted, sJobSite FROM Timesheet
ORDER BY iTimesheetID DESC
END

GO
