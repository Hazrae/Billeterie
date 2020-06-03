CREATE TABLE [dbo].[Artist]
(
	ArtistID int identity primary key,
	[Name] nvarchar(255) not null,
	[Desc] nvarchar(255),
	Photo nvarchar(255)

	constraint Unique_Name_Artist unique ([Name])
)
