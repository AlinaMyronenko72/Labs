use Curs4
go
create procedure hottour @date1 date='2022-05-27',@date2 date='2022-06-03', @name int output
as
select @name=count(NameTour)
from Term inner join Tour
on Term.TermID=Tour.TermID
where DateStart between @date1 and @date2


create procedure pricetour  @name nvarchar(50)='Франция',@min money output, @max money output,@count int output
as
select @min=min(Price),@max=max(Price),@count=count(*)
from Country inner join City
on Country.CountryID=City.CountryID
inner join Hotel
on City.CityID=Hotel.CityID
inner join Tour
on Hotel.HotelID=Tour.HotelID
where NameCountry=@name
