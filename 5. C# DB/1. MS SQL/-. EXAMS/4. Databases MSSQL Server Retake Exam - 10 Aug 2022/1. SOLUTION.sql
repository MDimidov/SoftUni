--										Database Basics MS SQL Exam – 10.08.2022
--										100 National Tourist Sites of Bulgaria

CREATE DATABASE NationalTouristSitesOfBulgaria;

GO

USE NationalTouristSitesOfBulgaria;

--		Section 1. DDL (30 pts)

GO -- 1.	Database design

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	);
	
CREATE TABLE Locations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Municipality VARCHAR(50),
	Province VARCHAR(50)
	);

CREATE TABLE Sites(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Establishment VARCHAR(15) 
	);

CREATE TABLE Tourists(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT NOT NULL
			CHECK(Age >= 0 AND Age <= 120),
	PhoneNumber VARCHAR(20) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Reward VARCHAR(20)
	);


CREATE TABLE SitesTourists(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL,
	PRIMARY KEY (TouristId, SiteId)
	);

CREATE TABLE BonusPrizes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	);

CREATE TABLE TouristsBonusPrizes(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL,
	PRIMARY KEY (TouristId, BonusPrizeId)
	);


--			Section 2. DML (10 pts)

GO -- 2.	Insert

INSERT INTO Tourists([Name], Age, PhoneNumber, Nationality, Reward)
	VALUES
		('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
		('Peter Bosh', 48, '+447911844141', 'UK', NULL),
		('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
		('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
		('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL);

INSERT INTO Sites([Name], LocationId, CategoryId, Establishment)
	VALUES
		('Ustra fortress', 90, 7, 'X'),
		('Karlanovo Pyramids', 65, 7, NULL),
		('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
		('Sinite Kamani Natural Park', 17, 1, NULL),
		('St. Petka of Bulgaria – Rupite', 92, 6, '1994');

GO -- 3.	Update

UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL;

GO -- 4.	Delete

DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId IN (SELECT Id
			FROM BonusPrizes
			WHERE [Name] = 'Sleeping bag'
			);

DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag';

--			Section 3. Querying (40 pts)

GO -- 5.	Tourists

SELECT [Name]
	,Age
	,PhoneNumber
	,Nationality
FROM Tourists
ORDER BY Nationality, Age DESC, [Name];

GO -- 6.	Sites with Their Location and Category

SELECT s.[Name] AS [Site]
	,l.[Name] AS [Location]
	,s.Establishment
	,c.[Name] AS Category
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
JOIN Categories AS c ON s.CategoryId = c.Id
ORDER BY c.[Name] DESC, l.[Name], s.[Name];

GO -- 7.	Count of Sites in Sofia Province

SELECT l.Province
	,l.Municipality
	,l.[Name] AS [Location]
	,COUNT(s.Id) AS CountOfSites
FROM Locations AS l
JOIN Sites AS s ON s.LocationId = l.Id
WHERE l.Province = 'Sofia'
GROUP BY l.Province ,l.Municipality ,l.[Name]
ORDER BY CountOfSites DESC, [Location];

GO -- 8.	Tourist Sites established BC

SELECT s.[Name] AS [Site]
	,L.[Name] AS [Location]
	,l.Municipality
	,l.Province
	,s.Establishment
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
WHERE l.[Name] NOT LIKE '[BMD]%'
AND s.Establishment LIKE '% BC'
ORDER BY s.[Name];

GO -- 9.	Tourists with their Bonus Prizes

SELECT t.[Name]
	,t.Age
	,t.PhoneNumber
	,t.Nationality
	,CASE
		WHEN bP.[Name] IS NULL THEN '(no bonus prize)'
		ELSE bp.[Name]
	END AS Reward
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tbp ON t.Id = tbp.TouristId
LEFT JOIN BonusPrizes AS bp ON tbp.BonusPrizeId = bp.Id
ORDER BY t.[Name];

GO -- 10.	Tourists visiting History and Archaeology sites

SELECT DISTINCT RIGHT(t.[Name], LEN(t.[Name]) - CHARINDEX(' ', t.[Name])) AS LastName
	,t.Nationality
	,t.Age
	,T.PhoneNumber
FROM Sites AS s
JOIN SitesTourists AS st ON s.Id = st.SiteId
JOIN Tourists AS t ON st.TouristId = t.Id
WHERE CategoryId = 8
ORDER BY LastName;


--			Section 4. Programmability (20 pts)

GO -- 11.	Tourists Count on a Tourist Site

CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
BEGIN
			RETURN ( 
					SELECT COUNT(*)
					FROM Sites AS s
					JOIN SitesTourists AS st ON s.Id = st.SiteId
					WHERE s.[Name] = @Site
					);
END

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa');

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress');

GO -- 12.	Annual Reward Lottery

CREATE OR ALTER PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
		DECLARE @receivers INT = (
									SELECT COUNT(s.Id)
									FROM Sites AS s
									JOIN SitesTourists AS st ON st.SiteId = s.Id
									JOIN Tourists AS t ON st.TouristId = t.Id
									WHERE t.[Name] = @TouristName
									);
		DECLARE @badge VARCHAR(20) = NULL;

		IF(@receivers >= 100)
			BEGIN
				SET @badge = 'Gold badge';
			END
		ELSE IF(@receivers >= 50)
			BEGIN
				SET @badge = 'Silver badge';
			END
		ELSE IF(@receivers >= 25)
			BEGIN
				SET @badge = 'Bronze badge';
			END

		UPDATE Tourists
		SET Reward = @badge
		WHERE [Name] = @TouristName;
		
		SELECT [Name]
			,Reward
		FROM Tourists
		WHERE [Name] = @TouristName;
END

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard';

EXEC usp_AnnualRewardLottery 'Teodor Petrov';

EXEC usp_AnnualRewardLottery 'Zac Walsh';

EXEC usp_AnnualRewardLottery 'Brus Brown';