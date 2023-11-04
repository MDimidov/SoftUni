--										Databases MSSQL Server Retake Exam - 8 April 2021
--															Service
--															myro.97

--			Section 1. DDL (30 pts)

CREATE DATABASE [Service];

GO

USE [Service];

GO -- 1.	Table design

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL, --CHECK IF WRONG
	[Name] VARCHAR(50),
	Birthdate DATE,
	AGE INT 
			CHECK(AGE BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
	);

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	);

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATE,
	AGE INT 
			CHECK(AGE BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
	);

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
	);

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(20) NOT NULL
	);

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME NOT NULL, 
	CloseDate DATETIME,
	Description VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
	);

--			Section 2. DML (10 pts)

GO -- 2.	Insert

INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
	VALUES 
		('Marlo', 'O''Malley', '1958-9-21', 1),
		('Niki', 'Stanaghan', '1969-11-26', 4),
		('Ayrton', 'Senna', '1960-03-21', 9),
		('Ronnie', 'Peterson', '1944-02-14', 9),
		('Giovanna', 'Amati', '1959-07-20', 5);

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId)
	VALUES
		(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
		(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
		(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
		(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1);

GO -- 03. Update

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL;

GO -- 04. Delete

DELETE FROM Reports
WHERE StatusId = 4;

--			Section 3. Querying (40 pts)

GO -- 5.	Unassigned Reports

SELECT Description
	,FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, Description;

GO -- 6.	Reports & Categories

SELECT r.Description
	,c.Name AS CategoryName
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.Description, c.Name;

GO -- 07. Most Reported Category

SELECT TOP (5) 
	 c.Name
	,COUNT(r.Id) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC, c.Name;

GO -- 8.	Birthday Report

SELECT u.Username
	,C.Name AS CategoryName
FROM Reports AS r
JOIN Users AS u ON r.UserId = u.Id
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate)
AND DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
ORDER BY u.Username, c.Name;

GO -- 9.	Users per Employee 

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName
	,COUNT(u.Id) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
LEFT JOIN Users AS u ON r.UserId = u.Id
GROUP bY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY UsersCount DESC, FullName;

GO -- 10.	Full Info

SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee
	,ISNULL(d.Name, 'None') AS Department
	,ISNULL(c.Name, 'None') AS Category
	,ISNULL(r.Description, 'None') AS Description
	,ISNULL(FORMAT( r.OpenDate, 'dd.MM.yyyy'), 'None') AS OpenDate
	,ISNULL(s.Label, 'None') AS Status
	,ISNULL(u.Name, 'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
LEFT JOIN Status AS s ON r.StatusId = s.Id
ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, r.Description, r.OpenDate, Status, [User];

--			Section 4. Programmability (20 pts)

GO -- 11.	Hours to Complete

CREATE OR ALTER FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS 
BEGIN
			IF (@StartDate IS NULL OR @EndDate IS NULL)
				BEGIN
					RETURN 0;
				END
			
			RETURN ABS(DATEPART(DAY, @EndDate)*24 - DATEPART(DAY, @StartDate)*24)
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

GO -- 12.	Assign Employee

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
		DECLARE @departmentEmployee INT = (SELECT DepartmentId 
										 FROM Employees
										 WHERE Id = @EmployeeId);

		DECLARE @departmentCategory INT = (SELECT c.DepartmentId 
										 FROM Reports AS r
										 JOIN Categories AS c ON r.CategoryId = c.Id
										 WHERE r.Id = @ReportId);

		IF (@departmentCategory = @departmentEmployee)
			BEGIN
					UPDATE Reports
					SET EmployeeId = @EmployeeId
					WHERE Id = @ReportId
			END
		ELSE
			BEGIN
					RAISERROR ('Employee doesn''t belong to the appropriate department!', 16, 1);
			END
END

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2