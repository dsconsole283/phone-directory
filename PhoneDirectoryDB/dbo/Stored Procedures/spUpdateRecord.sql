CREATE PROCEDURE [dbo].[spUpdateRecord]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DepartmentId int,
	@TitleID int,
	@EmailAddress nvarchar(50),
	@PhoneMain nvarchar(11),
	@PhoneMobile nvarchar(11),
	@Extension nvarchar(5),
	@Notes nvarchar(MAX),
	@IsExec bit
AS

BEGIN

UPDATE dbo.Personnel
SET FirstName = @FirstName
	,LastName = @LastName
	,DepartmentId = @DepartmentId
	,TitleId = @TitleID
	,EmailAddress = @EmailAddress
	,PhoneMain = @PhoneMain
	,PhoneMobile = @PhoneMobile
	,Extension = @Extension
	,Notes = @Notes
	,IsExec = @IsExec
WHERE dbo.Personnel.Id = @Id

END


