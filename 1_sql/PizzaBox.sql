CREATE TABLE [Users] (
  [UserId] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [FirstName] nvarchar(255) NOT NULL,
  [LastName] nvarchar(255) NOT NULL,
  [AddressId] int NOT NULL,
  [UserTypeId] int NOT NULL
)
GO

CREATE TABLE [UserType] (
  [UserTypeId] int NOT NULL,
  [Type] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Account] (
  [AccountId] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [UserName] nvarchar(255) NOT NULL,
  [Password] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [AddressId] nvarchar(255) NOT NULL,
  [CreatedAt] timestamp NOT NULL
)
GO

CREATE TABLE [Address] (
  [AddressId] int NOT NULL,
  [Street] nvarchar(255) NOT NULL,
  [City] nvarchar(255) NOT NULL,
  [State] nvarchar(255) NOT NULL,
  [PostalCode] int NOT NULL
)
GO

CREATE TABLE [Store] (
  [StoreId] int PRIMARY KEY NOT NULL,
  [StoreName] nvarchar(255) NOT NULL,
  [AddressId] int NOT NULL,
  [AdminId] int NOT NULL
)
GO

CREATE TABLE [Employee] (
  [EmployeeId] int NOT NULL,
  [StoreId] int NOT NULL,
  [UserId] int NOT NULL
)
GO

CREATE TABLE [Order] (
  [OrderId] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [StoreId] int NOT NULL,
  [TotalCost] numeric(3,2) NOT NULL,
  [CompleteStatus] bit,
  [OrderDate] datetime(7) NOT NULL
)
GO

CREATE TABLE [Pizza] (
  [PizzaId] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [SizeId] int NOT NULL,
  [CrustId] int NOT NULL,
  [SauceId] int NOT NULL,
  [Price] decimal(2,2) NOT NULL,
  [Status] bit NOT NULL
)
GO

CREATE TABLE [OrderPizza] (
  [OrderId] int NOT NULL,
  [PizzaId] int NOT NULL
)
GO

CREATE TABLE [Size] (
  [SizeId] int NOT NULL,
  [Size] nvarchar(255) NOT NULL CHECK ([Size] IN ('Small', 'Medium', 'Large')),
  [Price] de
)
GO

CREATE TABLE [Crust] (
  [CrustId] int NOT NULL,
  [Crust] nvarchar(255) NOT NULL CHECK ([Crust] IN ('Regular', 'ThinCrust', 'StuffedCrust', 'DeepDish'))
)
GO

CREATE TABLE [Sauce] (
  [SauceId] int NOT NULL,
  [Sauce] nvarchar(255) NOT NULL CHECK ([Sauce] IN ('ClassicMarinara', 'Buffalo', 'Pesto', 'Alfredo'))
)
GO

CREATE TABLE [Toppings] (
  [ToppingsId] int NOT NULL,
  [Topping] nvarchar(255) NOT NULL CHECK ([Topping] IN ('PineApple', 'Pepperoni', 'Sausage', 'Onions', 'Ham'))
)
GO
