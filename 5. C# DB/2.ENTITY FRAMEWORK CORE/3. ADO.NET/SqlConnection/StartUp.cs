namespace SqlConnection
{
    using System.Text;
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            await using SqlConnection sqlConnection = 
                new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();


            using(sqlConnection)
            {
                //SqlCommand command = new SqlCommand(
                //    "SELECT COUNT(*) FROM Employees", sqlConnection);
                //int? employeesCount = (int?)command.ExecuteScalar();
                //Console.WriteLine("Employees count: {0} ", employeesCount);

                SqlCommand cmd = new(
                     SqlQueries.GetTotalEmplyees, sqlConnection);
                int? emplyeesCount = (int?)cmd.ExecuteScalar();
                Console.WriteLine($"Total employees: {emplyeesCount}");

                //Next Task
                cmd = new(SqlQueries.GetAllEmployees, sqlConnection);
                SqlDataReader employeesAllReader = cmd.ExecuteReader();
                using(employeesAllReader)
                {
                    while (employeesAllReader.Read())
                    {
                        string firstName = (string) employeesAllReader["FirstName"];
                        string lastName = (string)employeesAllReader["LastName"];
                        decimal salary = (decimal)employeesAllReader["Salary"];

                        Console.WriteLine($"{firstName} {lastName} -> {salary}");
                    }
                }

            }
        }
    }
}