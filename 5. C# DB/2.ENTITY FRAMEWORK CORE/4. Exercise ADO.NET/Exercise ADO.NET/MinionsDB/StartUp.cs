namespace MinionsDB
{
    using System.Linq;
    using System.Text;
    using Microsoft.Data.SqlClient;
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            //1. Initial Setup 
            //await using SqlConnection sqlConnectionMaster = 
            //    new(Config.ConnectionStringMaster);
            //await sqlConnectionMaster.OpenAsync();

            //await using SqlCommand sqlCommandCreateMinionsDB = new(SqlQueries.CreateMinionsDB, sqlConnectionMaster);
            //await sqlCommandCreateMinionsDB.ExecuteNonQueryAsync();

            //await using SqlConnection sqlConnectionMinionsDB = 
            //    new(Config.ConnectionStringMinionsDB);
            //await sqlConnectionMinionsDB.OpenAsync();

            //await using SqlCommand sqlCommandCreateTables = new(SqlQueries.CreateTables, sqlConnectionMinionsDB);
            //await sqlCommandCreateTables.ExecuteNonQueryAsync();


            await using SqlConnection sqlConnection =
                new(Config.ConnectionStringMinionsDB);
            await sqlConnection.OpenAsync();

            //2. Villain Names
            //string getAllVilians = await GetAllVilliansWhitTheirMinionsAsync(sqlConnection);
            //Console.WriteLine(getAllVilians);

            //3. Minion Names
            //int vilainId = int.Parse(Console.ReadLine());
            //string minionNames = await GetAllMinionsAndTheirAgeForViliant(sqlConnection, vilainId);
            //Console.WriteLine(minionNames);

            //4. Add Minion
            //string[] minionArgs = Console.ReadLine()
            //    .Split(' ')
            //    .Skip(1)
            //    .ToArray();

            //string villainName = Console.ReadLine()
            //    .Split(' ')
            //    .ToArray()[1];

            //string addMinion = await AddNewMinionsAsync(minionArgs, villainName, sqlConnection);
            //Console.WriteLine(addMinion);

            //5. Change Town Names Casing
            //string countryName = Console.ReadLine();
            //string changeTownNamesCasing = await ChangeTownsNameToUpperAndReturnsResult(countryName, sqlConnection);
            //Console.WriteLine(changeTownNamesCasing);

            //6. *Remove Villain 
            int villainId = int.Parse(Console.ReadLine());
            string removeVillainResult = await RemoveVillainAndReleaseMinions(villainId, sqlConnection);
            Console.WriteLine(removeVillainResult);

            //7. Print All Minion Names
            //string sortedMinions = await GetAllMinionsAndSortThem(sqlConnection);
            //Console.WriteLine(sortedMinions);

            //8. Increase Minion Age
            //int[] minonIDs = Console.ReadLine()
            //    .Split(' ')
            //    .Select(int.Parse)
            //    .ToArray();

            //string minons = await IncreaseMinonAgeAndLowerTheName(minonIDs, sqlConnection);
            //Console.WriteLine(minons);


            //9. Increase Age Stored Procedure 
            //int id = int.Parse(Console.ReadLine());
            //string getMinion = await IncreaseAgeSortedProcedure(id, sqlConnection);
            //Console.WriteLine(getMinion);

        }

        //2. Villain Names
        static async Task<string> GetAllVilliansWhitTheirMinionsAsync(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCommand =
                new SqlCommand(SqlQueries.GetAllVillainsAndCountOfTheirMinions, sqlConnection);
            // One row with many columns
            // First the reader hasn't loaded any data. We must call Read() first!
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} – {minionsCount}");
            }

            // No more data
            return sb.ToString().TrimEnd();
        }

        //3. Minion Names
        static async Task<string> GetAllMinionsAndTheirAgeForViliant(SqlConnection sqlConnection, int villiantId)
        {
            SqlCommand getVillianNameCommand =
                new(SqlQueries.GetVilianNameById, sqlConnection);
            getVillianNameCommand.Parameters.AddWithValue("@Id", villiantId);

            object? villainNameObj = await getVillianNameCommand.ExecuteScalarAsync();

            if( villainNameObj == null )
            {
                return $"No villain with ID ${villiantId} exists in the database.";
            }

            string villainName = (string)villainNameObj;

            SqlCommand getMinionsForCurrVilliantCmd =
                new(SqlQueries.GetAllMinionsNamesForVilians, sqlConnection);

            getMinionsForCurrVilliantCmd.Parameters.AddWithValue("@Id", villiantId);

            SqlDataReader minionsNameReader = await getMinionsForCurrVilliantCmd.ExecuteReaderAsync();

            string output =
                GenerateVillainWithMinionsOutput(villainName, minionsNameReader);
            return output;

        }

        private static string GenerateVillainWithMinionsOutput(string villainName, SqlDataReader minionsReader)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Villain: {villainName}");
            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNum = (long)minionsReader["RowNum"];
                    string minionName = (string)minionsReader["Name"];
                    int minionAge = (int)minionsReader["Age"];

                    sb.AppendLine($"{rowNum}. {minionName} {minionAge}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //4. Add Minion
        static async Task<string> AddNewMinionsAsync(string[] minionsArg, string villainName, SqlConnection sqlConnection)
        {
            string minionName = minionsArg[0];
            int minionAge = int.Parse(minionsArg[1]);
            string townName = minionsArg[2];

            StringBuilder sb = new();

            SqlCommand getTownId 
                = new(SqlQueries.GetTownIdFromTownName, sqlConnection);

            getTownId.Parameters.AddWithValue("@townName", townName);

            try
            {
                object? townIdObj = await getTownId.ExecuteScalarAsync();

                if (townIdObj == null)
                {
                    SqlCommand insertTown =
                        new(SqlQueries.InsertIntoTowns, sqlConnection);
                    insertTown.Parameters.AddWithValue("@townName", townName);

                    await insertTown.ExecuteNonQueryAsync();

                    sb.AppendLine($"Town {townName} was added to the database.");

                    townIdObj = await getTownId.ExecuteScalarAsync();
                }

                int? townId = (int?)townIdObj;


                SqlCommand insertMinion =
                    new(SqlQueries.InsertIntoMiinions, sqlConnection);

                insertMinion.Parameters.AddWithValue("@name", minionName);
                insertMinion.Parameters.AddWithValue("@age", minionAge);
                insertMinion.Parameters.AddWithValue("@townId", townId);

                await insertMinion.ExecuteNonQueryAsync();
                
                SqlCommand getVillainId =
                    new(SqlQueries.GetVillainIdFromName, sqlConnection);

                getVillainId.Parameters.AddWithValue("@Name", villainName);

                int? villainId = (int?) await getVillainId.ExecuteScalarAsync();
                if (villainId == null)
                {
                    SqlCommand insertVillain = 
                        new(SqlQueries.InsertIntoVillains, sqlConnection);

                    insertVillain.Parameters.AddWithValue("@villainName", villainName);

                    await insertVillain.ExecuteNonQueryAsync();

                    sb.AppendLine($"Villain {villainName} was added to the database.");

                    villainId = (int?) await getVillainId.ExecuteScalarAsync();
                }

                SqlCommand getMinionId = 
                    new(SqlQueries.GetMinionIdFromName, sqlConnection);

                getMinionId.Parameters.AddWithValue("@Name", minionName);

                int? minionId = (int?)await getMinionId.ExecuteScalarAsync();

                SqlCommand insertIntoMinonsVillains =
                    new(SqlQueries.InsetIntoMinionsVillains, sqlConnection);

                insertIntoMinonsVillains.Parameters.AddWithValue("@minionId", minionId);
                insertIntoMinonsVillains.Parameters.AddWithValue("@villainId", villainId);

                await insertIntoMinonsVillains.ExecuteNonQueryAsync();

                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
            catch(Exception ex)
            {
                
            }

            return sb.ToString().TrimEnd();
        }

        //5. Change Town Names Casing
        static async Task<string> ChangeTownsNameToUpperAndReturnsResult(string countryName, SqlConnection sqlConnection)
        {
            List<string> towns = new();

            SqlCommand updateTowns = 
                new(SqlQueries.updateTownsToUpper, sqlConnection);

            updateTowns.Parameters.AddWithValue("@countryName", countryName);

            await updateTowns.ExecuteNonQueryAsync();

            SqlCommand getTownsCmd = 
                new(SqlQueries.getAllTownsFromCountry, sqlConnection);

            getTownsCmd.Parameters.AddWithValue("@countryName", countryName);
            SqlDataReader getTownsReader = await getTownsCmd.ExecuteReaderAsync();

            while(getTownsReader.Read())
            {
                string townName = (string)getTownsReader["Name"];
                towns.Add(townName);
            }

            if (!towns.Any())
            {
                return $"No town names were affected.";
            }

            return $"{towns.Count} town names were affected.\n" +
                $"[{String.Join(", ", towns)}]";
        }

        //6. *Remove Villain 
        static async Task<string> RemoveVillainAndReleaseMinions(int villainId, SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            string result = string.Empty;

            try
            {
                SqlCommand GetVillainNameCmd =
                    new(SqlQueries.GetVilianNameById, sqlConnection, sqlTransaction);
                GetVillainNameCmd.Parameters.AddWithValue("@Id", villainId);
                string? villainName = (string?) await GetVillainNameCmd.ExecuteScalarAsync();

                if (villainName == null)
                {
                    return "No such villain was found.";
                }

                SqlCommand getReleasedMinions =
                    new(SqlQueries.GetReleasedMinions, sqlConnection, sqlTransaction);
                getReleasedMinions.Parameters.AddWithValue("@villainId", villainId);

                int? releasedMinions = (int?) await getReleasedMinions.ExecuteScalarAsync();

                SqlCommand releaseMinions =
                    new(SqlQueries.ReleaseMinonsFromVillain, sqlConnection, sqlTransaction);
                releaseMinions.Parameters.AddWithValue("@villainId", villainId);
                await releaseMinions.ExecuteNonQueryAsync();

                SqlCommand deleteVillain =
                    new(SqlQueries.DeleteVillain, sqlConnection, sqlTransaction);
                deleteVillain.Parameters.AddWithValue("@villainId", villainId);
                await deleteVillain.ExecuteNonQueryAsync();

                await sqlTransaction.CommitAsync();

                result = $"{villainName} was deleted.\n" +
                    $"{releasedMinions} minions were released.";
            }
            catch (Exception ex)
            {
                await sqlTransaction.RollbackAsync();
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        //7. Print All Minion Names
        static async Task<string> GetAllMinionsAndSortThem(SqlConnection sqlConnection)
        {
            List<string> minions = new();
            List<string> sortedMinions = new();

            SqlCommand getAllMinionsCmd = 
                new(SqlQueries.getAllMinionNames, sqlConnection);

            SqlDataReader getAllMinionsReader = await getAllMinionsCmd.ExecuteReaderAsync();

            int cnter = 1;
            
            while(getAllMinionsReader.Read())
            {
                string minionName = (string)getAllMinionsReader["Name"];
                minions.Add(cnter++ + minionName);
            }

            for(int i = 0; i < minions.Count / 2 ; i++)
            {
                sortedMinions.Add(minions[i]);
                sortedMinions.Add(minions[minions.Count - 1 - i]);
            }

            Console.WriteLine(string.Join(Environment.NewLine, minions));
            Console.WriteLine("-----------------");
            return string.Join(Environment.NewLine, sortedMinions);
        }

        //8. Increase Minion Age
        static async Task<string> IncreaseMinonAgeAndLowerTheName(int[] minonIds, SqlConnection sqlConnection)
        {
            SqlCommand updateMinion =
                new(SqlQueries.UpdateAgeAndNameOfMinonById, sqlConnection);


            for(int i = 0;i < minonIds.Length; i++)
            {
                int id = minonIds[i];
                updateMinion.Parameters.AddWithValue("@Id", id);
                await updateMinion.ExecuteNonQueryAsync();
                updateMinion.Parameters.Clear();
            }

            SqlCommand getAllMinonInfoCmd =
                new(SqlQueries.GetMinonNameAndAge, sqlConnection);
            SqlDataReader getAllMinionInfo = await getAllMinonInfoCmd.ExecuteReaderAsync();

            List<string> minions = new List<string>();

            while (getAllMinionInfo.Read())
            {
                string minionName = (string)getAllMinionInfo["Name"];
                int minionAge = (int)getAllMinionInfo["Age"];

                minions.Add($"{minionName} {minionAge}");
            }

            return string.Join(Environment.NewLine, minions);
        }

        //9. Increase Age Stored Procedure 
        static async Task<string> IncreaseAgeSortedProcedure(int id, SqlConnection sqlConnection)
        {
            SqlCommand increaseAge =
                new("dbo.usp_GetOlder", sqlConnection);
            increaseAge.CommandType = System.Data.CommandType.StoredProcedure;
            increaseAge.Parameters.AddWithValue("@id", id);
            await increaseAge.ExecuteNonQueryAsync();


            SqlCommand GetMinionNameAge =
                new(SqlQueries.GetMinionNameAndAgeFromId, sqlConnection);
            GetMinionNameAge.Parameters.AddWithValue("@Id", id);

            SqlDataReader ReadMinionNameAge = await GetMinionNameAge.ExecuteReaderAsync();

            string result = string.Empty;

            while(ReadMinionNameAge.Read())
            {
                string name = (string)ReadMinionNameAge["Name"];
                int age = (int)ReadMinionNameAge["Age"];

                result = $"{name} – {age} years old";
            }

            return result;
        }

    }
}