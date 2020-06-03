CREATE PROCEDURE [dbo].[AddAddress]
	@num int,
	@street nvarchar(255),
	@city nvarchar(255),
	@zip int,
	@id int
AS
BEGIN
	UPDATE [User]
	SET Address_Num = @num, 
		Address_Street = @street, 
		Address_City = @city, 
		Address_ZIP = @zip 
	WHERE UserID = @id
END
