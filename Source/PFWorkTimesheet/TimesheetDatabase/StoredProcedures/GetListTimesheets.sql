CREATE PROCEDURE [dbo].[GetListTimesheets]
AS

BEGIN
SELECT iTimesheetID, ForemanID, DateWeekEnding, DateSubmitted FROM Timesheet
END

GO
