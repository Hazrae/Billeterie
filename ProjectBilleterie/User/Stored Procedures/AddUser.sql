CREATE PROCEDURE [dbo].[AddUser]
	@mail nvarchar(255),
	@login nvarchar(255),
	@password nvarchar(255),
	@birthDate datetime2,
	@country int
AS
BEGIN
	INSERT INTO [User] (Mail,[Login],[Password],BirthDate, FK_Country)
	VALUES (@mail,
			@login,
			HASHBYTES('SHA2_512',dbo.Salt() +@password),
			@birthDate,
			@country)
END