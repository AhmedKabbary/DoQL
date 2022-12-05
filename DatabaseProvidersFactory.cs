using DoQL.DatabaseProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoQL
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
