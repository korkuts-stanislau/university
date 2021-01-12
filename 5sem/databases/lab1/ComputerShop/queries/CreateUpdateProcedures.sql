use ComputerShop;
go

create procedure UpdateCountry
	@CountryId int,
	@CountryName varchar(50)
as
	begin
	if exists(select CountryId from Countries where CountryId = @CountryId)
	update Countries
	set CountryName = @CountryName
	where CountryId = @CountryId
	end
go

create procedure UpdateManufacturer
	@ManufacturerId int,
	@ManufacturerName varchar(50)
as
	begin
	if exists(select ManufacturerId from Manufacturers where ManufacturerId = @ManufacturerId)
	update Manufacturers
	set ManufacturerName = @ManufacturerName
	where ManufacturerId = @ManufacturerId
	end
go

create procedure UpdateComponentType
	@ComponentTypeId int,
	@ComponentTypeName varchar(50),
	@ComponentTypeDescription varchar(200)
as
	begin
	if exists(select ComponentTypeId from ComponentTypes where ComponentTypeId = @ComponentTypeId)
	update ComponentTypes
	set ComponentTypeName = @ComponentTypeName,
	ComponentTypeDescription = @ComponentTypeDescription
	where ComponentTypeId = @ComponentTypeId
	end
go

create procedure UpdateComponent
	@ComponentId int,
	@ComponentTypeId int,
	@ComponentModel varchar(50),
	@ComponentManufacturerId int,
	@ComponentCountryId int,
	@ComponentReleaseDate date,
	@ComponentCharacteristics varchar(200),
	@ComponentWarrantyInMonths int,
	@ComponentDescription varchar(200),
	@ComponentPrice money
as
	begin
	if exists(select ComponentId from Components where ComponentId = @ComponentId) and
	   exists(select ComponentTypeId from ComponentTypes where ComponentTypeId = @ComponentTypeId) and
	   exists(select ManufacturerId from Manufacturers where ManufacturerId = @ComponentManufacturerId) and
	   exists(select CountryId from Countries where CountryId = @ComponentCountryId)
	update Components
	set ComponentTypeId = @ComponentTypeId,
	ComponentModel = @ComponentModel,
	ComponentManufacturerId = @ComponentManufacturerId,
	ComponentCountryId = @ComponentCountryId,
	ComponentReleaseDate = @ComponentReleaseDate,
	ComponentCharacteristics = @ComponentCharacteristics,
	ComponentWarrantyInMonths = @ComponentWarrantyInMonths,
	ComponentDescription = @ComponentDescription,
	ComponentPrice = @ComponentPrice
	where ComponentId = @ComponentId
	end
go

create procedure UpdateCustomer
	@CustomerId int,
	@CustomerFullName varchar(50),
	@CustomerAddress varchar(100),
	@CustomerPhoneNumber varchar(10),
	@CustomerDiscount int
as
	begin
	if exists(select CustomerId from Customers where CustomerId = @CustomerId)
	update Customers
	set CustomerFullName = @CustomerFullName,
	CustomerAddress = @CustomerAddress,
	CustomerPhoneNumber = @CustomerPhoneNumber,
	CustomerDiscount = @CustomerDiscount
	where CustomerId = @CustomerId
	end
go

create procedure UpdateEmployee
	@EmployeeId int,
	@EmployeeFullName varchar(50),
	@EmployeeWorkExperienceInMonth int
as
	begin
	if exists(select EmployeeId from Employees where EmployeeId = @EmployeeId)
	update Employees
	set EmployeeFullName = @EmployeeFullName,
	EmployeeWorkExperienceInMonth = @EmployeeWorkExperienceInMonth
	where EmployeeId = @EmployeeId
	end
go

create procedure UpdateService
	@ServiceId int,
	@ServiceName varchar(50),
	@ServiceDescription varchar(200),
	@ServicePrice money
as
	begin
	if exists(select ServiceId from Services where ServiceId = @ServiceId)
	update Services
	set ServiceName = @ServiceName,
	ServiceDescription = @ServiceDescription,
	ServicePrice = @ServicePrice
	where ServiceId = @ServiceId
	end
go

create procedure UpdateOrder
	@OrderId int,
	@OrderStartDate date,
	@OrderExecutionDate date,
	@OrderCustomerId int,
	@OrderPrepayment money,
	@OrderPaid bit,
	@OrderFinished bit,
	@OrderExecutingEmployeeId int
as
	begin
	if exists(select OrderId from Orders where OrderId = @OrderId) and
	   exists(select CustomerId from Customers where CustomerId = @OrderCustomerId) and
	   exists(select EmployeeId from Employees where EmployeeId = @OrderExecutingEmployeeId)
	update Orders
	set OrderStartDate = @OrderStartDate,
	OrderExecutionDate = @OrderExecutionDate,
	OrderCustomerId = @OrderCustomerId,
	OrderPrepayment = @OrderPrepayment,
	OrderPaid = @OrderPaid,
	OrderFinished = @OrderFinished,
	OrderExecutingEmployeeId = @OrderExecutingEmployeeId
	where OrderId = @OrderId
	end
go

create procedure UpdateOrderComponent
	@OrderComponentId int,
	@OrderId int,
	@ComponentId int
as
	begin
	if exists(select OrderComponentId from OrderComponents where OrderComponentId = @OrderComponentId) and
	   exists(select OrderId from Orders where OrderId = @OrderId) and
	   exists(select ComponentId from Components where ComponentId = @ComponentId)
	update OrderComponents
	set OrderId = @OrderId,
	ComponentId = @ComponentId
	where OrderComponentId = @OrderComponentId
	end
go

create procedure UpdateOrderService
	@OrderServiceId int,
	@OrderId int,
	@ServiceId int
as
	begin
	if exists(select OrderServiceId from OrderServices where OrderServiceId = @OrderServiceId) and
	   exists(select OrderId from Orders where OrderId = @OrderId) and
	   exists(select ServiceId from Services where ServiceId = @ServiceId)
	update OrderServices
	set OrderId = @OrderId,
	ServiceId = @ServiceId
	where OrderServiceId = @OrderServiceId
	end