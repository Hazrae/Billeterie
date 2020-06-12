CREATE TABLE [dbo].[Event]
(
	EventID int identity primary key,
	[Date] DATETIME2 not null,
	[Name] varchar(255) not null,
	FK_Location int not null,
	FK_Artist int not null

	constraint FK_Locate foreign key (FK_Location) references [Location](LocationID)
	constraint FK_Artist foreign key (FK_Artist) references Artist(ArtistID)
)
