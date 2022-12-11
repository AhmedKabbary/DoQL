using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoQL.Interfaces;
using DoQL.Models;
using DoQL.Utilities;
using Action = DoQL.Models.Action;
using Attribute = DoQL.Models.Attribute;

namespace DoQL.DatabaseProviders
{
    public class SqliteDatabaseProvider : DatabaseProvider,ISQLExporter
    {
        public override List<string> GetDataTypes()
        {
            List<string> types = new List<string> { "INT","INTEGER","TINYINT","SMALLINT","MEDIUMINT",
                "BIGINT","UNSIGNED BIG INT","INT2","INT8","CHARACTER","VARCHAR","VARYING CHARACTER","NCHAR","NATIVE CHARACTER","NVARCHAR",
                "TEXT","CLOB","BLOB","REAL","DOUBLE","DOUBLE PRECISION","FLOAT","NUMERIC","DECIMAL","BOOLEAN","DATE","DATETIME"};
            return types;
        }
        public override bool ValidateTableName(string tableName)
        {
            List<string> keyWords = new List<string> { "ABORT", "ACTION", "ADD", "AFTER", "ALL", "ALTER", "ALWAYS", "ANALYZE", "AND", "AS", "ASC", "ATTACH", "AUTOINCREMENT", "BEFORE", "BEGIN", "BETWEEN", "BY", "CASCADE", "CASE", "CAST", "CHECK", "COLLATE", "COLUMN", "COMMIT", "CONFLICT",
                "CONSTRAINT", "CREATE", "CROSS", "CURRENT", "CURRENT_DATE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "DATABASE", "DEFAULT", "DEFERRABLE", "DEFERRED", "DELETE", "DESC", "DETACH", "DISTINCT", "DO", "DROP", "EACH", "ELSE", "END", "ESCAPE", "EXCEPT", "EXCLUDE", "EXCLUSIVE", "EXISTS", "EXPLAIN", "FAIL", "FILTER", "FIRST", "FOLLOWING", "FOR",
                "FOREIGN", "FROM", "FULL", "GENERATED", "GLOB", "GROUP", "GROUPS", "HAVING", "IF", "IGNORE", "IMMEDIATE", "IN", "INDEX", "INDEXED", "INITIALLY", "INNER", "INSERT", "INSTEAD", "INTERSECT", "INTO", "IS", "ISNULL", "JOIN", "KEY", "LAST", "LEFT", "LIKE", "LIMIT", "MATCH",
                "MATERIALIZED", "NATURAL", "NO", "NOT", "NOTHING", "NOTNULL", "NULL", "NULLS", "OF", "OFFSET", "ON", "OR", "ORDER", "OTHERS", "OUTER", "OVER", "PARTITION", "PLAN", "PRAGMA", "PRECEDING", "PRIMARY", "QUERY", "RAISE", "RANGE", "RECURSIVE", "REFERENCES", "REGEXP", "REINDEX", "RELEASE",
                "RENAME", "REPLACE", "RESTRICT", "RETURNING", "RIGHT", "ROLLBACK", "ROW", "ROWS", "SAVEPOINT", "SELECT", "SET", "TABLE", "TEMP", "TEMPORARY", "THEN", "TIES", "TO", "TRANSACTION", "TRIGGER", "UNBOUNDED", "UNION", "UNIQUE", "UPDATE", "USING", "VACUUM", "VALUES", "VIEW", "VIRTUAL", "WHEN", "WHERE", "WINDOW", "WITH", "WITHOUT" };

            List<char> chars = new List<char> { '#', '@', '$', '/', '&', '*', '+', '-', '!', '.' };

            if(tableName.Contains(" ") == true)
            {
                return false;
            }

            if (tableName.Length >= 7)
            {
                string name = tableName.Substring(0, 7);
                if (name == "sqlite_")
                {
                    return false;
                }
            }

            if (int.TryParse($"{tableName[0]}",out int result) == true)
            {
                return false;
            }

            foreach (char c in chars)
            {
                if (tableName[0] == c)
                {
                    return false;
                    
                }
            }

            foreach (string s in keyWords)
            {
                if(tableName == s)
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
            foreach (Table t in db.Tables)
            {
                sqlCommands.AppendLine($"CREATE TABLE {t.Name}(");
                foreach (Attribute a in t.Attributes)
                {
                    StringBuilder constraints = new StringBuilder();
                    if (a.NotNull == true) { constraints.Append("NOT NULL "); }
                    if (a.Unique == true) { constraints.Append("UNIQUE "); }
                    if (a.AutoIncrement == true) { constraints.Append("AUTOINCREMENT "); }
                    if (a.Primary == true) { constraints.Append("PRIMARY KEY "); }

                    if (a.ForiegnReference != null)
                    {
                        StringBuilder foriegn = new StringBuilder("REFERENCES ");
                        foreach (Table table in db.Tables)
                        {
                            if (table.Id == a.ForiegnReference.TableId)
                            {
                                foriegn.Append(table.Name + "(");
                                foreach (Attribute attribute in table.Attributes)
                                {
                                    if (attribute.Id == a.ForiegnReference.AttributeId)
                                    {
                                        foriegn.Append(attribute.Name + ") ");
                                        break;
                                    }
                                }
                                break;
                            }
                        }

                        if (a.ForiegnReference.OnUpdateAction != Action.NoAction)
                        {
                            foriegn.Append($"ON UPDATE {ActionFactory.GetActionString(a.ForiegnReference.OnUpdateAction)} ");
                        }
                        if (a.ForiegnReference.OnDeleteAction != Action.NoAction)
                        {
                            foriegn.Append($"ON DELETE {ActionFactory.GetActionString(a.ForiegnReference.OnDeleteAction)} ");
                        }
                        constraints.Append(foriegn.ToString());
                    }
                    string comma = (t.Attributes.IndexOf(a) == t.Attributes.Count - 1) ? "" : ",";
                    sqlCommands.AppendLine($"  {a.Name} {a.DataType} {constraints}{comma}");
                }
                sqlCommands.AppendLine(");");
                sqlCommands.AppendLine("");
            }
            return sqlCommands.ToString();
        }
    }
}
