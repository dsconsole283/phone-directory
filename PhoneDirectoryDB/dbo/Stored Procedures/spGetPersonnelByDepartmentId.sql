CREATE PROCEDURE [dbo].[spGetPersonnelByDepartmentId]

	@Id int 

AS

BEGIN

	SELECT * FROM dbo.Personnel AS p
	WHERE p.DepartmentId = @Id

END
