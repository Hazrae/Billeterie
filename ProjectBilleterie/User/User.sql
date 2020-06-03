CREATE TABLE [dbo].[User]
(
	UserID int identity primary key,
	[Login] nvarchar(255) not null,
	[Password] varbinary(64) not null,
	Mail nvarchar(255) not null,
	BirthDate date not null,
	Address_Num int,
	Address_Street nvarchar(255),
	Address_City nvarchar(255),
	Address_ZIP int,
	CB_Num BIGINT,
	CB_Valid TIME,
	CB_Code VARBINARY(64),
	IsAdmin bit default 0,
	IsActive bit default 1,
	FK_Country int not null

	constraint Unique_mail unique (Mail),
	constraint Unique_login unique ([Login]),
	constraint FK_Country foreign key (FK_Country) references Country(CountryID)
)
