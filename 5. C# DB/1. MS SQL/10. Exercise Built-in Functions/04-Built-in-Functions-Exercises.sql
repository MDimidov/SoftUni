
USE [SoftUni]

GO --1.	Find Names of All Employees by First Name

SELECT 
	[FirstName]
	,[LastName]
FROM [Employees]
WHERE SUBSTRING([FirstName], 1, 2) = 'Sa'

GO --02. Find Names of All Employees by Last Name

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [LastName] LIKE '%ei%';

GO --3.	Find First Names of All Employees

SELECT [FirstName]
FROM [Employees]
WHERE [DepartmentID] IN (3, 10)
--AND [HireDate] BETWEEN '1995-01-01' AND '2005-12-31';
--AND YEAR([HireDate]) BETWEEN 1995 AND 2005;
AND DATEPART(YEAR, [HireDate]) BETWEEN 1995 AND 2005;



GO --04. Find All Employees Except Engineers

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [JobTitle] NOT LIKE '%engineer%'

GO --05. Find Towns with Name Length

SELECT [Name] FROM [Towns]
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name];

GO --06. Find Towns Starting With

SELECT *FROM [Towns]
--WHERE [Name] LIKE '[MKBE]%'
WHERE LEFT([NAME], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name];

GO --07. Find Towns Not Starting With

SELECT *FROM [Towns]
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name];

GO --08. Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT 
	[FirstName]
	,[LastName]
FROM [Employees]
WHERE [HireDate] >= '2001-01-01';

GO --09. Length of Last Name

SELECT 
	[FirstName]
	,[LastName]
FROM [Employees]
WHERE LEN([LastName]) = 5;

GO --10. Rank Employees by Salary

SELECT
	[EmployeeID]
	,[FirstName]
	,[LastName]	
	,[Salary]
	,DENSE_RANK() OVER (
	PARTITION BY [Salary]
	ORDER BY [EmployeeID]
	) AS [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
	ORDER BY [Salary] DESC;

GO --11. Find All Employees with Rank 2 (not included in final score)

WITH RankedEmployees AS (
    SELECT
        [EmployeeID]
        ,[FirstName]
        ,[LastName]    
        ,[Salary]
        ,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM [Employees]
    WHERE [Salary] BETWEEN 10000 AND 50000
)
SELECT *
FROM RankedEmployees
WHERE [Rank] = 2
ORDER BY [Salary] DESC;

-------------------------- 
SELECT * FROM
	(SELECT 
		[EmployeeID]
		,[FirstName]
		,[LastName]	
		,[Salary]
		,DENSE_RANK() OVER (
			PARTITION BY [Salary]
			ORDER BY [EmployeeID]
		) AS [Rank]
		FROM [Employees]
		WHERE [Salary] BETWEEN 10000 AND 50000

	) AS [RankedEmployees]
	WHERE [Rank] = 2
	ORDER BY [Salary] DESC;

GO --12.	Countries Holding 'A' 3 or More Times

USE [Geography]

SELECT 
	[CountryName]
	,[IsoCode]
FROM [Countries]
WHERE LEN([CountryName]) - LEN(REPLACE([CountryName], 'A', '')) >= 3 
ORDER BY [IsoCode];

GO --13. Mix of Peak and River Names

SELECT p.[PeakName]
	,r.[RiverName]
	,LOWER(CONCAT(LEFT(p.[PeakName], LEN(p.[PeakName]) - 1), r.[RiverName])) AS [Mix]
FROM [Peaks] AS p
	, [Rivers] AS r
WHERE LEFT(r.[RiverName], 1) = RIGHT(p.[PeakName], 1)
ORDER BY [Mix];

--SELECT
--SUBSTRING([PeakName], LEN([PeakName]), 1), [PeakName]
--FROM [Peaks]

--SELECT
--SUBSTRING([RiverName], 1, 1), [RiverName]
--FROM [Rivers]

GO --14.	Games from 2011 and 2012 Year

USE [DIABLO]

SELECT TOP(50)
	[Name]
	,FORMAT ([Start], 'yyyy-MM-dd') AS [Start]
FROM [Games]
WHERE [Start] BETWEEN '2011-01-01' AND '2012-12-31'
ORDER BY [Start], [Name];

GO --15.	 User Email Providers

SELECT [Username],
SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([EmaIL])) AS [Email Provider]
FROM [Users]
ORDER BY [Email Provider], [Username];

GO --16.	 Get Users with IP Address Like Pattern

SELECT 
	[Username],
	[IpAddress] AS [IP Adress]
FROM [Users]
WHERE [IpAddress] LIKE '[0-9][0-9][0-9].1[0-9]%.[0-9]%.[0-9][0-9][0-9]'
ORDER BY [Username];

GO --17. Show All Games with Duration & Part of the Day

SELECT 
	[Name] AS [Game],
	CASE
		WHEN CAST([Start] AS time) < '12:00:00' THEN 'Morning' --CAST([Start] AS time) >= '00:00:00' AND
		WHEN CAST([Start] AS time) < '18:00:00' THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] <= 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM [Games]
ORDER BY [Game], [Duration];

GO --18. Orders Table

USE [Orders]

SELECT [ProductName]
      ,[OrderDate]
	  ,DATEADD(DAY, 3, [OrderDate]) AS [Pay Due]
	  ,DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
  FROM [Orders];


GO --19.	 People Table

CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL
	);

INSERT INTO [People]([Name], [Birthdate])
	VALUES
		('Victor', '2000-12-07'),
		('Steven', '1992-09-10'),
		('Stephen', '1910-09-19'),
		('John', '2010-01-06');

SELECT [Name]
	,DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years]
	,DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months]
	,DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days]
	,DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
FROM [People];