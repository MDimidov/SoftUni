--				Part I – Queries for Gringotts Database
USE [Gringotts];
GO -- 1. Records' Count

SELECT COUNT(*) AS [Count] 
FROM [WizzardDeposits];

GO -- 02. Longest Magic Wand

SELECT MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits];

GO -- 03. Longest Magic Wand per Deposit Groups

SELECT [DepositGroup]
	,MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits]
GROUP BY [DepositGroup];

GO -- 04. Smallest Deposit Group per Magic Wand Size (not included in final score)


SELECT TOP (2)
		[DepositGroup]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize]);

GO -- 05. Deposits Sum

SELECT [DepositGroup]
	,SUM(w.[DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits] AS w
GROUP BY [DepositGroup];

GO -- 06. Deposits Sum for Ollivander Family

SELECT [DepositGroup]
	,SUM(w.[DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits] AS w
WHERE w.[MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup];

GO -- 07. Deposits Filter

	-- EXAMPLE 1
SELECT *
FROM
	(
	SELECT [DepositGroup]
		,SUM(w.[DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits] AS w
	WHERE w.[MagicWandCreator] = 'Ollivander family'
	GROUP BY [DepositGroup]
	) AS dp
WHERE [TotalSum] < 150000
ORDER BY [TotalSum] DESC;

GO	-- EXAMPLE2
SELECT [DepositGroup]
	,SUM(w.[DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits] AS w
WHERE w.[MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
HAVING SUM(w.[DepositAmount]) < 150000
ORDER BY [TotalSum] DESC;

GO -- 08. Deposit Charge

SELECT w.[DepositGroup]
	,w.[MagicWandCreator]
	,MIN(w.[DepositCharge]) AS [MinDepositCharge]
FROM [WizzardDeposits] AS w
GROUP BY w.[DepositGroup], w.[MagicWandCreator]
ORDER BY w.[MagicWandCreator], w.[DepositGroup];

GO --09. Age Groups

SELECT *
	,COUNT(*) AS [WizardCount]
	FROM
	(
	SELECT CASE
				WHEN [Age] <= 10 THEN '[0-10]'
				WHEN [Age] <= 20 THEN '[11-20]'
				WHEN [Age] <= 30 THEN '[21-30]'
				WHEN [Age] <= 40 THEN '[31-40]'
				WHEN [Age] <= 50 THEN '[41-50]'
				WHEN [Age] <= 60 THEN '[51-60]'
				ELSE '[61+]'
			END AS [AgeGroup]
	FROM [WizzardDeposits]
	) AS dp
GROUP BY [AgeGroup];

GO -- 10. First Letter

SELECT DISTINCT LEFT(w.[FirstName], 1) AS [FirstLetter]
FROM [WizzardDeposits] AS w
WHERE w.[DepositGroup] = 'Troll Chest'
ORDER BY [FirstLetter];

GO -- 11. Average Interest

SELECT
	 [DepositGroup]
	,[IsDepositExpired]
	,AVG([DepositInterest]) AS [AverageInterest]
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired];

GO -- 12. *Rich Wizard, Poor Wizard (not included in final score)

SELECT SUM([RESULT])
FROM
	(
	SELECT 
		CASE WHEN w1.[Id] - w2.[Id] = 1 THEN (w2.[DepositAmount] - w1.[DepositAmount]) END AS [RESULT]
	FROM [WizzardDeposits] AS w1
	CROSS JOIN [WizzardDeposits] AS w2
	) AS dp;


--				Part II – Queries for SoftUni Database
USE [SoftUni]
GO -- 13. Departments Total Salaries

SELECT [DepartmentID]
	,SUM([Salary]) AS [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentID];

GO -- 14. Employees Minimum Salaries


SELECT [DepartmentID]
	,MIN([Salary]) AS [MinimumSalary]
FROM [Employees]
WHERE [DepartmentID] IN (2, 5, 7) 
AND DATEPART(YEAR, [HireDate]) >= 2000
GROUP BY [DepartmentID];

GO -- 15. Employees Average Salaries

SELECT *
		INTO [EmployeesSalaryMoreThan30000]
	FROM [Employees]
	WHERE [Salary] > 30000;

DELETE 
	FROM [EmployeesSalaryMoreThan30000]
	WHERE [ManagerID] = 42;

UPDATE [EmployeesSalaryMoreThan30000]
	SET [Salary] += 5000
	WHERE [DepartmentID] = 1;

SELECT [DepartmentID]
	,AVG([Salary]) AS [AverageSalary]
	FROM [EmployeesSalaryMoreThan30000]
	GROUP BY [DepartmentID];




GO -- 16. Employees Maximum Salaries

SELECT [DepartmentID]
	,MAX([Salary]) AS [MaxSalary]
FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) < 30000 OR MAX([Salary]) > 70000;

GO -- 17. Employees Count Salaries

SELECT COUNT([Salary])
FROM [Employees]
WHERE [ManagerID] IS NULL;

GO -- 18. *3rd Highest Salary (not included in final score)

SELECT DISTINCT 
	 [DepartmentID]
	,[Salary]
FROM
	(
	SELECT [DepartmentID]
		,[Salary]
		,DENSE_RANK() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Rank]
	FROM [Employees]
	) AS dp
WHERE [Rank] = 3;

GO --19. **Salary Challenge (not included in final score)

SELECT TOP(10) e.[FirstName]
	,e.[LastName]
	,e.[DepartmentID]
FROM [Employees] AS e
JOIN (
	SELECT [DepartmentID]
		,AVG([Salary]) AS [AverageSalary]
	FROM Employees
	GROUP BY [DepartmentID]
	) AS dp ON e.[DepartmentID] = dp.[DepartmentID]
WHERE e.[Salary] > dp.[AverageSalary];