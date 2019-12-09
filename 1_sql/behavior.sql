use AdventureWorks2017;
go 


-- view 
create view vw_Person 
as 
select firstname, lastname
from Person.Person;
go


alter view vw_Person with SCHEMABINDING
as 
select firstname, lastname
from Person.Person;
go


select * from vw_Person;
go

-- function 
-- Tabular Function
create function fn_Person(@first nvarchar(50))
returns table    --return type
as
return           --the actual return 
select firstname, lastname
from Person.Person
where FirstName = @first;
GO

-- Scalar Function 
create function fn_FullName(@first nvarchar(50), @middle nvarchar(50), @last nvarchar(50))
returns nvarchar(200) -- lower limit is 152
as 
begin 
    --return @first + ' ' + @middle + ' ' + @last
    return @first + coalesce(' ' + @middle, '', null, null) + ' ' + @last
    --return @first + isnull(' ' + @middle, '') + ' ' + @last

end;
go



select dbo.fn_FullName(firstname, null, lastname) as "Full Name" from fn_Person('Joshua');
go


-- Stored Procedures --used to clean raw data from db table i.e. removing the nulls in our db 
create procedure sp_InsertName(@first nvarchar(50), @middle nvarchar(500), @last nvarchar(50))
as 
begin 
    begin tran
        begin try 
            declare @mName nvarchar(50) = @middle;
            if(@middle is null)
            begin 
                set @mName = ''
            end

            checkpoint --savepoint 

            insert into Person.Person(FirstName, MiddleName, LastName)
            values (@first, @mName, @last)


            commit tran
        end TRY

        begin catch 
            print error_message()
            print error_line()
            print error_severity()
            print error_state()
            print error_number()
            rollback tran
        end catch 
end;

execute sp_InsertName 'fred', null, 'belotte';
go;

--trigger 
create trigger tr_InsertName 
on Person.Person
instead of insert
as
update pp
set firstname = inserted.firstname
from Person.Person as pp
where pp.BusinessEntityID = inserted.BusinessEntityID;