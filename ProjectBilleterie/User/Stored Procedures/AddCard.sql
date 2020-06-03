CREATE PROCEDURE [dbo].[AddCard]
	@num bigint,
	@valid date,
	@code nvarchar(255),
	@id int
AS
	UPDATE [User]
	SET CB_Num =  @num, 
		CB_Valid = @valid, 
		CB_Code = HASHBYTES('SHA2_512',dbo.Salt() +@code)
	WHERE UserID = @id
