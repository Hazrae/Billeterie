CREATE PROCEDURE [dbo].[AddUser]
	@mail nvarchar(255),
	@login nvarchar(255),
	@password nvarchar(255),
	@birthDate Date	
AS
BEGIN
	INSERT INTO [User] (Mail,[Login],[Password],BirthDate)
	VALUES (@mail,
			@login,
			HASHBYTES('SHA2_512',dbo.Salt() +@password),
			@birthDate)
END