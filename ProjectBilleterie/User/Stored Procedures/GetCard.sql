CREATE PROCEDURE [dbo].[GetCard]
	@id int
	
AS
	SELECT u.CB_Num, u.CB_Valid
	FROM [User] as u
	WHERE u.UserID = @id
RETURN 0
