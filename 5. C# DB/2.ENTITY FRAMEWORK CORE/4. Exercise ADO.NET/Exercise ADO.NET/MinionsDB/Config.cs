namespace MinionsDB
{
    
    internal static class Config
    {
        public static string ConnectionStringMaster =
            @"Server=.\SQLEXPRESS;Database=master;Integrated Security=True;TrustServerCertificate=True";

        public static string ConnectionStringMinionsDB =
            @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=True;TrustServerCertificate=True";
    }
}
