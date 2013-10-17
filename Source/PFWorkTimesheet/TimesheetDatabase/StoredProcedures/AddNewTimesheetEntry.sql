CREATE PROCEDURE [dbo].[AddNewTimesheetEntry]
@TimesheetID INT

AS

BEGIN
INSERT INTO [TimesheetEntry]([iTimesheetID]) VALUES (@TimesheetID)
END

GO
