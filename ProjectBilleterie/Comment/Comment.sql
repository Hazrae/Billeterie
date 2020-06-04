CREATE TABLE [dbo].[Comment]
(
	CommentID int identity primary key,
	[Text] Varchar(400) not null,
	[Date] DATETIME2 not null,
	FK_User int not null,
	FK_Event int not null

	constraint FK_User_Comment foreign key (FK_User) references [User](UserID),
	constraint FK_Event_Comment foreign key (FK_Event) references [Event](EventID),

)
