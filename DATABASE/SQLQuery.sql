/****** Script for SelectTopNRows command from SSMS  ******/



Create table customer
(
	customerId nchar(50) NOT NULL Primary Key,
	name nchar(50) NOT NULL ,
	userName nchar(50) NOT NULL ,
	password nchar(50) NOT NULL,
	address nchar(100) NOT NULL ,
	phone nchar(50) NOT NULL ,
	gender nchar(50) NOT NULL ,
	photo nchar(255) NULL,
	status tinyint NOT NULL DEFAULT 1,
);
Select * from customer;


Create table admin
(
	adminId nchar(50) NOT NULL  Primary Key,
	name nchar(50) NOT NULL,
	userName nchar(50) NOT NULL ,
	password nchar(50) NOT NULL ,
	address nchar(100) NOT NULL,
	phone nchar(50) NOT NULL,
	gender nchar(50) NOT NULL,
	photo nchar(255) NULL,
	status tinyint NOT NULL DEFAULT 1,
);
Select * from admin


Create table applianceType
(
	applianceTypeId nchar(50) NOT NULL Primary Key,
	name nchar(50) NOT NULL ,
	status tinyint NOT NULL DEFAULT 1,
)
Select * from applianceType;


Create table appliances
(
   applianceId nchar(50) NOT NULL  Primary Key,
   applianceName nchar(50) NOT NULL,
   model nchar(50) NOT NULL,
   dimensions nchar(50) NULL,
   colour nchar(50) NOT NULL,
   annualCosts float  NOT NULL,
   monthlyFees float NOT NULL,
   energyConsumption nchar(50) NOT NULL,
   adminId nchar(50) NOT NULL,
   applianceTypeId nchar(50) NOT NULL Foreign Key References applianceType(applianceTypeId),
   applianceImage Varchar (255),
   quantity int NOT NULL,
   available int NOT NULL,
   powerUsage nchar(50) NOT NULL,
   typicalUsage nchar(50) NOT NULL,
	status tinyint NOT NULL DEFAULT 1,
	CONSTRAINT fk_adminId Foreign Key (adminId) References admin(adminId),
	CONSTRAINT fk_applianceTypeId Foreign Key (applianceTypeId) References applianceType(applianceTypeId),
);
Select * from appliances;


Create table rent
(
	rentId nchar(50) NOT NULL Primary Key,
	customerId nchar(50) NOT NULL,
	rentDate Date NOT NULL,
    totalAmount float NOT NULL,
	rentStatus nchar(20) NOT NULL, 
	status tinyint NOT NULL DEFAULT 1,
	CONSTRAINT fk_customerId Foreign Key (customerId) References customer(customerId),
);
Select * from rent;

 
Create table rentAppliances
(
    rentId nchar(50) NOT NULL ,
    applianceId nchar(50) NOT NULL,
    months int NOT NULL,
    unitPrice float NOT NULL,
    unitAnnualPrice float NOT NULL,
    totalPrice float NOT NULL,
    quantity int NOT NULL,
	CONSTRAINT fk_rentId Foreign Key (rentId) References rent(rentId),
	CONSTRAINT fk_applianceId Foreign Key (applianceId) References appliances(applianceId),
);
Select * from rentAppliances;

