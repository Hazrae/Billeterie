﻿CREATE PROCEDURE [dbo].[GetAllArtist]
AS
	SELECT Artist.ArtistID, Artist.[Name], Artist.Photo 
	From Artist
	Order by Artist.[Name] ASC