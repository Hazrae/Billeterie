CREATE PROCEDURE [dbo].[AddCard]
	@num nvarchar(50),
	@valid nvarchar(5),
	@id int
AS
		UPDATE [User]
	SET CB_Num =  @num, 
		CB_Valid = @valid
	WHERE UserID = @id
