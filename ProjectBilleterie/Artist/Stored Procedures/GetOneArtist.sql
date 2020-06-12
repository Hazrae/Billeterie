CREATE PROCEDURE [dbo].[GetOneArtist]
	@id int
AS
	SELECT * FROM Artist WHERE ArtistID = @id;
