CREATE TABLE [dbo].[Booking]
(
	BookingID int identity primary key,
	[Date] DATETIME2,
	FK_User int not null

	constraint FK_User_Booking foreign key (FK_User) references [User](UserID),
)
