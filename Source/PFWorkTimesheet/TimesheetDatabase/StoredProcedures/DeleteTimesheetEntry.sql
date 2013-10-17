CREATE PROCEDURE [dbo].[DeleteTimesheetEntry]
@EntryID INT

AS

BEGIN
DELETE FROM TimesheetEntry WHERE iEntryID = @EntryID
END