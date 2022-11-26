using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoQL.DatabaseProviders
{
    public class SqlServerDatabaseProvider : DatabaseProvider
    {
        public override List<string> GetDataTypes()
        {
            List<string> types = new List<string> {"BIGINT","NUMERIC","BIT","SMALLINT","DECIMAL","SMALLMONEY","INT","TINYINT","MONEY","FLOAT","REAL","DATE","DATETIMEOFFSET","DATETIME2","SMALLDATETIME","DATETIME","TIME","CHAR","VARCHAR","TEXT","NCHAR"
            ,"NVARCHAR","NTEXT","BINARY","VARBINARY","IMAGE","CURSOR","ROWVERSION","HIERARCHYID","UNIQUEIDENTIFIER","SQL_VARIANT","XML","SPATIALGEOMETRY","SPATIALGEOGRAPHY","TABLE"};
            return types;
        }
        public override bool ValidateTableName(string tableName)
        {
            List<string> keyWords = new List<string> { "ABORT", "ACTION", "ADD", "AFTER", "ALL", "ALTER", "ALWAYS", "ANALYZE", "AND", "AS", "ASC", "ATTACH", "AUTOINCREMENT", "BEFORE", "BEGIN", "BETWEEN", "BY", "CASCADE", "CASE", "CAST", "CHECK", "COLLATE", "COLUMN", "COMMIT", "CONFLICT",
                "CONSTRAINT", "CREATE", "CROSS", "CURRENT", "CURRENT_DATE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "DATABASE", "DEFAULT", "DEFERRABLE", "DEFERRED", "DELETE", "DESC", "DETACH", "DISTINCT", "DO", "DROP", "EACH", "ELSE", "END", "ESCAPE", "EXCEPT", "EXCLUDE", "EXCLUSIVE", "EXISTS", "EXPLAIN", "FAIL", "FILTER", "FIRST", "FOLLOWING", "FOR",
                "FOREIGN", "FROM", "FULL", "GENERATED", "COUNT", "GROUP", "GROUPS", "HAVING", "IF", "IGNORE", "IMMEDIATE", "IN", "INDEX", "INDEXED", "INITIALLY", "INNER", "INSERT", "INSTEAD", "INTERSECT", "INTO", "IS", "ISNULL", "JOIN", "KEY", "LAST", "LEFT", "LIKE", "LIMIT", "MATCH",
                "MATERIALIZED", "NATURAL", "NO", "NOT", "NOTHING", "NOTNULL", "NULL", "NULLS", "OF", "OFFSET", "ON", "OR", "ORDER", "OTHERS", "OUTER", "OVER", "PARTITION", "PLAN", "PRAGMA", "PRECEDING", "PRIMARY", "QUERY", "RAISE", "RANGE", "RECURSIVE", "REFERENCES", "REGEXP", "REINDEX", "RELEASE",
                "RENAME", "REPLACE", "RESTRICT", "RETURNING", "RIGHT", "ROLLBACK", "ROW", "ROWS", "SAVEPOINT", "SELECT", "SET", "TABLE", "TEMP", "TEMPORARY", "THEN", "TIES", "TO", "TRANSACTION", "TRIGGER", "UNBOUNDED", "UNION", "UNIQUE", "UPDATE", "USING", "VACUUM", "VALUES", "VIEW", "VIRTUAL", "WHEN", "WHERE", "WINDOW", "WITH", "WITHOUT" };

            List<char> chars = new List<char> { '#', '@', '$', '/', '&', '*', '+', '-', '!', '.', '_' };

            string upperName = tableName.ToUpper();

            if (upperName.Contains(" ") == true || upperName.Contains(".") == true || upperName.Contains("/") == true)
            {
                return false;
            }

            if (int.TryParse($"{upperName[0]}", out int result) == true)
            {
                return false;
            }

            foreach (char c in chars)
            {
                if (upperName[0] == c)
                {
                    return false;

                }
            }

            foreach (string s in keyWords)
            {
                if (upperName == s)
                {
                    return false;
                }
            }

            return true;
        }
        public override bool ValideteAttributeName(string attributeName)
        {
            return ValidateTableName(attributeName);
        }

        public override bool ValideteDataType(string dataType)
        {
            return GetDataTypes().Contains(dataType);
        }
    }
}
