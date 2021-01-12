use ComputerShop;
go

create view GetAllComponentsInfo
	as
	select CT.ComponentTypeName, CT.ComponentTypeDescription, C.ComponentModel, M.ManufacturerName, CNT.CountryName,
		   C.ComponentReleaseDate, C.ComponentCharacteristics, C.ComponentWarrantyInMonths, C.ComponentDescription,
		   C.ComponentPrice
	from Components as C join
		 ComponentTypes as CT on C.ComponentTypeId = CT.ComponentTypeId join
		 Manufacturers as M on C.ComponentManufacturerId = M.ManufacturerId join
		 Countries as CNT on C.ComponentCountryId = CNT.CountryId