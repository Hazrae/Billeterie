CREATE PROCEDURE [dbo].[GetCheckoutInfo]
	@id int
	
AS
	SELECT u.CB_Num, u.CB_Valid, u.Mail
	FROM [User] as u
	WHERE u.UserID = @id
