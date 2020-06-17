CREATE PROCEDURE [dbo].[GetBookingDetails]
	@id int
	
AS
	SELECT A.ArtistID,A.[Name] as Artist,
		   E.[Name] as [Event],E.[Date],E.EventID,
		   L.[Name] as [Location],L.[Desc],
		   T.TicketID,T.Category,T.Price--,T.QtyAvailable-(SELECT COUNT(*) FROM BookingTicket join Booking on BookingTicket.FK_Booking = Booking.BookingID WHERE Booking.FK_Event = @id) as QtyAvailable

	FROM [Event] as E join Artist as A on E.FK_Artist = A.ArtistID join [Location] as L on E.FK_Location = L.LocationID join Ticket as T on L.LocationID = T.FK_Location  
	WHERE EventID = @id

