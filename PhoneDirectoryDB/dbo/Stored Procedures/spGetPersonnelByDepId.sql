CREATE PROCEDURE [dbo].[spGetPersonnelByDepId]
	@DepartmentId int
AS

BEGIN

	SELECT FirstName, LastName, TitleId, EmailAddress, PhoneMain, PhoneMobile, Extension, Notes, IsExec
	FROM dbo.Personnel
	WHERE DepartmentId = @DepartmentId

END
