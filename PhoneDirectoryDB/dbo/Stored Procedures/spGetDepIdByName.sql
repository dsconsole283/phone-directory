CREATE PROCEDURE [dbo].[spGetDepIdByName]

	@Name nvarchar(50)

AS

BEGIN

	SELECT Id FROM dbo.Departments
	WHERE [Name] = @Name

END
