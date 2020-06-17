CREATE TABLE [dbo].[BookingSelection]
(
	BookingSelectionID int identity primary key,
	FK_Event int not null,
	FK_Booking int not null,
	FK_BookingTicket int not null

	constraint FK_Event_Booking foreign key (FK_Event) references [Event](EventID)
	constraint FK_Booking_Selection foreign key (FK_Booking) references [Booking](BookingID)
	constraint FK_Booking_Ticket foreign key (FK_BookingTicket) references [Ticket](TicketID)

)
