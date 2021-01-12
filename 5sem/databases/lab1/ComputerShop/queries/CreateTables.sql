create database ComputerShop;
go

use ComputerShop;
go

create table Countries
(
	CountryId int primary key identity,
    CountryName varchar(50) not null
)

create table Manufacturers
(
	ManufacturerId int primary key identity,
	ManufacturerName varchar(50) not null
)

create table ComponentTypes 
(
	ComponentTypeId int primary key identity,
	ComponentTypeName varchar(50) not null,
	ComponentTypeDescription varchar(200) not null
)

create table Components
(
	ComponentId int primary key identity,
	ComponentTypeId int references ComponentTypes(ComponentTypeId) on delete cascade not null,
	ComponentModel varchar(50) not null,
	ComponentManufacturerId int references Manufacturers(ManufacturerId) on delete cascade not null,
	ComponentCountryId int references Countries(CountryId) on delete cascade not null,
	ComponentReleaseDate date not null,
	ComponentCharacteristics varchar(200) not null,
	ComponentWarrantyInMonths int not null,
	ComponentDescription varchar(200) not null,
	ComponentPrice money not null
)

create table Customers
(
	CustomerId int primary key identity,
	CustomerFullName varchar(50) not null,
	CustomerAddress varchar(100) not null,
	CustomerPhoneNumber varchar(10) not null,
	CustomerDiscount int not null
)

create table Employees
(
	EmployeeId int primary key identity,
	EmployeeFullName varchar(50) not null,
	EmployeeWorkExperienceInMonth int not null
)

create table Services
(
	ServiceId int primary key identity,
	ServiceName varchar(50) not null,
	ServiceDescription varchar(200) not null,
	ServicePrice money not null
)

create table Orders
(
	OrderId int primary key identity,
	OrderStartDate date not null,
	OrderExecutionDate date not null,
	OrderCustomerId int references Customers(CustomerId) on delete cascade not null,
	OrderPrepayment money not null,
	OrderPaid bit not null,
	OrderFinished bit not null,
	OrderExecutingEmployeeId int references Employees(EmployeeId) on delete cascade not null
)

create table OrderServices
(
	OrderServiceId int primary key identity,
	OrderId int references Orders(OrderId) on delete cascade not null,
	ServiceId int references Services(ServiceId) on delete cascade not null
)

create table OrderComponents
(
	OrderComponentId int primary key identity,
	OrderId int references Orders(OrderId) on delete cascade not null,
	ComponentId int references Components(ComponentId) on delete cascade not null
)

