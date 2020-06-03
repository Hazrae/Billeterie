CREATE TABLE [dbo].[Country]
(
	CountryID int identity Primary key,
	[Name] nvarchar(255) not null unique

	constraint Unique_Name_Country unique ([Name])
)
