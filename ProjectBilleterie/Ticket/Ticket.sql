CREATE TABLE [dbo].[Ticket]
(
	TicketID int identity primary key,
	Category varchar(255) not null,
	QtyAvailable int not null,
	Price float not null,
	FK_Location int not null

	constraint FK_Location_Ticket foreign key (FK_Location) references [Location](LocationID)
)
