CREATE PROCEDURE [dbo].[AddCard]
	@num bigint,
	@valid datetime2,
	@code nvarchar(255),
	@id int
AS
		UPDATE [User]
	SET CB_Num =  @num, 
		CB_Valid = @valid
	WHERE UserID = @id
