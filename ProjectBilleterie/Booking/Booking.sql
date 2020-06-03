CREATE TABLE [dbo].[Booking]
(
	BookingID int identity primary key,
	[Date] date,
	FK_User int not null,
	FK_Event int not null

	constraint FK_User_Booking foreign key (FK_User) references [User](UserID),
	constraint FK_Event_Booking foreign key (FK_Event) references [Event](EventID)
)
