CREATE PROCEDURE [dbo].[GetListTimesheetsByForeman]
	@sForemanID NVARCHAR(50)
AS

BEGIN
SELECT  iTimesheetID, ForemanID, DateWeekEnding, DateSubmitted FROM Timesheet WHERE ForemanID = @sForemanID
END

GO
