CREATE PROCEDURE [dbo].[spCreateDepartment]

@Department nvarchar(50)

AS

BEGIN

	IF NOT EXISTS 
(
	SELECT [Name]
	FROM dbo.Departments 
	WHERE [Name] = @Department
)

INSERT INTO dbo.Departments ([Name])
VALUES (@Department)

ELSE

RETURN 0

END
