CREATE TABLE [dbo].[TimesheetEntry]
(
	[iEntryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [iTimesheetID] INT NOT NULL, 
    [EmployeeID] NVARCHAR(50) NULL,
	[sEmployeeName] NVARCHAR(50) NULL,
    [cEmployeeType] NVARCHAR(50) NULL, 
    [sHoursWednesday] NVARCHAR(50) NULL, 
    [sHoursThursday] NVARCHAR(50) NULL, 
    [sHoursFriday] NVARCHAR(50) NULL, 
    [sHoursSaturday] NVARCHAR(50) NULL, 
    [sHoursSunday] NVARCHAR(50) NULL, 
    [sHoursMonday] NVARCHAR(50) NULL, 
    [sHoursTuesday] NVARCHAR(50) NULL, 
    [sComments] NVARCHAR(50) NULL
)
