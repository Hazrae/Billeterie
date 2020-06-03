CREATE PROCEDURE [dbo].[DeleteUser]
	@id int
AS
BEGIN
		UPDATE [User] 
		SET IsActive = 0 
		WHERE UserID = @id
END
