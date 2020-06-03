CREATE TABLE [dbo].[Location]
(
	LocationID int identity primary key,
	[Name] nvarchar(255) not null,
	[Desc] nvarchar(255)

	constraint unique_Name_Location unique ([Name])
)
