CREATE TABLE [dbo].[User]
(
	UserID int identity primary key,
	[Login] nvarchar(255) not null,
	[Password] varbinary(64) not null,
	Mail nvarchar(255) not null,
	BirthDate DATETIME2 not null,
	CB_Num BIGINT,
	CB_Valid DATETIME2,
	IsAdmin bit default 0,
	IsActive bit default 1,
	FK_Country int not null

	constraint Unique_mail unique (Mail),
	constraint Unique_login unique ([Login]),
	constraint FK_Country foreign key (FK_Country) references Country(CountryID)
)
