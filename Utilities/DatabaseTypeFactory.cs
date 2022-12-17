namespace DoQL.Utilities
{
    class DatabaseTypeFactory
    {
        public static string GetDatabaseTypeString(DatabaseType type)
        {
            return type switch
            {
                DatabaseType.SQLite => "SQLite",
                DatabaseType.MySQL => "MySQL",
                DatabaseType.SQLServer => "SQL Server",
                _ => throw new ArgumentException("Unknown type")
            };
        }

        public static Color GetDatabaseTypeColor(DatabaseType type)
        {
            return type switch
            {
                DatabaseType.SQLite => Color.LightSeaGreen,
                DatabaseType.MySQL => Color.DarkOrange,
                DatabaseType.SQLServer => Color.DarkViolet,
                _ => throw new ArgumentException("Unknown type")
            };
        }
    }
}
