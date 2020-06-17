CREATE TABLE [dbo].[BookingTicket]
(
	BookingTicketID int identity primary key,
	Qty int not null,
	FK_Ticket int not null,

	constraint FK_Ticket_Booking foreign key (FK_Ticket) references Ticket(TicketID)
	

)
