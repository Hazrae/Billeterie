CREATE PROCEDURE [dbo].[UpdatePassword](
	@id INT,
	@oldpassword NVARCHAR(25),
	@password NVARCHAR(25)	
	)
AS
BEGIN
	IF( SELECT COUNT(*) 
	    FROM [User]  
        WHERE [Password] = HASHBYTES('SHA2_512',dbo.Salt() +@oldpassword) AND UserID = @id) = 0
		RETURN (1)
	ELSE
	BEGIN	
		UPDATE [User] 
		SET [Password] = HASHBYTES('SHA2_512',dbo.Salt() +@password)
		WHERE UserID = @id
		RETURN (0)
	END
END
