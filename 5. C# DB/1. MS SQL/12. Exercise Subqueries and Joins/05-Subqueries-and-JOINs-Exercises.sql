--			Part I – Queries for SoftUni Database
GO --1.	Employee Address

SELECT TOP (5)
	e.[EmployeeID]
	,e.[JobTitle]
	,e.[AddressID]
	,a.[AddressText]
FROM [Employees] AS e
JOIN [Addresses] AS a ON a.[AddressID] = e.[AddressID]
ORDER BY e.[AddressID];

GO --02. Addresses with Towns

SELECT TOP (50)
	e.[FirstName]
	,e.[LastName]
	,t.[Name] AS [Town]
	,a.[AddressText]
FROM [Employees] AS e
JOIN [Addresses] AS a ON a.[AddressID] = e.[AddressID]
JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
ORDER BY e.[FirstName], e.[LastName];

GO --03. Sales Employees

SELECT e.[EmployeeID]
	,e.[FirstName]
	,e.[LastName]
	,d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
AND d.[Name] = 'Sales'
ORDER BY E.[EmployeeID];

GO --04. Employee Departments

SELECT TOP (5) 
	 e.[EmployeeID]
	,e.[FirstName]
	,e.[Salary]
	,d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
AND e.[Salary] > 15000
ORDER BY e.[DepartmentID];

GO --05. Employees Without Projects

SELECT TOP (3)
	 e.[EmployeeID]
	,e.[FirstName]
FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
WHERE ep.[EmployeeID] IS NULL
ORDER BY e.[EmployeeID];

GO --06. Employees Hired After

SELECT e.[FirstName]
	,e.[LastName]
	,e.[HireDate]
	,d.[Name] AS [DeptName]
FROM [Employees] AS e
JOIN [Departments] AS d ON d.[DepartmentID] = e.[DepartmentID]
AND d.[Name] IN ('Sales', 'Finance')
AND e.[HireDate] > '1999-01-01'
ORDER BY e.[HireDate];

GO --07. Employees With Project

SELECT TOP (5)
	 e.[EmployeeID]
	,e.[FirstName]
	,p.[Name] AS [ProjectName]
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep ON ep.[EmployeeID] = e.[EmployeeID]
JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
AND p.[StartDate] > '2002-08-13'
AND p.[EndDate] IS NULL;

GO --08. Employee 24

SELECT
	 e.[EmployeeID]
	,e.[FirstName]
	,CASE
		WHEN DATEPART(YEAR, p.[StartDate]) >= 2005 THEN NULL
		ELSE P.[Name] 
	END AS [ProjectName]
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep ON ep.[EmployeeID] = e.[EmployeeID]
JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
AND e.[EmployeeID] = 24;

GO --09. Employee Manager

SELECT e.[EmployeeID]
	,e.[FirstName]
	,m.[EmployeeID] AS [ManagerID]
	,m.[FirstName] AS [ManagerName]
FROM [Employees] AS e
JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
AND m.[EmployeeID] IN (3, 7);

GO --10. Employees Summary

SELECT TOP (50) 
	 m.[EmployeeID]
	,CONCAT(m.[FirstName], ' ', m.[LastName]) AS [EmployeeName]
	,CONCAT(e.[FirstName], ' ', e.[LastName]) AS [ManagerName]
	,d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Employees] AS m ON m.[ManagerID] = e.[EmployeeID]
JOIN [Departments] AS d ON d.[DepartmentID] = m.[DepartmentID]
ORDER BY m.[EmployeeID];

GO --11. Min Average Salary

SELECT MIN(sq.[MinAverageSalary])
	FROM (SELECT AVG(e.[Salary]) AS [MinAverageSalary]
		FROM [Employees] AS e
		GROUP BY [DepartmentID]) AS sq;


--			Part II – Queries for Geography Database
		USE [Geography]

GO --12. Highest Peaks in Bulgaria

SELECT c.[CountryCode]
	,m.[MountainRange]
	,p.[PeakName]
	,p.[Elevation]
FROM [Peaks] AS p
JOIN [Mountains] AS m ON p.[MountainId] = m.[Id]
JOIN [MountainsCountries] AS mc ON mc.[MountainId] = m.[Id]
JOIN [Countries] AS c ON c.[CountryCode] = mc.[CountryCode]
AND c.[CountryName] = 'Bulgaria'
AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC;

GO --13. Count Mountain Ranges

SELECT mc.[CountryCode]
	,COUNT(m.[MountainRange]) AS [MountainRanges]
FROM [Mountains] AS m
JOIN [MountainsCountries] AS mc ON mc.[MountainId] = m.[Id]
AND mc.[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY mc.[CountryCode];

GO --14. Countries With or Without Rivers

SELECT TOP (5)
	 c.[CountryName]
	,r.[RiverName]
FROM [Rivers] AS r
JOIN [CountriesRivers] AS cr ON cr.[RiverId] = r.[Id]
RIGHT JOIN [Countries] AS c ON cr.[CountryCode] = c.[CountryCode]
JOIN [Continents] AS co ON co.[ContinentCode] = c.[ContinentCode]
WHERE co.[ContinentName] = 'Africa'
ORDER BY c.[CountryName];

GO --15. Continents and Currencies (not included in final score)

SELECT [ContinentCode]
	,[CurrencyCode]
	,[CurrencyUsage]
	FROM 
		(
		SELECT *,
			DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC) AS [RANK]
			FROM 
				(
					SELECT co.[ContinentCode]
					,C.[CurrencyCode]
					,COUNT(c.[CurrencyCode]) AS [CurrencyUsage]
					FROM [Continents] AS co
					LEFT JOIN [Countries] AS c ON c.[ContinentCode] = co.[ContinentCode]
					GROUP BY co.[ContinentCode], c.[CurrencyCode]
				) AS [CurrencyUsage]
			WHERE [CurrencyUsage] > 1
		) AS [FINAL]
WHERE [RANK] = 1
ORDER BY [ContinentCode];

GO --16.	Countries Without Any Mountains

SELECT COUNT(*)
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
WHERE mc.[MountainId] IS NULL;

GO --17. Highest Peak and Longest River by Country

SELECT TOP (5) 
	 c.[CountryName]
	,MAX(p.[Elevation]) AS [HighestPeakElevation]
	,MAX(r.[Length]) AS [LongestRiverLength]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Peaks] AS p ON mc.[MountainId] = p.[MountainId]
LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
GROUP BY C.[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.[CountryName];

GO --18. Highest Peak Name and Elevation by Country (not included in final score)

SELECT TOP (5)
	 [CountryName] AS [Country]
	,CASE 
		WHEN [PeakName] IS NULL THEN '(no highest peak)'
		ELSE [PeakName]
	 END AS [Highest Peak Name]

	,CASE
		WHEN [Elevation] IS NULL THEN 0
		ELSE [Elevation]
	 END AS [Highest Peak Elevation]

	,CASE
		WHEN [MountainRange] IS NULL THEN '(no mountain)'
		ELSE [MountainRange]
	 END AS [Mountain]
FROM
	(
		SELECT  
			 c.[CountryName]
			,p.[PeakName]
			,p.[Elevation]
			,m.[MountainRange]
			,DENSE_RANK() OVER(PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [DenseRank]
		FROM [Countries] AS c
		LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
		LEFT JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
		LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
	) AS [RankedPeaks]
WHERE [DenseRank] = 1
ORDER BY [CountryName], [Highest Peak Name];


