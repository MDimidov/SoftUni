

namespace MinionsDB
{
    public static class SqlQueries
    {
        public const string CreateMinionsDB =
            @"CREATE DATABASE MinionsDB";

        public const string CreateTables = 
            @"
              CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))

              CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))
              
              CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))
              
              CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))
              
              CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))
              
              CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))

              INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')

              INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 5)
              
              INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)
              
              INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')
              
              INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)
              
              INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,7),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1)
            ";

        public static string GetAllVillainsAndCountOfTheirMinions =
            @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                FROM Villains AS v 
                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                GROUP BY v.Id, v.Name 
                HAVING COUNT(mv.VillainId) > 3 
                ORDER BY COUNT(mv.VillainId)
            ";

        public static string GetVilianNameById =
            @"SELECT Name FROM Villains WHERE Id = @Id";

        public static string GetAllMinionsNamesForVilians =
            @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                       m.Name, 
                                                       m.Age
                                                  FROM MinionsVillains AS mv
                                                  JOIN Minions As m ON mv.MinionId = m.Id
                                                 WHERE mv.VillainId = @Id
                                              ORDER BY m.Name
            ";

        public static string GetVillainIdFromName =
            @"SELECT Id FROM Villains WHERE Name = @Name";

        public static string GetMinionIdFromName =
            @"SELECT MAX(Id) FROM Minions WHERE Name = @Name";

        public static string InsetIntoMinionsVillains =
            @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

        public static string InsertIntoVillains =
            @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public static string InsertIntoMiinions =
            @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public static string InsertIntoTowns =
            @"INSERT INTO Towns (Name) VALUES (@townName)";

        public static string GetTownIdFromTownName =
            @"SELECT Id FROM Towns WHERE Name = @townName";

        public static string updateTownsToUpper=
            @"UPDATE Towns
                SET Name = UPPER(Name)
              WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)
            ";

        public static string getAllTownsFromCountry =
            @" SELECT t.Name 
                FROM Towns as t
                JOIN Countries AS c ON c.Id = t.CountryCode
               WHERE c.Name = @countryName
            ";

        public static string getAllMinionNames =
            @"SELECT Name FROM Minions";

        public static string UpdateAgeAndNameOfMinonById =
            @"UPDATE Minions
                SET Name = lower(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
              WHERE Id = @Id
            ";

        public static string GetMinonNameAndAge =
            @"SELECT Name, Age FROM Minions";

        public static string ProcGetOlder =
            @"EXEC dbo.usp_GetOlder @id";

        public static string GetMinionNameAndAgeFromId =
            @"SELECT Name, Age FROM Minions WHERE Id = @Id";

        public static string ReleaseMinonsFromVillain =
            @"DELETE FROM MinionsVillains 
                  WHERE VillainId = @villainId
            ";

        public static string DeleteVillain =
            @"DELETE FROM Villains
                  WHERE Id = @villainId
            ";

        public static string GetReleasedMinions =
            @"SELECT COUNT(VillainId) FROM MinionsVillains WHERE VillainId = @villainId";
    }
}
