GO --2.	Find All the Information About Departments

	SELECT [DepartmentID]
      ,[Name]
      ,[ManagerID]
	FROM [Departments]

GO --3.	Find all Department Names
	
	SELECT [Name] FROM [Departments]

GO --4.	Find Salary of Each Employee

	SELECT [FirstName]
	,[LastName]
	,[Salary]
	FROM [Employees]

GO --5.	Find Full Name of Each Employee

		SELECT [FirstName]
			,[MiddleName]
			,[LastName]
		FROM [Employees]

GO --6.	Find Email Address of Each Employee

	SELECT CONCAT([FirstName], '.', [LastName], '@softuni.bg' ) 
		AS [Full Email Address] 
	FROM [Employees]

GO --07. Find All Different Employee’s Salaries

	SELECT DISTINCT [Salary] 
	FROM [Employees]

GO --8.	Find All Information About Employees

	SELECT *
	FROM [Employees] 
	WHERE [JobTitle] = 'Sales Representative'

GO --09. Find Names of All Employees by Salary in Range

	SELECT [FirstName]
		,[LastName]
		,[JobTitle]
		--,[Salary]
	FROM [Employees] AS e
	WHERE e.[Salary] BETWEEN 20000 AND 30000

GO --10. Find Names of All Employees

	SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS 'Full Name'
	FROM [Employees] AS e
	WHERE e.[Salary] = 25000 
	OR e.[Salary] = 14000 
	OR e.[Salary] = 12500 
	OR e.[Salary] = 23600

GO --11. Find All Employees Without Manager

	SELECT [FirstName]
	,[LastName]
	FROM [Employees] AS e
	WHERE e.ManagerID IS NULL

GO --12. Find All Employees with Salary More Than

	SELECT [FirstName]
	,[LastName] 
	,[Salary]
	FROM [Employees]
	WHERE [Salary] > 50000 
	ORDER BY [Salary] DESC

GO --13. Find 5 Best Paid Employees

	SELECT TOP(5) [FirstName]
	,[LastName]
	FROM [Employees]
	ORDER BY [Salary] DESC 

GO --14. Find All Employees Except Marketing
	
	SELECT [FirstName]
	,[LastName]
	FROM [Employees]
	WHERE [DepartmentID] <> 4

GO --15. Sort Employees Table

	SELECT * FROM [Employees]
	ORDER BY [Salary] DESC
	,[FirstName]
	,[LastName] DESC
	,[MiddleName] 

GO --16. Create View Employees with Salaries

	CREATE VIEW V_EmployeesSalaries AS 
	SELECT [FirstName]
	,[LastName]
	,[Salary] 
	FROM [Employees]

	SELECT * FROM V_EmployeesSalaries

GO --17. Create View Employees with Job Titles

	CREATE VIEW V_EmployeeNameJobTitle AS
	SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS 'Full Name'
	,[JobTitle] AS 'Job Title'
	FROM [Employees]

GO --18. Distinct Job Titles

	SELECT DISTINCT [JobTitle] FROM [Employees]

GO --19. Find First 10 Started Projects

	SELECT TOP (10) *
	FROM [Projects] AS p
	ORDER BY p.[StartDate], p.[Name]

GO --20. Last 7 Hired Employees

	SELECT TOP(7)
	[FirstName]
	,[LastName]
	,[HireDate]
	FROM [Employees]
	ORDER BY [HireDate] DESC

GO --21. Increase Salaries

	UPDATE [Employees]
	SET [Salary] = [Salary] * 1.12
	WHERE [DepartmentID] = 1
	OR [DepartmentID] = 2
	OR [DepartmentID] = 4 
	OR [DepartmentID] = 11

GO 
	SELECT e.[Salary] FROM [Employees] AS e

GO 
	UPDATE [Employees]
	SET [Salary] = [Salary] / 1.12
	WHERE [DepartmentID] = 1
	OR [DepartmentID] = 2
	OR [DepartmentID] = 4 
	OR [DepartmentID] = 11

GO --22. All Mountain Peaks

	USE [Geography]

	SELECT [PeakName] FROM [Peaks]
	ORDER BY [PeakName] 

GO --23. Biggest Countries by Population

	SELECT TOP (30) [CountryName]
	,[Population]
	FROM [Countries]
	WHERE [ContinentCode] = 'EU'
	ORDER BY [Population] DESC, [CountryName]

GO --24. Countries and Currency (Euro / Not Euro)

	SELECT [CountryName]
	,[CountryCode]
	,CASE WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
		END AS 'Currency'
	FROM [Countries]
	ORDER BY [CountryName]

GO --25. All Diablo Characters

	USE [Diablo]

	SELECT [Name] FROM [Characters]
	ORDER BY [Name]