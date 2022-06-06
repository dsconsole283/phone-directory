CREATE PROCEDURE [dbo].[spGetAllDepartments]

AS

BEGIN

	SELECT Id, [Name] FROM dbo.Departments

END
