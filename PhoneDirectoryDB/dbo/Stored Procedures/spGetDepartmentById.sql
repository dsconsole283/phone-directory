CREATE PROCEDURE [dbo].[spGetDepartmentById]
	@Id int

AS

BEGIN

	SELECT Id, [Name] FROM dbo.Departments
	WHERE Id = @Id

END
