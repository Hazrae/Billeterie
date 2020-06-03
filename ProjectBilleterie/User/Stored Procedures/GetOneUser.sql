CREATE PROCEDURE [dbo].[GetOne]
	@id int
AS
BEGIN
	SELECT * FROM UserSafeView where UserID = @id
END
