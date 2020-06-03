CREATE PROCEDURE [dbo].[UpdateUser]
	@id int,
	@mail nvarchar(50),
	@login nvarchar(25),	
	@birthDate Date

AS
BEGIN
	UPDATE [User] 
	SET Mail = @mail, [Login] = @login, BirthDate = @birthDate
	WHERE UserID = @id
END