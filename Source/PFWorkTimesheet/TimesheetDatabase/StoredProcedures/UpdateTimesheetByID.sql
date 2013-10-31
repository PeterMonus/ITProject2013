CREATE PROCEDURE [dbo].[UpdateTimesheetByID]
    @iTimesheetID INT,
    @DateSubmitted DATETIME,
    @sSubContractor NVARCHAR(50),
	@sJobsite NVARCHAR(50),
    @Signature VARBINARY(MAX)
AS

BEGIN
	UPDATE Timesheet
	SET 
		DateSubmitted=@DateSubmitted,
		sSubContractor=@sSubContractor,
		sJobSite=@sJobsite,
		Signature=@Signature
	WHERE 
		iTimesheetID = @iTimesheetID
END

GO
