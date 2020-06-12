CREATE PROCEDURE [dbo].[GetEventsByArtist]
	@id int 
	
AS
	SELECT E.EventID, E.[Date], E.[Name],L.LocationID,L.[Name] as [location]
	FROM[Event] as E join [Location] as L on E.FK_Location = L.LocationID
	WHERE E.FK_Artist = @id
