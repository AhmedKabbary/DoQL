namespace DoQL.DatabaseProviders
{
    class DatabaseProvidersFactory
    {
        public static DatabaseProvider GetDatabaseProvider(DatabaseType type)
        {
            return type switch
            {
                DatabaseType.MySQL => new MySqlDatabaseProvider(),
                DatabaseType.SQLite => new SqliteDatabaseProvider(),
                DatabaseType.SQLServer => new SqlServerDatabaseProvider(),
                _ => throw new ArgumentException("Unknown database type"),
            };
        }
    }
}
