--					Part I - Queries for Bank Database

USE [Bank]

GO -- 1.	Create Table Logs

CREATE TABLE [Logs] (
	[LogId] INT PRIMARY KEY IDENTITY,
	[AccountId] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL,
	[OldSum] MONEY,
	[NewSum] MONEY
	)

CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON [Accounts] FOR UPDATE
AS
	INSERT INTO [Logs]([AccountId], [OldSum], [NewSum])
	SELECT i.[Id], d.[Balance], i.[Balance]
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance <> d.Balance

SELECT * FROM [Logs]

UPDATE [Accounts]
SET [Balance] *= 1.5
WHERE [Balance] < 500

GO -- 02. Create Table Emails

CREATE TABLE [NotificationEmails](
	[Id] INT PRIMARY KEY IDENTITY,
	[Recipient] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL,
	[Subject] VARCHAR(50) NOT NULL,
	[Body] VARCHAR(100) NOT NULL
	)

CREATE TRIGGER tr_AddToLogsOnAccountInsert
ON [Accounts] FOR UPDATE
AS
	INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
	SELECT i.[Id]
		,CONCAT('Balance change for account: ', i.[Id]) AS [Subject]
		,CONCAT('On ', GETDATE(),' your balance was changed from ', d.[Balance],' to ',i.[Balance],'.') AS [Body]
	FROM INSERTED AS i
	JOIN DELETED AS d ON i.[Id] = d.[Id]
	WHERE i.[Balance] <> d.[Balance]

UPDATE [Accounts]
SET [Balance] *= 1.5
WHERE [Balance] < 1000

SELECT * FROM [NotificationEmails]

GO -- 03. Deposit Money

CREATE OR ALTER PROC usp_DepositMoney @accountId INT, @moneyAmount DECIMAL (18, 4)
AS
BEGIN	
	BEGIN TRANSACTION 
		IF @moneyAmount < 0
			BEGIN
				ROLLBACK
			END

		UPDATE [Accounts]
		SET [Balance] += @moneyAmount
		WHERE [Id] = @accountId
	COMMIT
END


-----TEST------
EXEC usp_DepositMoney 1, 10;
select * from Accounts
WHERE id = 1;

GO -- 04. Withdraw Money Procedure

CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(18, 4))
AS
BEGIN
	BEGIN TRANSACTION
		UPDATE [Accounts]
		SET [Balance] -= @moneyAmount
		WHERE [Id] = @accountId;
		IF (@@ROWCOUNT <> 1)
			BEGIN
				ROLLBACK
			END
		COMMIT
END

GO -- 05. Money Transfer




CREATE OR ALTER PROC usp_TransferMoney @SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4)
AS
BEGIN
	BEGIN TRANSACTION
	IF ((SELECT a.id FROM accounts as a WHERE a.id = @SenderId) IS NULL)
			OR ((SELECT a.id FROM accounts as a WHERE a.id = @ReceiverId) IS NULL)
			OR @SenderId = @ReceiverId
			OR @Amount < 0 
			OR @Amount > (SELECT a.balance FROM accounts as a
				     WHERE a.id = @SenderId)
		BEGIN
			ROLLBACK
		END
	ELSE 
		BEGIN
		UPDATE [Accounts] 
		SET [Balance]  -= @Amount
		WHERE [Id] = @SenderId;
		UPDATE accounts
		SET [Balance] += @Amount
		WHERE [Id] = @ReceiverId;
		END
	COMMIT
END


EXEC dbo.usp_TransferMoney 5, 1, 5000

SELECT * 
FROM [ACCOUNTS]
WHERE [Id] IN (1, 5)



--					Part II - Queries for Diablo Database

--USE [Diablo];

--GO -- 07. *Massive Shopping (not included in final score)

--BEGIN TRANSACTION
	


--SELECT * 
--FROM USERSGAMES AS ug
--JOIN users AS u ON u.Id = ug.UserId
--where u.Username in ('Stamat', 'Safflower')

--SELECT * FROM ITEMS
--ORDER BY [MINLEVEL]


--					Part III - Queries for SoftUni Database

use [SoftUni];

GO -- 8.	Employees with Three Projects

CREATE OR ALTER PROC usp_AssignProject @emloyeeId INT, @projectID INT
AS
BEGIN
	DECLARE @currProjects INT;
	BEGIN TRANSACTION
		
		INSERT INTO [EmployeesProjects] ([EmployeeID], [ProjectID])
			VALUES (@emloyeeId, @projectID);

		SET @currProjects = (	SELECT COUNT([ProjectID])
								FROM [EmployeesProjects]
								WHERE [EmployeeID] = @emloyeeId
								GROUP BY [EmployeeID]
							);

		IF (@currProjects > 3)
			BEGIN
				RAISERROR ('The employee has too many projects!', 16, 1);
				ROLLBACK;
			END
		COMMIT	
END


GO -- 09. Delete Employees

CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	JobTitle VARCHAR (50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES [Departments]([DepartmentID]) NOT NULL,
	Salary MONEY NOT NULL);

CREATE OR ALTER TRIGGER tr_DeletedEmployee
ON [Employees] for DELETE
AS
	INSERT INTO [Deleted_Employees](FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT d.[FirstName], d.[LastName], d.[MiddleName], d.[JobTitle], d.[DepartmentID], d.[Salary]
	FROM deleted as d


DELETE FROM [Employees]
WHERE [EmployeeID] = 2

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

