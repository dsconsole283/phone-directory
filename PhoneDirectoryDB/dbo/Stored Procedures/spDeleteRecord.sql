CREATE PROCEDURE [dbo].[spDeleteRecord]

	@Id int

AS

BEGIN

	DELETE FROM dbo.Personnel
	WHERE Personnel.Id = @ID

END
