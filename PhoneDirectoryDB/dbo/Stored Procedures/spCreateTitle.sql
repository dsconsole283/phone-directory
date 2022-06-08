CREATE PROCEDURE [dbo].[spCreateTitle]

@Title nvarchar(50)

AS

BEGIN

	IF NOT EXISTS 
(
	SELECT [Name]
	FROM dbo.Titles 
	WHERE [Name] = @Title
)

INSERT INTO dbo.Titles ([Name])
VALUES (@Title)

ELSE

RETURN 0

END
