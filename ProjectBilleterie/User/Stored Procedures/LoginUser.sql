CREATE PROCEDURE [dbo].[LoginUser]
	@login nvarchar(255),
	@password nvarchar(255)
AS
	BEGIN
		SELECT UserID,Mail,[Login],BirthDate,IsAdmin,IsActive
		FROM [User] 
		WHERE [Login] = @login AND [Password] = HASHBYTES('SHA2_512', dbo.Salt() + @password)
	END
