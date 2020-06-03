CREATE TRIGGER [OnDelete]
ON [User]
INSTEAD OF DELETE
AS
BEGIN
	EXEC DeleteUser(Select UserID from inserted)
	--UPDATE [User] 
	--SET isActive = 0
	--WHERE Userid in (Select UserID from inserted)
END
