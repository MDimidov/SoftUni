--									Database Basics MS SQL Exam – 10 December 2021
--														Airport

CREATE DATABASE Airport;

GO

USE Airport;

--			Section 1. DDL (30 pts)

GO -- 1.	Database design

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
	);

CREATE TABLE Pilots(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT 
			CHECK(Age >= 21 AND Age <=62) NOT NULL,
	Rating FLOAT
			CHECK(Rating >= 0.0 AND Rating <= 10.0)
	);

CREATE TABLE AircraftTypes(
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
	);
	
CREATE TABLE Aircraft(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
	);

CREATE TABLE PilotsAircraft(
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PilotId INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL,
	PRIMARY KEY (AircraftId, PilotId)
	);

CREATE TABLE Airports(
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
	);

CREATE TABLE FlightDestinations(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	[Start] DateTime NOT NULL,
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(18, 2) NOT NULL DEFAULT(15)
	);

--			Section 2. DML (10 pts)

GO -- 2.	Insert

INSERT INTO Passengers (FullName, Email)
		SELECT CONCAT(FirstName, ' ', LastName) AS FullName  
			,CONCAT(FirstName, LastName, '@gmail.com') AS Email
		FROM Pilots
		WHERE Id BETWEEN 5 AND 15;

GO -- 3.	Update

UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B')
AND [Year] >= 2013
AND (FlightHours IS NULL OR FlightHours <= 100);

GO -- 4.	Delete

DELETE FROM FlightDestinations
WHERE PassengerId IN (	SELECT Id
						FROM Passengers
						WHERE LEN(FullName) <= 10
						);

DELETE FROM Passengers
WHERE LEN(FullName) <= 10;

--			Section 3. Querying (40 pts)

GO -- 5.	Aircraft

SELECT Manufacturer
	,Model
	,FlightHours
	,Condition
FROM Aircraft
ORDER BY FlightHours DESC;

GO -- 6.	Pilots and Aircraft

SELECT p.FirstName
	,p.LastName
	,a.Manufacturer
	,a.Model
	,a.FlightHours
FROM Pilots AS p
JOIN PilotsAircraft AS pa ON p.Id = pa.PilotId
JOIN Aircraft AS a ON pa.AircraftId = a.Id
WHERE a.FlightHours <= 304 
AND a.FlightHours IS NOT NULL
ORDER BY a.FlightHours DESC, p.FirstName;

GO -- 7.	Top 20 Flight Destinations

SELECT TOP(20)
	 fd.Id AS DestinationId
	,fd.[Start]
	,p.FullName
	,a.AirportName
	,fd.TicketPrice
FROM FlightDestinations AS fd
JOIN Airports AS a ON fd.AirportId = a.Id
JOIN Passengers AS p ON fd.PassengerId = p.Id
WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
ORDER BY fd.TicketPrice DESC;

GO -- 8.	Number of Flights for Each Aircraft

SELECT fd.AircraftId
	,a.Manufacturer
	,a.FlightHours
	,COUNT(fd.Id) AS FlightDestinationsCount
	,ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a
JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
GROUP BY fd.AircraftId ,a.Manufacturer ,a.FlightHours
HAVING COUNT(fd.Id) >= 2
ORDER BY FlightDestinationsCount DESC, fd.AircraftId;

GO -- 9.	Regular Passengers

SELECT p.FullName
	,COUNT(a.Id) AS CountOfAircraft
	,SUM(fd.TicketPrice) AS TotalPayed
FROM Passengers AS p
JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
JOIN Aircraft AS a ON fd.AircraftId = a.Id
WHERE RIGHT(LEFT(p.FullName, 2), 1) = 'A'
GROUP BY p.FullName
HAVING COUNT(a.Id) > 1
ORDER BY p.FullName;

GO -- 10.	Full Info for Flight Destinations

 SELECT a.AirportName
	,fd.[Start] AS DayTime
	,fd.TicketPrice
	,p.FullName
	,ac.Manufacturer
	,ac.Model
 FROM FlightDestinations AS fd
 JOIN Airports AS a ON fd.AirportId = a.Id
 JOIN Passengers AS p ON p.Id = fd.PassengerId
 JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
 WHERE DATEPART(HOUR, fd.[Start]) BETWEEN 6 AND 20
 AND fd.TicketPrice > 2500
 ORDER BY ac.Model;

 --			Section 4. Programmability (20 pts)

 GO -- 11.	Find all Destinations by Email Address

 CREATE FUNCTION udf_FlightDestinationsByEmail(@email NVARCHAR(50))
 RETURNS INT 
 AS 
 BEGIN
	RETURN (SELECT COUNT(fd.Id)
			FROM Passengers AS p
			JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
			WHERE p.Email = @email
			);
 END

 SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com');

 SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com');

 SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com');

 GO -- 12.	Full Info for Airports

 CREATE PROC usp_SearchByAirportName @airportName NVARCHAR(70)
 AS
 BEGIN
			SELECT a.AirportName
				,p.FullName
				,CASE	
					WHEN fd.TicketPrice <= 400 THEN 'Low'
					WHEN fd.TicketPrice <= 1500 THEN 'Medium'
					ELSE 'High'
				END AS LevelOfTickerPrice
				,ac.Manufacturer
				,ac.Condition
				,[at].TypeName
			FROM Airports AS a
			JOIN FlightDestinations AS fd ON a.Id = fd.AirportId
			JOIN Passengers AS p ON fd.PassengerId = p.Id
			JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
			JOIN AircraftTypes AS [at] ON ac.TypeId = [at].Id
			WHERE a.AirportName = @airportName
			ORDER BY ac.Manufacturer, p.FullName;
 END

 EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport';