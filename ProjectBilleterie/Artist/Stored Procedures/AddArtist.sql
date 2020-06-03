CREATE PROCEDURE [dbo].[AddArtist]
	@name nvarchar(255),
	@desc nvarchar(255),
	@photo nvarchar(255)
AS
	Insert into Artist ([Name],[Desc],Photo) 
	VALUES (@name,
			@desc,
			@photo)
