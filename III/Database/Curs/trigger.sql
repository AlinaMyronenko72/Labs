use Curs4
go
create trigger trr1
on Client
for insert ,update
as
set nocount on
declare @fam nvarchar(30),@iniz nvarchar(4),@datebirth date,@phone nvarchar(13)
set @fam=(select Fam from inserted)
set @iniz=(select Iniz from inserted)
set @datebirth=(select DateBirth from inserted)
set @phone=(select Phone from inserted)
if exists(select * from Client where (Fam=@fam and Iniz=@iniz and DateBirth=@datebirth and Phone=@phone)
having count(*)>1)
begin
	raiserror ('“акой клиент уже существует!',16,10)
	rollback transaction
end

create trigger trr2
on Client
after delete
as
raiserror('¬ы удалили клиента из базы данных!',16,10)
go


create trigger trr3
on Client
for insert, update
as
set nocount on
declare @db date,@db1 date='2006-01-01'
set @db=(select DateBirth from inserted)
if @db>@db1
begin
	raiserror (' лиент, которому нет 16 лет, не может быть внесен в базу данных!',16,10)
	rollback transaction
end


