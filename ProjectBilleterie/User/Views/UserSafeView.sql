CREATE VIEW [dbo].[UserSafeView]
	AS SELECT UserID, [Login], Mail, BirthDate, IsAdmin, IsActive,FK_Country FROM [User]
