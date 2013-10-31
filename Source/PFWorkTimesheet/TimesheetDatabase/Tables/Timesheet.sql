CREATE TABLE [dbo].[Timesheet]
(
	[iTimesheetID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ForemanID] NVARCHAR(50) NULL, 
    [DateSubmitted] DATETIME NULL, 
    [DateWeekEnding] DATE NOT NULL, 
    [sJobSite] NVARCHAR(50) NULL, 
    [sSubContractor] NVARCHAR(50) NULL, 
    [Signature] VARBINARY(MAX) NULL
)
