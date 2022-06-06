CREATE PROCEDURE [dbo].[spGetTitleIdByTitle]

	@Title nvarchar(50)

AS

BEGIN

	SELECT Id FROM dbo.Titles
	WHERE [Name] = @Title

END
