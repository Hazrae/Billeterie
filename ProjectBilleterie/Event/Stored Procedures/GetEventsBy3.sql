CREATE PROCEDURE [dbo].[GetEventsBy3]
	@offset int
	
AS
	SELECT EventID, E.[Name],E.[Date], A.[Name] as artist,A.ArtistID, A.Photo, L.[Name] as [location],L.LocationID
	FROM [Event] as E Join Artist as A on A.[ArtistID] = E.FK_Artist join [Location] as L on L.LocationID = E.FK_Location
	ORDER BY E.[Date] DESC
	OFFSET @offset ROWS
	FETCH NEXT 3 ROWS ONLY;

