CREATE PROCEDURE [dbo].[spGetAllTitles]
	
AS

BEGIN

	SELECT Id, [Name] FROM dbo.Titles

END
