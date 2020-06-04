CREATE PROCEDURE [dbo].[UpdateUser]
	@id int,
	@mail nvarchar(50),
	@login nvarchar(25),	
	@birthDate datetime2,
	@country int

AS
BEGIN
	UPDATE [User] 
	SET Mail = @mail, [Login] = @login, BirthDate = @birthDate, FK_Country = @country
	WHERE UserID = @id
END