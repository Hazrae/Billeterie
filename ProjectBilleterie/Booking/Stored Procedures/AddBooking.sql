CREATE PROCEDURE [dbo].[AddBooking]
	@idUser int
	
AS
	insert into Booking ([Date], FK_User) OUTPUT inserted.BookingID
	values (GetDate(),@idUser)

