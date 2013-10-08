CREATE PROCEDURE [dbo].[GetListTimesheetsByForeman]
	@sForemanID NCHAR
AS

BEGIN
SELECT  iTimesheetID, ForemanID, DateWeekEnding, DateSubmitted FROM Timesheet WHERE ForemanID = @sForemanID
END

GO
