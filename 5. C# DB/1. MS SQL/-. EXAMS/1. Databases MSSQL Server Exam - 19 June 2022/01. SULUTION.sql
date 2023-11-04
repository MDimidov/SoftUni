--								 Database Basics MS SQL Exam – 19 June 2022
--												Zoo

GO -- Section 1. DDL (30 pts)

CREATE DATABASE [Zoo];

GO

USE [Zoo];

GO

CREATE TABLE [Owners](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
	);

CREATE TABLE [AnimalTypes](
	[Id] INT PRIMARY KEY IDENTITY,
	[AnimalType] VARCHAR(30) NOT NULL
	);

CREATE TABLE [Cages](
	[Id] INT PRIMARY KEY IDENTITY,
	[AnimalTypeId] INT FOREIGN KEY REFERENCES [AnimalTypes]([Id]) NOT NULL
	);

CREATE TABLE [Animals](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[OwnerId] INT FOREIGN KEY REFERENCES [Owners]([Id]),
	[AnimalTypeId] INT FOREIGN KEY REFERENCES [AnimalTypes]([Id]) NOT NULL
	);

CREATE TABLE [AnimalsCages](
	[CageId] INT FOREIGN KEY REFERENCES [Cages]([Id]) NOT NULL,
	[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id]) NOT NULL,
	PRIMARY KEY ([CageId], [AnimalId])
	);
	
CREATE TABLE [VolunteersDepartments] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DepartmentName] VARCHAR(30) NOT NULL
	);
	
CREATE TABLE [Volunteers] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id]),
	[DepartmentId] INT FOREIGN KEY REFERENCES [VolunteersDepartments]([Id]) NOT NULL
	);

--	1.	Database design

GO -- Section 2. DML (10 pts)

-- 2.	Insert

INSERT INTO [Volunteers] ([Name], [PhoneNumber], [Address], [AnimalId], [DepartmentId])
	VALUES
		('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
		('Dimitur Stoev', '0877564223', NULL, 42, 4),
		('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
		('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
		('Boryana Mileva', '0888112233', NULL, 31, 5);

INSERT INTO [Animals] ([Name], [BirthDate], [OwnerId], [AnimalTypeId])
	VALUES
		('Giraffe', '2018-09-21', 21, 1),
		('Harpy Eagle', '2015-04-17', 15, 3),
		('Hamadryas Baboon', '2017-11-02', NULL, 1),
		('Tuatara', '2021-06-30', 2, 4);

GO -- 3.	Update

UPDATE [Animals]
SET [OwnerId] = 4
WHERE [OwnerId] IS NULL;

GO -- 04. Delete

SELECT * FROM [VolunteersDepartments]

DELETE FROM [Volunteers]
WHERE [DepartmentId] = 2;

DELETE FROM [VolunteersDepartments]
WHERE [Id] = 2;

--		Section 3. Querying (40 pts)

GO -- 05. Volunteers

SELECT [Name]
	,[PhoneNumber]
	,[Address]
	,[AnimalId]
	,[DepartmentId]
FROM [Volunteers]
ORDER BY [Name], [AnimalId], [DepartmentId];

GO -- 06. Animals data

SELECT a.[Name]
	,[at].[AnimalType]
	,FORMAT(a.[BirthDate], 'dd.MM.yyyy') AS [BirthDate]
FROM [Animals] AS a
JOIN [AnimalTypes] AS [at] ON a.[AnimalTypeId] = [at].[Id]
ORDER BY a.[Name];

GO -- 07. Owners and Their Animals

SELECT TOP(5)
	 o.[Name] AS [Owner]
	,COUNT(a.[Id]) AS [CountOfAnimals]
FROM [Animals] AS a
JOIN [Owners] AS o ON a.[OwnerId] = o.[Id]
GROUP BY o.[Name]
ORDER BY [CountOfAnimals] DESC, o.[Name];

GO -- 08. Owners, Animals and Cages

SELECT CONCAT(o.[Name], '-', a.[Name]) AS [OwnersAnimals]
	,o.[PhoneNumber]
	,ac.[CageId]
FROM [Owners] AS o
JOIN [Animals] AS a ON a.[OwnerId] = o.[Id]
JOIN [AnimalsCages] AS ac ON a.[Id] = ac.[AnimalId]
WHERE a.[AnimalTypeId] = 1
ORDER BY o.[Name], a.[Name] DESC;

GO -- 09. Volunteers in Sofia

SELECT o.[Name]
	,o.[PhoneNumber]
	,RIGHT(o.[Address], LEN(o.[Address]) - CHARINDEX(',', o.[Address])) AS [Address]
FROM [Volunteers] AS o
WHERE 
[Address] LIKE '%Sofia%'
AND o.[DepartmentId] = 2
ORDER BY o.[Name];

GO -- 10. Animals for Adoption

SELECT a.[Name]
	,DATEPART(YEAR, a.[BirthDate]) AS [BirthYear]
	,ap.[AnimalType]
FROM [Animals] AS a
JOIN [AnimalTypes] AS ap ON a.[AnimalTypeId] = ap.[Id]
WHERE a.[OwnerId] IS NULL
AND 2022 - DATEPART(YEAR, a.[BirthDate]) < 5
AND a.[AnimalTypeId] <> 3
ORDER BY a.[Name];


--		Section 4. Programmability (20 pts)

GO -- 11. All Volunteers in a Department

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	RETURN (
			SELECT COUNT(v.[Id])
			FROM [Volunteers] AS v
			JOIN [VolunteersDepartments] AS vd ON v.[DepartmentId] = vd.[Id]
			WHERE vd.[DepartmentName] = @VolunteersDepartment
			)
END


-----TEST-----
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')

GO -- 12. Animals with Owner or Not

CREATE PROC usp_AnimalsWithOwnersOrNot @AnimalName VARCHAR(30)
AS
BEGIN
	SELECT 
		a.[Name]
		,CASE
			WHEN a.[OwnerId] IS NULL THEN 'For adoption'
			ELSE o.[Name] 
			END AS [OwnersName]
	FROM [Animals] AS a
	LEFT JOIN [Owners] AS o ON a.[OwnerId] = o.[Id]
	WHERE a.[Name] = @AnimalName
END

----TEST----
EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'