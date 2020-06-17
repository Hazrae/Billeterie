CREATE PROCEDURE [dbo].[AddBookingSelection]
	@idBooking int,
	@idEvent int
	
AS
	insert into BookingSelection(FK_Booking, FK_Event) output inserted.BookingSelectionID
	values (@idBooking,@idEvent)
