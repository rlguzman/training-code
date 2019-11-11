use AdventureWorks2017;
go 

-- select 
select *
from Person.Person;

select firstname, lastname, middlename
from person.person;

select firstname, lastname, middlename
from person.person 
where FirstName = 'robert';

select firstname, lastname, middlename
from person.person
where FirstName = 'robert' or FirstName = 'john';

select firstname, lastname, middlename
from person.person
where FirstName <> 'robert' or not FirstName = 'john';

select firstname, lastname, middlename
from person.person
where FirstName <> 'robert' and FirstName <> 'john';

select firstname, lastname, middlename
from person.person
where FirstName like  '%robert%' or FirstName like 'r___' or FirstName like 'r[aeoi]%';

select firstname, LastName
from person.person
where FirstName = 'robert' or FirstName = 'john'
group by FirstName, LastName;

select count(*) as "amount of", firstname, LastName
from person.person
where FirstName = 'robert' or FirstName = 'john'
group by FirstName, LastName;


select count(*) as "amount of", firstname, LastName
from person.person
where FirstName = 'robert' or FirstName = 'john' 
group by FirstName, LastName
having count(*) > 1
order by LastName asc, FirstName desc;

--mode of execution / method of execution 
/*
FROM
WHERE
GROUP BY
HAVING 
SELECT 
ORDER BY
*/


--insert 

select * from Person.Address

insert into Person.Address
values ('UT',	NULL, 'Arlingtons', 79, 76010,	0xE6100000010CAE8BFC28BCE4474067A89189898A5EC0, '9aadcb0d-36cf-483f-84d8-585c2d4ec6ea', 2019-12-04)

select *
from Person.Address
where AddressLine1 = 'UT';

insert into Person.Address(AddressLine2, AddressLine1, City, StateProvinceID, PostalCode, SpatialLocation, rowguid, ModifiedDate )
values 
('UT',	'12354', 'Arlingtons', 79, 76010,	0xE6100000010CAE8BFC28BCE4474067A89189898A5EC0, '9aadcb0d-36cf-483f-84d8-585c2d4ec6ea0', 2019-12-04)
-- ,()
-- ,()

insert into Person.Address
select AddressLine1, AddressLine2, City, StateProvinceID, PostalCode, SpatialLocation, rowguid, ModifiedDate
from AdventureWorks2017.Person.Address
where AddressLine1 = 'UT';


-- insert into Person.Address from FILENAME 'data.csv' with (rowterminator = '\n', fieldterminator= ',')
bulk insert Person.Address from 'data.csv' with (rowterminator= '\n', fieldterminator= ',');



-- update
update person.Person
set firstname = 'john'
where FirstName = 'robert';


update pp
set firstname = 'robert'
from person.person as pp
where pp.LastName = 'jones';


-- delete 
delete 
from Person.Person
where MiddleName is null and FirstName='xavier';


-- join

select pp.firstname,ssoh.orderdate, pp.lastname, prp.Name, pa.addressline1, pa.city, pa.PostalCode
from person.person as pp
inner join person.BusinessEntityAddress as pbea ON pbea.BusinessEntityID = pp.BusinessEntityID
inner join person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pbea.BusinessEntityID
inner join sales.SalesOrderHeader as ssoh on ssoh.CustomerID = sc.CustomerID
inner join sales.SalesOrderDetail as ssod on ssod.SalesOrderDetailID = ssoh.SalesOrderID
inner join Production.Product as prp on prp.ProductID = ssod.ProductID
where pp.FirstName = 'Jimmy' and prp.name like '%tire%'
-- where pp.FirstName = 'Jimmy' and datepart([MONTH],ssoh.OrderDate) = 7 and month(ssoh.OrderDate)=7;




select pp.firstname, pp.lastname, prp.Name, pa.addressline1, pa.city, pa.PostalCode
from person.person as pp
inner join person.BusinessEntityAddress as pbea ON pbea.BusinessEntityID = pp.BusinessEntityID
inner join person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pbea.BusinessEntityID
inner join
(
    select salesorderid, customerid
    from sales.SalesOrderHeader
    where datepart(month, orderdate) = 7
) as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderID
inner join 
(
    select productid, name
    from Production.Product
    where name like '%tire%'
) as prp on prp.ProductID = ssod.ProductID
where pp.FirstName = 'Jimmy' and prp.name like '%tire%';


with OrderHeader as 
(
    select salesorderid, customerid
    from sales.SalesOrderHeader
    where datepart(month, orderdate) = 7    
),
Product as 
(
    select productid, name
    from Production.Product
    where name like '%tire%'    
)
select pp.firstname, pp.lastname, prp.Name, pa.addressline1, pa.city, pa.PostalCode
from person.person as pp
inner join person.BusinessEntityAddress as pbea ON pbea.BusinessEntityID = pp.BusinessEntityID
inner join person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pbea.BusinessEntityID
inner join OrderHeader as ssoh on ssoh.CustomerID = sc.CustomerID
inner join sales.SalesOrderDetail as ssod on ssod.SalesOrderDetailID = ssoh.SalesOrderID
inner join Product as prp on prp.ProductID = ssod.ProductID
where pp.FirstName = 'Jimmy' and prp.name like '%tire%'



select pp.firstname, pp.lastname    
from person.person as pp
where pp.FirstName = pp.LastName;


-- preferred by logic
select distinct pp1.firstname , pp2.lastname
from person.person as pp1
inner join person.person as pp2  on pp2.lastname = pp1.firstname


-- preferred by sql
select firstname
from person.Person
intersect
select lastname 
from person.person;