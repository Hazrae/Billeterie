use BilleterieDB;

insert into Artist ([Name], [Desc], Photo) 
values 
('Slipknot','Un groupe de métal qui déchire','https://www.touslesfestivals.com/caches/d5837d4e4deccb841203f20b1819ad6bc2327426-1040x540-outbound.jpg'),
('Bernard Minet','The one and only','https://i.ytimg.com/vi/rbg-InH7EGo/maxresdefault.jpg'),
('Five Finger Death Punch','Du gros métal bien barbu','https://www.lagrosseradio.com/_images/fck/62074.jpg'),
('Didier Super','Il faut de tout pour faire un monde','https://i.ytimg.com/vi/6TuE4nYFP6g/hqdefault.jpg')
go

insert into Location([Name], [Desc])
values
('Forest National','Ha bah c''est une bien belle salle ça madame'),
('Country Hall','Ha bah c''est une bien belle salle ça madame'),
('Salle des fêtes de Quimquempoix-les-deux-arbres','Ha bah c''est une bien belle salle ça madame'),
('Ton cul','Ha bah c''est une bien belle salle ça madame')
go

insert into Ticket(Category, QtyAvailable,Price,FK_Location)
values
('cat 1',69,20,1),
('cat 1',69,20,2),
('cat 1',69,20,3),
('cat 1',69,25,4),
('cat 2',10,45,1),
('cat 2',10,51,2),
('cat 2',10,52.5,3),
('cat 2',10,64.7,4),
('cat 3',15,100,1),
('cat 3',16,102.5,2),
('cat 3',17,110,3),
('cat 3',18,252.9,4)
go

insert into [Event]([Date],[Name],FK_Location,FK_Artist)
values
('2020-10-10','Event génial',1,1),
('2020-2-20','Encore un event génial',2,2),
('2020-10-20','Concert génial',1,2),
('2020-10-21','Festival génial',3,3),
('2022-1-20','Guinguette géniale',3,4),
('2021-10-20','Event pas top',4,4)
go

insert into Country ([Name])
values
('Germany'),
('Belgium'),
('France'),
('Ukraine'),
('Zanarkand'),
('Midgard'),
('England'),
('Your Ass')
go

insert into [User] ([Login],[Password],Mail,BirthDate,FK_Country,IsActive,IsAdmin)
values
('test',HASHBYTES('SHA2_512',dbo.Salt() +'test'),'test@test.com','1980-10-10',3,1,0),
('test1',HASHBYTES('SHA2_512',dbo.Salt() +'test1'),'test1@test.com','1980-10-18',3,1,0),
('test2',HASHBYTES('SHA2_512',dbo.Salt() +'test2'),'test2@test.com','1980-10-8',2,0,0),
('Hazrae',HASHBYTES('SHA2_512',dbo.Salt() +'Hazrae'),'kevinvoneche@gmail.com','1988-11-10',2,1,1)
go

insert into Comment ([Text], [Date],FK_User,FK_Event)
values
('j''adore les saucisses lentilles!', '2020-6-10',4,1),
('j''adore les poireaux!', '2020-06-9',2,2),
('j''adore les pâtes!', '2020-4-10',3,5)
go

insert into Booking ([Date], FK_User)
values
('2020-6-10',1),
('2020-6-4',2),
('2020-10-10',3),
('2020-6-15',4)
go

insert into BookingSelection(FK_Event,FK_Booking)
values
(1,1),
(2,2),
(3,1),
(2,3),
(1,4)

insert into BookingTicket(Qty,FK_Ticket,FK_BookingSelection)
values
(2,3,1),
(2,5,1),
(2,7,2),
(2,10,3)
go




