CREATE TABLE [dbo].[BookingTicket]
(
	BookingTicketID int identity primary key,
	Qty int not null,
	FK_Ticket int not null,
	FK_Booking int not null

	constraint FK_Ticket_Booking foreign key (FK_Ticket) references Ticket(TicketID),
	constraint FK_Booking_Ticket foreign key (FK_Booking) references Booking(BookingID),

)
