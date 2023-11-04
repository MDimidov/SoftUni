GO --2.	Create Tables
CREATE TABLE [Minions](
[Id] INT PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
[Age] INT,
)

CREATE TABLE Towns (
[Id] INT PRIMARY KEY,
[Name] VARCHAR(50)
)


GO --3.	Alter Minions Table
ALTER TABLE [Minions] 
	ADD [TownId] INT FOREIGN KEY (TownId) REFERENCES [Towns](Id)

GO --4.	Insert Records in Both Tables
	
	INSERT INTO [Towns]([Id], [Name])
	VALUES 
		(1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna')
GO
	INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES 
		(1, 'Kevin', 22, 1),
		(2, 'Bob', 15, 3),
		(3, 'Steward', NULL, 2)

GO --5.	Truncate Table Minions
	TRUNCATE TABLE [Minions]

GO --6.	Drop All Tables
DROP TABLE [Minions], [Towns]

GO --7.	Create Table People
	CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([PICTURE]) <= 2000000),
	[Heihgt] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[BirthDate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
	)

INSERT INTO [People]([Name], [Picture], [Heihgt],[Weight], [Gender], [BirthDate], [Biography])
	VALUES
		('Pesho', NULL, 1.85, 45.67, 'm', '1988-03-23', NULL),
		('Myro', NULL, 1.85, 45.67, 'm', '1998-05-23', NULL),
		('Ani', NULL, 1.85, 45.67, 'm', '1998-03-22', NULL),
		('Filip', NULL, 1.85, 45.67, 'm', '1999-03-23', NULL),
		('Gatio', NULL, 1.85, 45.67, 'm', '1993-03-23', NULL)

GO --8.	Create Table Users
	CREATE TABLE [Users](
		[Id] INT PRIMARY KEY IDENTITY,
		[Username] VARCHAR(30) NOT NULL,
		[Password] VARCHAR(26) NOT NULL,
		[ProfilePicture] VARBINARY(MAX),
			CHECK (DATALENGTH([ProfilePicture]) <= 900000),
		[LastLoginTime] DATETIME2,
		[IsDeleted] BIT
		)

	INSERT INTO [Users]([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
		VALUES
			('mYO.97', 'PASSORD', NULL, '2023-09-01', 'TRUE'),
			('mYRO.97', 'PASSRD', NULL, '2023-08-20', 'FALSE'),
			('mY.97', 'PASORD', NULL, '2023-07-14', 'TRUE'),
			('mYR97', 'PASSWRD', NULL, '2022-09-14', 'FALSE'),
			('mYRO7', 'PASSRD', NULL, '2023-08-14', 'TRUE')

GO --9.	Change Primary Key
	ALTER TABLE [Users] 
	ADD CONSTRAINT PK_User PRIMARY KEY ([Id] ,[Username])
	
GO --10.	Add Check Constraint
	ALTER TABLE [Users]
	ADD CHECK (LEN([Password]) >= 5)

GO --11.	Set Default Value of a Field
	ALTER TABLE [Users]
	ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR [LastLoginTime]
	
	--TEST
	INSERT INTO [Users]([Username], [Password], [ProfilePicture], [IsDeleted])
		VALUES
			('mYO.97', 'PASSORD', NULL, 'TRUE')
	SELECT * FROM [Users]

GO --12.	Set Unique Field
	ALTER TABLE [Users]
	DROP CONSTRAINT PK_User
	ALTER TABLE [Users]
	ADD CONSTRAINT UC_User UNIQUE ([User]) 
	,CHECK (LEN([User]) >= 3)



GO --13.	Movies Database
	CREATE DATABASE [Movies]

	USE [Movies]

	CREATE TABLE[Directors](
		[Id] INT PRIMARY KEY IDENTITY,
		[DirectorName] NVARCHAR(50) NOT NULL,
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [Genres](
		[Id] INT PRIMARY KEY IDENTITY,
		[GenreName] NVARCHAR(50) NOT NULL,
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [Categories](
		[Id] INT PRIMARY KEY IDENTITY,
		[CategoryName] NVARCHAR(50) NOT NULL,
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [Movies](
		[Id] INT PRIMARY KEY IDENTITY,
		[Title] NVARCHAR(50) NOT NULL,
		[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
		[CopyrightYear] DATETIME2 NOT NULL,
		[Length] TIME NOT NULL,
		[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
		[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
		[Rating] DECIMAL(2,0),
		[Notes] NVARCHAR(MAX)
		)

	INSERT INTO [Directors]([DirectorName], [Notes])
		VALUES
			('Мариян Димидов', 'THE BEST DIRECOTR'),
			('Мариян Димидов', NULL),
			('Димидов', 'THE BEST DIRECOTR'),
			('Димидов', NULL),
			('Мариян', 'THE BEST DIRECOTR')

	INSERT INTO [Genres]([GenreName], [Notes])
		VALUES
			('SCARY', NULL),
			('FUNNY', NULL),
			('LOVE', NULL),
			('DRAMA', NULL),
			('ACTION', NULL)

	INSERT INTO [Categories]([CategoryName], [Notes])
		VALUES
			('SHORT', 'NOT LONGER THAN 30 MIN'),
			('MEDIUM', 'NOT LONGER THAN 60 MIN'),
			('LONG', 'NOT LONGER THAN 110 MIN'),
			('VERY LONG', 'NOT LONGER THAN 150 MIN'),
			('SHORT', 'NOT LONGER THAN 30 MIN')

	INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
		VALUES
			('3 METERS TO THE SKY', 2, GETDATE(), '02:10:12', 3, 4, '07', NULL),
			('3 METERS TO THE SKY', 3, GETDATE(), '02:10:12', 1, 2, '06', NULL),
			('THE MEG', 1, GETDATE(), '02:10:12', 2, 1, '10', NULL),
			('BLUE BUG', 4, GETDATE(), '02:10:12', 4, 3, '03', NULL),
			('3 METERS TO THE SKY', 5, GETDATE(), '02:10:12', 5, 5, '09', NULL)


GO --14.	Car Rental Database

	CREATE DATABASE [CarRental]

	USE [CarRental]

	CREATE TABLE[Categories](
		[Id] INT PRIMARY KEY IDENTITY,
		[CategoryName] NVARCHAR(50) NOT NULL,
		[DailyRate] DECIMAL(6, 2),
		[WeeklyRate] DECIMAL(6, 2),
		[MonthlyRate] DECIMAL(6, 2),
		[WeekendRate] DECIMAL(6, 2)
		)

	CREATE TABLE[Cars](
		[Id] INT PRIMARY KEY IDENTITY,
		[PlateNumber] VARCHAR(8) NOT NULL,
		[Manufacturer] NVARCHAR(50) NOT NULL,
		[Model] NVARCHAR(50) NOT NULL, 
		[CarYear] DATE NOT NULL, 
		[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
		[Doors] TINYINT NOT NULL,
		[Picture] VARBINARY(MAX),
			CHECK (DATALENGTH([Picture]) <= 2000000),
		[Condition] NVARCHAR(MAX),
		[Available] BIT NOT NULL
		)

	CREATE TABLE [Employees](
		[Id] INT PRIMARY KEY IDENTITY,
		[FirstName] NVARCHAR(50) NOT NULL,
		[LastName] NVARCHAR(50) NOT NULL,
		[Title] NVARCHAR(50),
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [Customers](
		[Id] INT PRIMARY KEY IDENTITY,
		[DriverLicenceNumber] CHAR(10) NOT NULL,
		[FullName] NVARCHAR(100) NOT NULL,
		[Address] NVARCHAR(200) NOT NULL,
		[City] NVARCHAR(50) NOT NULL,
		[ZIPCode] CHAR(4),
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [RentalOrders](
		[Id] INT PRIMARY KEY IDENTITY,
		[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
		[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
		[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
		[TankLevel] DECIMAL(3, 0) NOT NULL,
		[KilometrageStart] DECIMAL(8,2) NOT NULL,
		[KilometrageEnd] DECIMAL(8, 2) NOT NULL,
			CHECK ([KilometrageEnd] > [KilometrageStart]),
		[TotalKilometrage] AS [KilometrageEnd] - [KilometrageStart],
		[StartDate] DATE NOT NULL,
		[EndDate] DATE NOT NULL,
			--CHECK (CONVERT(INT, [EndDate]) >= CONVERT(INT, [StartDate])),
		--[TotalDays] AS (CONVERT(INT, [EndDate]) - CONVERT(INT, [StartDate])),
			CHECK (CONVERT(INT, CAST([EndDate]  as DATETIME)) >= CONVERT(INT, CAST([StartDate]  as DATETIME))),
		[TotalDays] AS (CONVERT(INT, CAST([EndDate] as DATETIME)) - CONVERT(INT, CAST([StartDate] as DATETIME))),
		[RateApplied] DECIMAL(3,2) NOT NULL,
		[TaxRate] DECIMAL(3, 2) NOT NULL,
		[OrderStatus] BIT NOT NULL,
		[Notes] NVARCHAR(MAX)
		)

	INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
		VALUES
			('SPORT CAR', 15.0, 80.00, 120.00, 35.00),
			('NORMAL CAR', 15.0, 80.00, 120.00, 35.00), 
			('SLOW CAR', 15.0, 80.00, 120.00, 35.00) 
			
	INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
		VALUES
			('B5555TH', 'AUDI', 'RS5', '2001-09-01', 2, 5, NULL, 'GOOD', 1),
			('B5565TH', 'AUDI', 'RS5', '2001-09-01', 2, 5, NULL, 'GOOD', 1),
			('B5861TH', 'AUDI', 'RS5', '2001-09-01', 2, 5, NULL, 'GOOD', 1)

	INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
		VALUES
			('MARIQN', 'DIMIDOV', 'RENTA', NULL),
			('MARIQN', 'DIMIDOV', 'RENTA', NULL),
			('MARIQN', 'DIMIDOV', 'RENTA', NULL)

	INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
		VALUES
			('0854684656', 'MARIQN DIMIDOV', 'VARNA, VARNA, VARNA', 'VARNA', '9000', NULL),
			('0854684656', 'MARIQN DIMIDOV', 'VARNA, VARNA, VARNA', 'VARNA', '9000', NULL),
			('0854684656', 'MARIQN DIMIDOV', 'VARNA, VARNA, VARNA', 'VARNA', '9000', NULL)

	INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [RateApplied], [TaxRate], [OrderStatus], [Notes])
		VALUES
			(1, 2, 3, 95, 111234.4, 111542.2, '2023-09-12', GETDATE(), 1.32, 4.21, 1, NULL),
			(1, 2, 3, 95, 111234.4, 111842.2, '2023-09-11', GETDATE(), 1.32, 4.21, 0, NULL),
			(1, 2, 3, 95, 111234.4, 111342.2, '2023-08-25', GETDATE(), 1.32, 4.21, 1, NULL)




SELECT * FROM [RentalOrders]

GO --15.	Hotel Database

	CREATE DATABASE [Hotel]

	USE [Hotel]

	CREATE TABLE [Employees](
		[Id] INT PRIMARY KEY IDENTITY,
		[FirstName] NVARCHAR(50) NOT NULL,
		[LastName] NVARCHAR(50) NOT NULL,
		[Title] NVARCHAR(50),
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [Customers](
		[AccountNumber] INT PRIMARY KEY IDENTITY,
		[FirstName] NVARCHAR(50) NOT NULL,
		[LastName] NVARCHAR(50) NOT NULL,
		[PhoneNumber] CHAR(10) NOT NULL,
		[EmergencyName] NVARCHAR(100),
		[EmergencyNumber] CHAR(10),
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [RoomStatus](
		[RoomStatus] NVARCHAR(50) PRIMARY KEY,
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [RoomTypes](
		[RoomType] NVARCHAR(50) PRIMARY KEY,
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [BedTypes](
		[BedType] NVARCHAR(50) PRIMARY KEY,
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [Rooms](
		[RoomNumber] INT PRIMARY KEY,
		[RoomType] NVARCHAR(50) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]) NOT NULL,
		[BedType] NVARCHAR(50) FOREIGN KEY REFERENCES [BedTypes]([BedType]) NOT NULL,
		[Rate] DECIMAL(5, 2) NOT NULL,
		[RoomStatus] NVARCHAR(50) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]) NOT NULL,
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [Payments](
		[Id] INT PRIMARY KEY IDENTITY,
		[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
		[PaymentDate] AS GETDATE(),
		[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
		[FirstDateOccupied] DATETIME2 NOT NULL,
		[LastDateOccupied] DATETIME2 NOT NULL,
			CHECK (CONVERT(INT, CAST([LastDateOccupied]  as DATETIME)) >= CONVERT(INT, CAST([FirstDateOccupied]  as DATETIME))),
		[TotalDays] AS (CONVERT(INT, CAST([LastDateOccupied] as DATETIME)) - CONVERT(INT, CAST([FirstDateOccupied] as DATETIME))),
		[AmountCharged] DECIMAL(3,2) NOT NULL,
		[TaxRate] DECIMAL(3, 2) NOT NULL,
		[TaxAmount] DECIMAL(3, 2) NOT NULL,
		[PaymentTotal] AS ( [TaxRate] + ([AmountCharged] * [TaxAmount])),
		[Notes] NVARCHAR(MAX)
		)

	CREATE TABLE [Occupancies](
		[Id] INT PRIMARY KEY IDENTITY,
		[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
		[DateOccupied] AS GETDATE(),
		[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]) NOT NULL,
		[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]) NOT NULL,
		[RateApplied] INT FOREIGN KEY REFERENCES [Payments]([Id]) NOT NULL,
		[PhoneCharge] CHAR(10) NOT NULL,
		[Notes] NVARCHAR(MAX)
		)


	INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
		VALUES
			('MARIQN', 'DIMIDOV', 'EXPERT', NULL),
			('MARIQN', 'DIMIDOV', 'EXPERT', NULL),
			('MARIQN', 'DIMIDOV', 'EXPERT', NULL)

	INSERT INTO [Customers]([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
		VALUES
			('MARIQN', 'DIMIDOV', '0890890895', 'STOQNKA KOLEVA', '0870870875', NULL),
			('MARIQN', 'DIMIDOV', '0890890895', 'STOQNKA KOLEVA', '0870870875', NULL),
			('MARIQN', 'DIMIDOV', '0890890895', 'STOQNKA KOLEVA', '0870870875', NULL)

	INSERT INTO [RoomStatus]([RoomStatus], [Notes])
		VALUES
			('FREE', NULL),
			('TAKEN', NULL),
			('SEX', NULL)

	INSERT INTO [RoomTypes]([RoomType], [Notes])
		VALUES
			('SEX', NULL),
			('MASSAGE', NULL),
			('RELAX', NULL)

	INSERT INTO [BedTypes]([BedType], [Notes])
		VALUES
			('BIG', NULL),
			('NORMAL', NULL),
			('SMALL', NULL)

	INSERT INTO [Rooms]([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus], [Notes])
		VALUES
			(101, 'SEX', 'NORMAL', 123.12, 'FREE', NULL),
			(102, 'SEX', 'NORMAL', 113.12, 'TAKEN', NULL),
			(103, 'SEX', 'NORMAL', 223.12, 'SEX', NULL)

	INSERT INTO [Payments]([EmployeeId], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [AmountCharged], [TaxRate], [TaxAmount], [Notes])
		VALUES
			(1, 2, '2023-05-24', GETDATE(), 2.42, 5.42, 2.41, NULL),
			(1, 2, '2023-05-24', GETDATE(), 2.42, 5.42, 2.41, NULL), 
			(1, 2, '2023-05-24', GETDATE(), 2.42, 5.42, 2.41, NULL)
			
	INSERT INTO [Occupancies]([EmployeeId], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes])
		VALUES
			(1, 2, 101, 2, '0890890895', NULL),
			(1, 2, 101, 2, '0890890895', NULL),
			(1, 2, 101, 2, '0890890895', NULL)





GO --16.	Create SoftUni Database

	CREATE DATABASE [SoftUni]
GO
	USE [SoftUni]
GO
		CREATE TABLE [Towns](
			[Id] INT IDENTITY,
			[Name] NVARCHAR(50) NOT NULL,
			CONSTRAINT PK_TownId PRIMARY KEY ([Id])
			)
GO
		CREATE TABLE [Addresses](
			[Id] INT IDENTITY,
			[AddressText] NVARCHAR(200) NOT NULL,
			[TownId] INT NOT NULL,
			CONSTRAINT PK_AddressId PRIMARY KEY ([Id]),
			CONSTRAINT FK_AddressTownId FOREIGN KEY ([Id]) REFERENCES [Towns]([Id])
			)
GO
		CREATE TABLE [Departments](
			[Id] INT IDENTITY,
			[Name] NVARCHAR(50) NOT NULL,
			CONSTRAINT PK_DepartmentId PRIMARY KEY ([Id])
			)
GO
		CREATE TABLE [Employees](
			[Id] INT IDENTITY,
			[FirstName] NVARCHAR(50) NOT NULL,
			[MiddleName] NVARCHAR(50),
			[LastName] NVARCHAR(50) NOT NULL,
			[JobTitle] NVARCHAR(50) NOT NULL,
			[DepartmentId] INT NOT NULL,
			[HireDate] DATETIME2 NOT NULL,
			[Salary] DECIMAL(7, 2) NOT NULL,
			[AddressId] INT,
			CONSTRAINT PK_EmployeId PRIMARY KEY ([Id]),
			CONSTRAINT FK_EmployeDepartmentId FOREIGN KEY ([DepartmentId]) REFERENCES [Departments]([Id]),
			CONSTRAINT FK_EmployeAddressId FOREIGN KEY ([AddressId]) REFERENCES [Addresses]([Id])
			)


GO --17.	Backup Database

	BACKUP DATABASE [SoftUni]
		TO DISK = 'C:\DISK-D\me\-)Programing(-\SoftUni\3. Advanced Module\C#\3. C# DB\1. MS SQL\softuni-backup.bak'
		WITH FORMAT,
		MEDIANAME = 'SQLServerBackups',
		NAME = 'Full Backup of SQLTestDB';
GO

	DROP DATABASE [SoftUni]

GO
	RESTORE DATABASE [SoftUni]  
		FROM DISK = 'C:\DISK-D\me\-)Programing(-\SoftUni\3. Advanced Module\C#\3. C# DB\1. MS SQL\softuni-backup.bak';  

GO  --18.	Basic Insert

	INSERT INTO [Towns]([Name])
		VALUES
			('Sofia'),
			('Plovdiv'),
			('Varna'),
			('Burgas')
GO
	INSERT INTO [Departments]([Name])
		VALUES
			('Engineering'),
			('Sales'),
			('Marketing'),
			('Software Development'),
			('Quality Assurance')
GO
	INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary]) 
		VALUES
			('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
			('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
			('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
			('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
			('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

GO --19.	Basic Select All Fields

	SELECT * FROM [Towns]
	SELECT * FROM [Departments]
	SELECT * FROM [Employees]

GO --20.	Basic Select All Fields and Order Them

	SELECT * FROM [Towns]
		ORDER BY [Name]

	SELECT * FROM [Departments]
		ORDER BY [Name]

	SELECT * FROM [Employees]
		ORDER BY [Salary] DESC

GO --21. Basic Select Some Fields

	SELECT [Name] FROM [Towns]
		ORDER BY [Name]

	SELECT [Name] FROM [Departments]
		ORDER BY [Name]

	SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees]
		ORDER BY [Salary] DESC

GO --22. Increase Employees Salary

	UPDATE [Employees] SET [Salary] = [Salary] * 1.1
	SELECT [Salary] FROM [Employees]

GO --23. Decrease Tax Rate

	USE [Hotel]
		
		UPDATE [Payments] SET [TaxRate] = [TaxRate] * 0.97
		SELECT [TaxRate] FROM [Payments]

GO --24. Delete All Records

	USE [Hotel]
	TRUNCATE TABLE [Occupancies]
