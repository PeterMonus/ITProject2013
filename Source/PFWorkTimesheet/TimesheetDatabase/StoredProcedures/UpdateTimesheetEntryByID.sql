CREATE PROCEDURE [dbo].[UpdateTimesheetEntryByID]
	@EntryID INT,
    @TimesheetID INT,    
    @EmployeeID NVARCHAR(50),  
	@EmployeeName NVARCHAR(50),  
    @EmployeeType NVARCHAR(50),   
    @HoursWednesday NVARCHAR(50),   
    @HoursThursday NVARCHAR(50),   
    @HoursFriday NVARCHAR(50),   
    @HoursSaturday NVARCHAR(50),   
    @HoursSunday NVARCHAR(50),   
    @HoursMonday NVARCHAR(50),   
    @HoursTuesday NVARCHAR(50),   
    @Comments NVARCHAR(50)  
AS

BEGIN
	UPDATE TimesheetEntry
	SET 
		sEmployeeName=@EmployeeName,
		cEmployeeType=@EmployeeType,
		sHoursWednesday=@HoursWednesday,
		sHoursThursday=@HoursThursday,
		sHoursFriday=@HoursFriday,
		sHoursSaturday=@HoursSaturday,
		sHoursSunday=@HoursSunday,
		sHoursMonday=@HoursMonday,
		sHoursTuesday=@HoursTuesday,
		sComments=@Comments
	WHERE
		iEntryID = @EntryID;
END

GO