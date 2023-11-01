

namespace SqlConnection
{
    public static class SqlQueries
    {
        public const string GetTotalEmplyees =
            @"SELECT COUNT(*) FROM Employees";

        public const string GetAllEmployees =
            @"SELECT * FROM Employees";
    }
}
