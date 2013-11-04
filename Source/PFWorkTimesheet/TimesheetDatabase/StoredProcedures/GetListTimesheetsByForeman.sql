CREATE PROCEDURE [dbo].[GetListTimesheetsByForeman]
	@sForemanID NVARCHAR(50)
AS

BEGIN
SELECT  iTimesheetID, ForemanID, DateWeekEnding, DateSubmitted, sJobSite FROM Timesheet WHERE ForemanID = @sForemanID
ORDER BY iTimesheetID DESC
END

GO
