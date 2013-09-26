CREATE PROCEDURE [dbo].[GetListTimesheets]
	@iTimesheetID INT
AS

BEGIN
SELECT iTimesheetID FROM Timesheet
END

GO
