CREATE PROCEDURE [dbo].[GetTimesheetEntriesByID]
@TimesheetID INT

AS

BEGIN
SELECT * FROM TimesheetEntry WHERE iTimesheetID = @TimesheetID
END

GO
