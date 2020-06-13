CREATE PROCEDURE [dbo].[GetEventsByArtist]
	@id int 
	
AS
	SELECT A.[Desc], A.[Name], A.Photo, E.EventID, E.[Date], E.[Name] as [event],L.LocationID,L.[Name] as [location]
	FROM Artist as A join[Event] as E on A.ArtistID = E.FK_Artist join [Location] as L on E.FK_Location = L.LocationID
	WHERE A.ArtistID = @id
