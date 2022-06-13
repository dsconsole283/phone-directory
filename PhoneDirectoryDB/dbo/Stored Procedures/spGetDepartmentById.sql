CREATE PROCEDURE [dbo].[spGetDepartmentById]

	@Id int

AS

BEGIN

	SELECT [Name] FROM dbo.Departments
	WHERE Id = @Id

END
