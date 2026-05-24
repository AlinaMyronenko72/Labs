use Curs4
go
create view tourview
as
select NameTour,NameHotel,Star,TypeFood,NameCountry,NameCity,DateStart,DateEnd,Price
from Country inner join City
on Country.CountryID=City.CountryID
inner join Hotel
on City.CityID=Hotel.CityID
inner join Tour
on Hotel.HotelID=Tour.HotelID
inner join Term
on Term.TermID=Tour.TermID
inner join Food
on Food.FoodID=Hotel.FoodID

create view payview
as
select Fam,Iniz,Phone,NameTour,SumPayment,DatePayment
from Tour inner join Voucher
on Tour.TourID=Voucher.TourID
inner join Client
on Client.ClientID=Voucher.ClientID
inner join Payment
on Payment.PaymentID=Voucher.PaymentID

create view voucherview
as
select Fam,Iniz,NameTour,NameHotel,Price,DatePayment,NameCountry,TypeTransp,NumberTransp,DateStart,DateEnd
from Client inner join Voucher
on Client.ClientID=Voucher.ClientID
inner join Payment
on Voucher.PaymentID=Payment.PaymentID
inner join Transp
on Transp.TranspID=Voucher.TranspID
inner join TypeTransp
on TypeTransp.TypeTranspID=Transp.TypeTranspID
inner join Tour
on Tour.TourID=Voucher.TourID
inner join Hotel
on Hotel.HotelID=Tour.HotelID
inner join Term
on Term.TermID=Tour.TermID
inner join City
on City.CityID=Hotel.CityID
inner join Country
on Country.CountryID=City.CountryID


select * from voucherview