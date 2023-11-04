--					Part I – Queries for SoftUni Database

USE [SoftUni];

GO -- 1.	Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
	--(@minSalary INT = 35000)
AS
	SELECT [FirstName], [LastName] 
	FROM [Employees]
	WHERE [Salary] > 35000; --@minSalary;

EXEC usp_GetEmployeesSalaryAbove35000;

GO -- 2.	Employees with Salary Above Number

CREATE PROC usp_GetEmployeesSalaryAboveNumber
	(@minSalary DECIMAL(18,4))
AS
	SELECT [FirstName], [LastName] 
	FROM [Employees]
	WHERE [Salary] >= @minSalary;

EXEC usp_GetEmployeesSalaryAboveNumber 48100;

GO -- 3.	Town Names Starting With

CREATE PROC usp_GetTownsStartingWith
	(@startString NVARCHAR(50))
AS 
	SELECT t.[Name] AS [Town] 
	FROM [Towns] AS t
	WHERE t.[Name] LIKE @startString + '%';

EXEC usp_GetTownsStartingWith 'B'

GO -- 04. Employees from Town

CREATE PROC usp_GetEmployeesFromTown
	(@town NVARCHAR(50))
AS 
	SELECT e.[FirstName]
		,e.[LastName]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON a.[AddressID] = e.[AddressID]
	JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
	WHERE t.[Name] = @town;

EXEC usp_GetEmployeesFromTown 'SOFIA';

GO -- 05. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel
	(@salary DECIMAL(18,4))
	RETURNS NVARCHAR(7)
AS
BEGIN
	DECLARE @RESULT NVARCHAR(7) = 'Average';
	IF (@salary < 30000)
		BEGIN
			SET @RESULT = 'Low';
		END
	IF @salary > 50000
		BEGIN
			SET @RESULT = 'High';
		END
	RETURN @RESULT;
END

------------TEST--------------
SELECT [Salary]
	,dbo.ufn_GetSalaryLevel([Salary])
FROM [Employees];

GO -- 06. Employees by Salary Level

CREATE PROC usp_EmployeesBySalaryLevel
	(@salaryLevel NVARCHAR(7))
AS
	SELECT e.[FirstName]
		,e.[LastName]
	FROM
		(
		SELECT *
			,dbo.ufn_GetSalaryLevel([Salary]) AS [Salary Level]
		FROM [Employees]
		) AS e
	WHERE e.[Salary Level] = @salaryLevel

EXEC usp_EmployeesBySalaryLevel 'high'

GO -- 07. Define Function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN	
	DECLARE @wordIndex INT = 1;
	WHILE (@wordIndex <= LEN(@word))
		BEGIN
			DECLARE @currentCharacter VARCHAR(1) = SUBSTRING(@word, @wordIndex, 1);

			IF (CHARINDEX(@currentCharacter, @setOfLetters) = 0)
				BEGIN
					RETURN 0;
				END

				SET @wordIndex += 1;
		END

		RETURN 1;
END

GO

------------TEST-----------
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy');

GO -- 8.	Delete Employees and Departments

CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment @departmentId INT
AS
BEGIN

	DECLARE @emplyeesID TABLE ([Id] INT);
	INSERT INTO @emplyeesID 
	SELECT [EmployeeID]
	FROM [Employees]
	WHERE [DepartmentID] = @departmentId;

	DELETE 
	FROM [EmployeesProjects]
	WHERE [EmployeeID] IN (SELECT * FROM @emplyeesID);

	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT;

	UPDATE [Departments] 
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN (SELECT * FROM @emplyeesID);	

	UPDATE [Employees] 
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN (SELECT * FROM @emplyeesID);	

		DELETE 
	FROM [Employees]
	WHERE [DepartmentID] = @departmentId;

	DELETE 
	FROM [Departments]
	WHERE [DepartmentID] = @departmentId;

	SELECT COUNT(*)
	FROM [Employees]
	WHERE [DepartmentID] = @departmentId;
	
END


EXEC dbo.usp_DeleteEmployeesFromDepartment 3

--					Part II – Queries for Bank Database

USE [Bank];

GO -- 9.	Find Full Name

CREATE PROC usp_GetHoldersFullName
AS
BEGIN 
	SELECT CONCAT(a.[FirstName], ' ', a.[LastName]) AS [Full Name]
	FROM [AccountHolders] AS a;
END

-------TEST---------
EXEC usp_GetHoldersFullName

GO -- 10.	People with Balance Higher Than

CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan @money MONEY
AS
BEGIN

	SELECT ah.[FirstName]
	,ah.[LastName]
	FROM
		(
			SELECT ah.[FirstName]
				,ah.[LastName]
				,SUM(a.[Balance]) AS [TOTAL]
			FROM [AccountHolders] AS ah
			JOIN [AccountS] AS a ON ah.[Id] = a.[AccountHolderId]
			GROUP BY ah.[FirstName], ah.[LastName]
		) AS ah
	WHERE [TOTAL] > @money
	ORDER BY ah.[FirstName], ah.[LastName];
END

-------TEST---------
EXEC dbo.usp_GetHoldersWithBalanceHigherThan 60000.02

GO -- 11.	Future Value Function

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@sum decimal(15,4), @yearlyInterestRate float, @numOfYears INT)
RETURNS DECIMAL(15,4)
AS BEGIN
		RETURN @sum * POWER(( 1 + @yearlyInterestRate ), @numOfYears)
	END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5)

--SELECT ROUND(1000.00 * POWER(( 1 + 10.0 / 100 ), 5), 4)

--SELECT FORMAT(ROUND(500000 * POWER(( 1 + 0.61 ), 23), 4), '0.0000');

--SELECT CEILING(ROUND(1000.00 * POWER(( 1 + 10.0 / 100 ), 5), 4)*10000)/ 10000


GO -- 12. Calculating Interest

CREATE OR ALTER PROC usp_CalculateFutureValueForAccount @accountId INT, @yearlyInterestRate FLOAT
AS
	BEGIN
		SELECT TOP(1) ah.[Id] AS [Account Id]
			,ah.[FirstName] AS [First Name]
			,ah.[LastName] AS [Last Name]
			,a.[Balance] AS [Current Balance]
			,dbo.ufn_CalculateFutureValue(a.[Balance], @yearlyInterestRate, 5) AS [Balance in 5 years]
		FROM [AccountHolders] AS ah
		JOIN [Accounts] AS a ON ah.[Id] = a.[AccountHolderId]
		WHERE ah.[Id] = @accountId
	END

-------TEST---------
EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1

--					Part III – Queries for Diablo Database

USE [Diablo];

GO -- 13.	*Scalar Function: Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS
		RETURN
			(
			SELECT SUM([Cash]) AS [SumCash]
			FROM
				(
				SELECT g.[Name] AS [GAMENAME]
				,ug.[Cash]
				,ROW_NUMBER() OVER(ORDER BY ug.[Cash] DESC) AS [ROW]
			FROM [Games] AS g
			INNER JOIN [UsersGames] AS ug ON ug.[GameId] = g.[Id]
			WHERE g.[Name] = @gameName
				) AS SUBQ
			WHERE [ROW] % 2 = 1
			)
-------------TEST---------------
SELECT 
* 
FROM dbo.ufn_CashInUsersGames('Love in a mist')