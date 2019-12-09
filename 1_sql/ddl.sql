use master;
 go 

--  create
create database PizzaBox;
go 

create schema [Order];
GO

create schema Accounts;
GO

create table [Order].[Order]
(
    OrderId int not null identity(1,2) --primary key
    ,UserId int not null --foreign key references Account.User.UserId
    ,StoreId int not null --foreign key
    ,Totalcost numeric(3,2) not null
    ,OrderDate datetime2(7) not null --computed
    ,Active bit not null --checked constraint
    ,constraint PK_Order_OrderId primary key (OrderId)
    -- ,constraint FK_Order_UserId foreign key (UserId) references Account.User(UserId)
);

create table [Order].[OrderPizza]
(
    OrderPizzaId int not null identity(1,2)
    ,OrderId int not null 
    ,PizzaId int not null 
)

create table [Order].[Pizza]
(
    PizzaId int not null identity(1,2) -- primary key
    ,SizeId int not null --FOREIGN
    ,CrustID int not null --FOREIGN
    ,Price decimal(2,2) not null
    ,Active bit not null
);

-- alter
alter table [Order].[Order]
    add CONSTRAINT PK_Order_OrderId primary key (OrderId);

alter table [Order].[OrderPizza]
    add CONSTRAINT PK_OrderPizza_OrderPizzaId primary key (OrderPizzaId);

alter table [Order].[Pizza]
    add CONSTRAINT PK_Pizza_PizzaId primary key (PizzaId);

alter table[Order].[OrderPizza]
    add CONSTRAINT FK_OrderPizza_OrderId FOREIGN key (OrderId) references [Order].[Order](OrderId);

alter table[Order].[OrderPizza]
    add CONSTRAINT FK_OrderPizza_OrderId FOREIGN key (PizzaId) references [Order].[Order](PizzaId);

alter table [Order].[Order]
    add constraint DF_Order_Active default (1) for Active;

alter table [Order].[Pizza]
    add constraint DF_Pizza_Active default (1) for Active;

alter table [Order].[Order]
    add constraint CK_Order_OrderDate check (OrderDate >= '2019-01-01');

alter table [Order].[Order]
    drop constraint CK_Order_OrderDate;  --removing constraints 

alter table [Order].[Order]
    add TipAmount decimal(2,2) null

alter table [Order].[Order]
    drop column TipAmount;