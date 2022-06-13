CREATE PROCEDURE [dbo].[spAddRecord]

	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DepartmentId int,
	@TitleID int,
	@EmailAddress nvarchar(50),
	@PhoneMain nchar(11),
	@PhoneMobile nchar(11),
	@Extension nchar(5),
	@Notes nvarchar(MAX),
	@IsExec bit

AS

BEGIN

INSERT INTO dbo.Personnel (FirstName, LastName, DepartmentId, TitleId, EmailAddress, PhoneMain, PhoneMobile, Extension, Notes, IsExec)
VALUES (@FirstName, @LastName, @DepartmentId, @TitleID, @EmailAddress, @PhoneMain, @PhoneMobile, @Extension, @Notes, @IsExec)

END

