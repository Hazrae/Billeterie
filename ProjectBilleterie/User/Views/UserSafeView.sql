CREATE VIEW [dbo].[UserSafeView]
	AS SELECT UserID, [Login], Mail, BirthDate, Address_Num, Address_Street, Address_City, Address_ZIP, IsAdmin FROM [User]
