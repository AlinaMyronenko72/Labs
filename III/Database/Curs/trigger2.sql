use testCurs1
go

CREATE TRIGGER rrr2 
ON Client 
AFTER INSERT, UPDATE   
AS RAISERROR ('Notify Customer Relations', 16, 10);  
GO  

insert into Client(Fam,Iniz,DateBirth,Phone) values ('ddd','ddds','2001-12-12','+380664534234')
select * from Client

create trigger trr1
on Payment
for insert,update
as
set nocount on
declare @price money,@sum money
set @price=(select Price from Tour)
set @sum=(select SumPayment from Payment)
if @price<>@sum
begin
	raiserror('nonnnnn',16,10)
	rollback transaction
end
go

insert into Payment (DatePayment,SumPayment)values