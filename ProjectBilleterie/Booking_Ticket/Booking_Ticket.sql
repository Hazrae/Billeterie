CREATE TABLE [dbo].[BookingTicket]
(
	BookingTicketID int identity primary key,
	Qty int not null,
	FK_Ticket int not null,
	FK_BookingSelection int not null

	constraint FK_Ticket_Booking foreign key (FK_Ticket) references Ticket(TicketID),
	constraint FK_BookingSelection_Ticket foreign key (FK_BookingSelection) references BookingSelection(BookingSelectionID)

	

)
