using DoQL.Interfaces;
using DoQL.Models;
using DoQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = DoQL.Models.Action;
using Column = DoQL.Models.Column;

namespace DoQL.DatabaseProviders
{
    public class SqlServerDatabaseProvider : DatabaseProvider,ISQLExporter
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

        public string Export(Database db)
        {
            StringBuilder sqlCommands = new StringBuilder();
            sqlCommands.AppendLine($"CREATE DATABASE {db.Name};");
            sqlCommands.AppendLine("");
            sqlCommands.AppendLine($"USE {db.Name};");
            sqlCommands.AppendLine("");
            foreach (Table t in db.Tables)
            {
                sqlCommands.AppendLine($"CREATE TABLE {t.Name}(");
                List<string> primaryKeys = new List<string>();
                List<string> foreignKeys = new List<string>();
                foreach (Column a in t.Columns)
                {
                    StringBuilder constraints = new StringBuilder();
                    if (a.NotNull == true) { constraints.Append("NOT NULL "); }
                    if (a.Unique == true) { constraints.Append("UNIQUE "); }
                    if (a.AutoIncrement == true) { constraints.Append("IDENTITY(1,1) "); }
                    if (a.Primary == true) { primaryKeys.Add(a.Name); }

                    if (a.ForiegnReference != null)
                    {
                        StringBuilder foriegn = new StringBuilder($"  FOREIGN KEY ({a.Name}) REFERENCES ");
                        foreach (Table table in db.Tables)
                        {
                            if (table.Id == a.ForiegnReference.TableId)
                            {
                                foriegn.Append(table.Name);
                                foreach (Column attribute in table.Columns)
                                {
                                    if (attribute.Id == a.ForiegnReference.ColumnId)
                                    {
                                        foriegn.Append($"({attribute.Name}) ");
                                        break;
                                    }
                                }
                                break;
                            }
                        }

                        if (a.ForiegnReference.OnUpdateAction != Action.NoAction && a.ForiegnReference.OnUpdateAction != Action.Restrict)
                        {
                            foriegn.Append($"ON UPDATE {ActionFactory.GetActionString(a.ForiegnReference.OnUpdateAction)} ");
                        }
                        if (a.ForiegnReference.OnDeleteAction != Action.NoAction && a.ForiegnReference.OnUpdateAction != Action.Restrict)
                        {
                            foriegn.Append($"ON DELETE {ActionFactory.GetActionString(a.ForiegnReference.OnDeleteAction)} ");
                        }
                        foreignKeys.Add(foriegn.ToString());
                    }
                    string comma = (t.Columns.IndexOf(a) == t.Columns.Count - 1 && primaryKeys.Count
                        == 0 && foreignKeys.Count == 0) ? "" : ",";
                    sqlCommands.AppendLine($"  {a.Name} {a.DataType} {constraints}{comma}");
                }
                string primaryComma = (foreignKeys.Count > 0) ? "," : "";
                if (primaryKeys.Count > 0) { sqlCommands.AppendLine($"  PRIMARY KEY ({string.Join(", ", primaryKeys)}){primaryComma}"); }
                if (foreignKeys.Count > 0)
                {
                    foreignKeys.Reverse();
                    foreach (string key in foreignKeys)
                    {
                        string foreignComma = (foreignKeys.IndexOf(key) == foreignKeys.Count - 1) ? "" : ",";
                        sqlCommands.AppendLine(key + foreignComma);
                    }
                }
                sqlCommands.AppendLine(");");
                sqlCommands.AppendLine("");
            }
            return sqlCommands.ToString();
        }
    }
}
