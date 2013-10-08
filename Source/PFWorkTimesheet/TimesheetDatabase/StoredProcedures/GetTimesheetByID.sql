CREATE PROCEDURE [dbo].[GetTimesheetByID]
@TimesheetID INT

AS

BEGIN
SELECT * FROM Timesheet WHERE iTimesheetID = @TimesheetID
END

GO
