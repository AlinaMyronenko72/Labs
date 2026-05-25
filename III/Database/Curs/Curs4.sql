use master
go
if exists (Select * from sys.databases where name='Curs4')
begin
   alter database Curs4 set single_user with rollback immediate
   drop database Curs4
end
go
create database Curs4
go
use Curs4
go
create table Client
(
	ClientID int not null identity(1,1) Primary key,
	Fam nvarchar(30) not null,
	Iniz nvarchar(4) null,
	DateBirth date not null,
	Phone nvarchar(13) not null
)
go
insert into Client(Fam,Iniz,DateBirth,Phone) values('Иванов','В.П','1993-02-16','+380662536727')
insert into Client(Fam,Iniz,DateBirth,Phone) values('Шептько','К.П','1995-04-23','+380955986106')
insert into Client(Fam,Iniz,DateBirth,Phone) values('Кирнева','А.М','1985-11-04','+380935609543')
insert into Client(Fam,Iniz,DateBirth,Phone) values('Олипова','Ю.Д','1967-07-07','+380996499988')
insert into Client(Fam,Iniz,DateBirth,Phone) values('Корнев','В.М','1956-01-01','+380673357611')
insert into Client(Fam,Iniz,DateBirth,Phone) values('Аликова','А.А','2000-12-17','+380666555456')
insert into Client(Fam,Iniz,DateBirth,Phone) values('Мечников','Д.А','1990-06-10','+380951666489')
insert into Client(Fam,Iniz,DateBirth,Phone) values('Цепков','К.Е','2001-03-24','+380965334788')
insert into Client(Fam,Iniz,DateBirth,Phone) values('Ульникова','М.Р','1979-09-27','+380971213245')
go
create table Payment
(
	PaymentID int not null identity(1,1) Primary key,
	DatePayment date null,
	SumPayment money not null
)
go
insert into Payment(DatePayment,SumPayment) values('2022-05-01',20000)
insert into Payment(DatePayment,SumPayment) values(null,15000)
insert into Payment(DatePayment,SumPayment) values('2022-05-01',30000)
insert into Payment(DatePayment,SumPayment) values('2022-05-05',45000)
insert into Payment(DatePayment,SumPayment) values(null,30000)
insert into Payment(DatePayment,SumPayment) values('2022-04-01',10000)
insert into Payment(DatePayment,SumPayment) values('2022-04-17',9000)
insert into Payment(DatePayment,SumPayment) values('2022-05-10',57000)
insert into Payment(DatePayment,SumPayment) values('2022-03-26',90000)

go
create table TypeTransp
(
	TypeTranspID int not null identity(1,1) Primary key,
	TypeTransp nvarchar(20) not null
)
go
insert into TypeTransp(TypeTransp) values('Самолет')
insert into TypeTransp(TypeTransp) values('Автобус')
go
create table Term
(
	TermID int not null identity(1,1) Primary key,
	DateStart date not null,
	DateEnd date not null
)
go
insert into Term(DateStart,DateEnd) values ('2022-09-03','2022-09-10')
insert into Term(DateStart,DateEnd) values ('2022-06-01','2022-06-14')
insert into Term(DateStart,DateEnd) values ('2022-07-05','2022-07-12')
insert into Term(DateStart,DateEnd) values ('2022-08-20','2022-08-30')
insert into Term(DateStart,DateEnd) values ('2022-06-09','2022-06-19')
insert into Term(DateStart,DateEnd) values ('2022-07-17','2022-07-22')
insert into Term(DateStart,DateEnd) values ('2022-06-27','2022-07-07')
insert into Term(DateStart,DateEnd) values ('2022-06-20','2022-07-10')
go
create table Country
(
	CountryID int not null identity(1,1) Primary key,
	NameCountry nvarchar(30) not null
)
go
insert into Country(NameCountry) values ('Украина')
insert into Country(NameCountry) values ('Египет')
insert into Country(NameCountry) values ('Турция')
insert into Country(NameCountry) values ('Франция')
insert into Country(NameCountry) values ('Испания')
insert into Country(NameCountry) values ('Греция')
go
create table Food
(
	FoodID int not null identity(1,1) Primary key,
	TypeFood nvarchar(30) not null default 'Все включено'
)
go
insert into Food(TypeFood) values ('Только завтраки')
insert into Food(TypeFood) values ('Завтрак и обед')
insert into Food(TypeFood) values ('Все включено')
go
create table City
(
	CityID int not null identity(1,1) Primary key,
	CountryID int not null,
	NameCity nvarchar(30) not null
	Foreign key (CountryID) references Country(CountryID)
)
go
insert into City(CountryID,NameCity) values (1,'Киев')
insert into City(CountryID,NameCity) values (1,'Харьков')
insert into City(CountryID,NameCity) values (1,'Днепр')
insert into City(CountryID,NameCity) values (2,'Каир')
insert into City(CountryID,NameCity) values (2,'Хургада')
insert into City(CountryID,NameCity) values (3,'Аланья')
insert into City(CountryID,NameCity) values (3,'Анталия')
insert into City(CountryID,NameCity) values (4,'Париж')
insert into City(CountryID,NameCity) values (4,'Лион')
insert into City(CountryID,NameCity) values (5,'Валенсия')
insert into City(CountryID,NameCity) values (5,'Мадрид')
insert into City(CountryID,NameCity) values (6,'Афины')
insert into City(CountryID,NameCity) values (5,'Ханья')


go
create table Hotel
(
	HotelID int not null identity(1,1) Primary key,
	CityID int not null,
	FoodID int not null,
	NameHotel nvarchar(50) not null,
	Star int not null check(Star>=1 and Star<=5)
	Foreign key (CityID) references City(CityID),
	Foreign key (FoodID) references Food(FoodID)
)
go
insert into Hotel(CityID,FoodID,NameHotel,Star) values(4,3,'Savoy',5)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(5,1,'Sunrise Arabian Beach Resort',4)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(5,2,'Aqua Blu Resort',5)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(6,3,'Saphir Hotel',4)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(7,2,'Hilton',5)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(7,3,'Incekum Beach Resort',5)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(8,3,'Generator Paris',4)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(8,3,'Four Seasons',5)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(9,1,'Pullman',5)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(10,1,'Sixtytwo',3)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(11,2,'The Corner Hotel',4)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(11,3,'Vincci Soho',5)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(12,2,'Lardos Bay',4)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(12,1,'FarOut Beach Club',3)
insert into Hotel(CityID,FoodID,NameHotel,Star) values(13,1,'Angsana Corfu',5)

go
create table Tour
(
	TourID int not null identity(1,1) Primary key,
	TermID int not null,
	HotelID int not null,
	NameTour nvarchar(50) not null,
	Price money not null
	Foreign key (TermID) references Term(TermID),
	Foreign key (HotelID) references Hotel(HotelID)
)
go
insert into Tour (TermID,HotelID,NameTour,Price) values (1,8,'Погулки по Парижу',45000)
insert into Tour (TermID,HotelID,NameTour,Price) values (2,6,'Золотое кольцо Турции',20000)
insert into Tour (TermID,HotelID,NameTour,Price) values (3,12,'Оздоровительный тур в Испанию',10000)
insert into Tour (TermID,HotelID,NameTour,Price) values (4,13,'Незабываемый отдых для двоих в Греции',30000)
insert into Tour (TermID,HotelID,NameTour,Price) values (5,15,'Отдых на острове в Греции',30000)
insert into Tour (TermID,HotelID,NameTour,Price) values (6,1,'Екскурсии по Египту',9000)
insert into Tour (TermID,HotelID,NameTour,Price) values (7,9,'Романтическая поездка в Лион',90000)
insert into Tour (TermID,HotelID,NameTour,Price) values (8,4,'Отдых на берегу Турции',30000)
insert into Tour (TermID,HotelID,NameTour,Price) values (7,3,'Расслабляющая поездка в Египет',57000)
insert into Tour (TermID,HotelID,NameTour,Price) values (6,10,'Спортивная поездка в Испанию',15000)
go
create table Transp
(
	TranspID int not null identity(1,1) Primary key,
	CityID int not null,
	TypeTranspID int not null,
	NumberTransp nvarchar(15) not null,
	TimeTo time not null,
	TimeBack time not null
	Foreign key (CityID) references City(CityID),
	Foreign key (TypeTranspID) references TypeTransp(TypeTranspID)
)
go
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (1,2,'AA3678AK','12:00:00','09:00:00')
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (2,1,'UR-36123','06:30:00','05:40:00')
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (3,2,'AE3877AK','17:00:00','06:30:00')
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (1,1,'UR-65785','08:55:00','09:00:00')
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (2,1,'UR-55775','07:35:00','10:30:00')
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (3,1,'UR-08364','12:00:00','06:27:00')
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (1,2,'AA3499AK','15:30:00','04:00:00')
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (2,1,'UR-12345','20:00:00','20:40:00')
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (3,1,'UR-34789','21:53:00','06:46:00')
insert into Transp (CityID,TypeTranspID,NumberTransp,TimeTo,TimeBack)values (1,2,'AA1234AK','16:00:00','07:30:00')

go
create table Voucher
(
	VoucherID int not null identity(1,1) Primary key,
	ClientID int not null,
	PaymentID int not null,
	TourID int not null,
	TranspID int not null
	Foreign key (ClientID) references Client(ClientID),
	Foreign key (PaymentID) references Payment(PaymentID),
	Foreign key (TourID) references Tour(TourID),
	Foreign key (TranspID) references Transp(TranspID)
)
go
insert into Voucher (ClientID,PaymentID,TourID,TranspID) values (1,6,3,3)
insert into Voucher (ClientID,PaymentID,TourID,TranspID) values (2,3,5,5)
insert into Voucher (ClientID,PaymentID,TourID,TranspID) values (3,8,9,9)
insert into Voucher (ClientID,PaymentID,TourID,TranspID) values (4,2,10,10)
insert into Voucher (ClientID,PaymentID,TourID,TranspID) values (5,5,8,8)
insert into Voucher (ClientID,PaymentID,TourID,TranspID) values (6,9,7,7)
insert into Voucher (ClientID,PaymentID,TourID,TranspID) values (7,7,6,6)
insert into Voucher (ClientID,PaymentID,TourID,TranspID) values (8,4,1,1)
insert into Voucher (ClientID,PaymentID,TourID,TranspID) values (9,1,2,2)
go
alter database Curs4 set multi_user
go

