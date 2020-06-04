CREATE VIEW [dbo].[UserSafeView]
	AS SELECT UserID, [Login], Mail, BirthDate, IsAdmin FROM [User]
