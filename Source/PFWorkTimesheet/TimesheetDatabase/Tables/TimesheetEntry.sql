CREATE TABLE [dbo].[TimesheetEntry]
(
	[iEntryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [iTimesheetID] INT NOT NULL, 
    [EmployeeID] NCHAR(10) NULL,
	[sEmployeeName] NCHAR(10) NULL,
    [cEmployeeType] NCHAR(10) NULL, 
    [sHoursWednesday] NCHAR(10) NULL, 
    [sHoursThursday] NCHAR(10) NULL, 
    [sHoursFriday] NCHAR(10) NULL, 
    [sHoursSaturday] NCHAR(10) NULL, 
    [sHoursSunday] NCHAR(10) NULL, 
    [sHoursMonday] NCHAR(10) NULL, 
    [sHoursTuesday] NCHAR(10) NULL, 
    [sComments] NCHAR(10) NULL
)
