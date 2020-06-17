CREATE PROCEDURE [dbo].[AddBookingTicket]
	@idTicket int,
	@idBooking int,
	@qty int
	
AS
	insert into BookingTicket(Qty, FK_BookingSelection, FK_Ticket)
	values (@qty,@idBooking,@idTicket)
