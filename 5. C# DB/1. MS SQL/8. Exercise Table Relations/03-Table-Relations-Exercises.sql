GO --1.	One-To-One Relationship

CREATE DATABASE Passports

GO

USE Passports

GO 

CREATE TABLE Persons(
	PersonID INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(8, 2) NOT NULL,
	PassportID INT
	)

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY IDENTITY(101, 1),
	PassportNumber CHAR(8) NOT NULL
	)

GO

INSERT INTO Persons(FirstName, Salary, PassportID)
	VALUES
		('Roberto', 43300.00, 102),
		('Tom', 56100.00, 102),
		('Yana', 60200.00, 101)

INSERT INTO Passports(PassportNumber)
	VALUES
		('N34FG21B'),
		('K65LO4R7'),
		('ZE657QP2')
		

GO
ALTER TABLE Persons 
ADD CONSTRAINT PK_PersonID PRIMARY KEY (PersonID);

GO

ALTER TABLE Persons
ADD CONSTRAINT FK_PassportID FOREIGN KEY (PassportID) REFERENCES Passports(PassportID);

GO --02. One-To-Many Relationship

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL
	);

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATETIME2 NOT NULL
	);


GO

ALTER TABLE Models
ADD CONSTRAINT FK_ManufacturerID FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID);

GO 


INSERT INTO Manufacturers([Name], [EstablishedOn])
	VALUES
		('BMW', '1916-03-07'),
		('Tesla', '2003-01-01'),
		('Lada', '1966-05-01');


		INSERT INTO Models([Name], ManufacturerID)
	VALUES
		('X1', 1),
		('i6', 1),
		('Model S', 2),
		('Model X', 2),
		('Model 3', 2),
		('Nova', 3);


GO --03. Many-To-Many Relationship

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
	);

CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL
	);

CREATE TABLE [StudentsExams](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]) NOT NULL,
	PRIMARY KEY ([StudentID], [ExamID])	
	);

INSERT INTO [Students]([Name])
	VALUES
		('Mila'),
		('Toni'),
		('Ron');

INSERT INTO [Exams]([Name])
	VALUES
		('SpringMVC'),
		('Neo4j'),
		('Oracle 11g');

INSERT INTO [StudentsExams]([StudentID], [ExamID])
	VALUES
		(1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103);

GO --04. Self-Referencing

CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
	);

INSERT INTO [Teachers]([Name], [ManagerID])
	VALUES
		('John', NULL),
		('Maya', 106),
		('Silvia', 106),
		('Ted', 105),
		('Mark', 101),
		('Greta', 101);

SELECT * FROM [Teachers]


GO --05. Online Store Database

CREATE DATABASE [Shop];

GO 

USE [Shop];

GO

CREATE TABLE [Cities](
	[CityID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
	);

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Birthday] DATETIME2,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
	);

CREATE TABLE [Orders](
	[OrderID] INT PRIMARY KEY IDENTITY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
	);

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
	);

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
	);

CREATE TABLE [OrderItems](
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]) NOT NULL,
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]) NOT NULL,
	PRIMARY KEY ([OrderID], [ItemID])
	);
	
GO --06. University Database


CREATE DATABASE [University]

GO

USE [University]

GO

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
	);

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] VARCHAR(15) NOT NULL,
	[StudentName] NVARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
	);

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] NVARCHAR(50) NOT NULL
	);

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATETIME2 NOT NULL,
	[PaymentAmount] DECIMAL(8, 2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
	);

CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
	PRIMARY KEY ([StudentID], [SubjectID])
	);

GO --9.	*Peaks in Rila

USE [Geography]

SELECT m.[MountainRange], [PeakName], [Elevation]
FROM Peaks AS p
INNER JOIN [Mountains] AS m ON m.[Id] = p.[MountainId]
AND m.[MountainRange] = 'Rila'
ORDER BY [Elevation] DESC;


SELECT * 

FROM 
[Projects]