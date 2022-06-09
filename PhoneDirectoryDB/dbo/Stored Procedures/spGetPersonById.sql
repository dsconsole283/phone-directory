CREATE PROCEDURE [dbo].[spGetPersonById]

	@Id int

AS

BEGIN

	SELECT * FROM dbo.Personnel AS p
	WHERE p.Id = @Id

END
