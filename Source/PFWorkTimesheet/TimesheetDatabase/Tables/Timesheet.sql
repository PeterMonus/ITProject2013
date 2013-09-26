CREATE TABLE [dbo].[Timesheet]
(
	[iTimesheetID] INT NOT NULL PRIMARY KEY, 
    [ForemanID] NCHAR(10) NULL, 
    [bSubmitted] DATETIME NULL, 
    [DateWeekEnding] DATE NOT NULL, 
    [sJobSite] NCHAR(10) NULL, 
    [sSubContractor] NCHAR(10) NULL, 
    [Signature] VARBINARY(MAX) NULL
)
