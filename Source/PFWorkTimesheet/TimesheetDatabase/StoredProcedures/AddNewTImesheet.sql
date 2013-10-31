CREATE PROCEDURE [dbo].[AddNewTImesheet]
	@Foreman NVARCHAR(50),
	@WeekEnding DATE
AS

BEGIN

INSERT INTO [Timesheet]([DateWeekEnding],[ForemanID]) VALUES (@WeekEnding, @Foreman)

SELECT SCOPE_IDENTITY() AS NewID

END

