using DoQL.Interfaces;
using DoQL.Models;
using DoQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = DoQL.Models.Table.Action;
using Column = DoQL.Models.Column;
using ForiegnReference = DoQL.Models.Table.ForiegnReference;

namespace DoQL.DatabaseProviders
{
    public class MySqlDatabaseProvider : DatabaseProvider,ISQLExporter
    {
        public override List<string> GetDataTypes()
        {
            List<string> types = new List<string> {"CHAR","VARCHAR","BINARY","VARBINARY","TINYBLOB","TINYTEXT","TEXT","BLOB","MEDIUMTEXT","MEDIUMBLOB","LONGTEXT","LONGBLOB","ENUM","SET","BIT","TINYINT",
            "BOOL","BOOLEAN","SMALLINT","MEDIUMINT","INT","INTEGER","BIGINT","FLOAT","DOUBLE","DECIMAL","DEC","DATE","DATETIME","TIMESTAMP","TIME","YEAR"};
            return types;
        }
        public override bool ValidateTableName(string tableName)
        {
            List<string> keyWords = new List<string> { "ABORT", "ACTION", "ADD", "AFTER", "ALL", "ALTER", "ALWAYS", "ANALYZE", "AND", "AS", "ASC", "ATTACH", "AUTOINCREMENT", "BEFORE", "BEGIN", "BETWEEN", "BY", "CASCADE", "CASE", "CAST", "CHECK", "COLLATE", "COLUMN", "COMMIT", "CONFLICT",
                "CONSTRAINT", "CREATE", "CROSS", "CURRENT", "CURRENT_DATE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "DATABASE", "DEFAULT", "DEFERRABLE", "DEFERRED", "DELETE", "DESC", "DETACH", "DISTINCT", "DO", "DROP", "EACH", "ELSE", "END", "ESCAPE", "EXCEPT", "EXCLUDE", "EXCLUSIVE", "EXISTS", "EXPLAIN", "FAIL", "FILTER", "FIRST", "FOLLOWING", "FOR",
                "FOREIGN", "FROM", "FULL", "GENERATED", "COUNT", "GROUP", "GROUPS", "HAVING", "IF", "IGNORE", "IMMEDIATE", "IN", "INDEX", "INDEXED", "INITIALLY", "INNER", "INSERT", "INSTEAD", "INTERSECT", "INTO", "IS", "ISNULL", "JOIN", "KEY", "LAST", "LEFT", "LIKE", "LIMIT", "MATCH",
                "MATERIALIZED", "NATURAL", "NO", "NOT", "NOTHING", "NOTNULL", "NULL", "NULLS", "OF", "OFFSET", "ON", "OR", "ORDER", "OTHERS", "OUTER", "OVER", "PARTITION", "PLAN", "PRAGMA", "PRECEDING", "PRIMARY", "QUERY", "RAISE", "RANGE", "RECURSIVE", "REFERENCES", "REGEXP", "REINDEX", "RELEASE",
                "RENAME", "REPLACE", "RESTRICT", "RETURNING", "RIGHT", "ROLLBACK", "ROW", "ROWS", "SAVEPOINT", "SELECT", "SET", "TABLE", "TEMP", "TEMPORARY", "THEN", "TIES", "TO", "TRANSACTION", "TRIGGER", "UNBOUNDED", "UNION", "UNIQUE", "UPDATE", "USING", "VACUUM", "VALUES", "VIEW", "VIRTUAL", "WHEN", "WHERE", "WINDOW", "WITH", "WITHOUT" };

            List<char> chars = new List<char> { '#', '@', '$', '/', '&', '*', '+', '-', '!', '.' };

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
        public override bool ValidateAttributeName(string attributeName)
        {
            return ValidateTableName(attributeName);
        }

        public override bool ValidateDataType(string dataType)
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
                List<Column> primaryKeys = t.Columns.Where(a => a.Primary == true).ToList();
                List<string> foreignKeys = new List<string>();
                foreach (Column C in t.Columns)
                {
                    StringBuilder constraints = new StringBuilder();
                    if (C.NotNull == true) { constraints.Append("NOT NULL "); }
                    if (C.Unique == true) { constraints.Append("UNIQUE "); }
                    if (C.AutoIncrement == true) { constraints.Append("AUTO_INCREMENT "); }

                    string comma = (t.Columns.IndexOf(C) == t.Columns.Count - 1 && primaryKeys.Count
                        == 0 && t.ForiegnReferences.Count == 0) ? "" : ",";
                    sqlCommands.AppendLine($"  {C.Name} {C.DataType} {constraints}{comma}");
                }
                string primaryComma = (t.ForiegnReferences.Count > 0) ? "," : "";
                if (primaryKeys.Count > 0)
                {
                    List<string> primaryNames = (from primary in primaryKeys select primary.Name).ToList();
                    sqlCommands.AppendLine($"  PRIMARY KEY ({string.Join(", ", primaryNames)}) {primaryComma}");
                }
                if (t.ForiegnReferences.Count > 0)
                {
                    foreach (ForiegnReference f in t.ForiegnReferences)
                    {
                        Table tf = new Table();
                        foreach (Table t0 in db.Tables)
                        {
                            if (t0.Id == f.TableId)
                            {
                                tf = t0;
                            }
                        }
                        List<Column> foreignPrimaries = tf.Columns.Where(a => a.Primary == true).ToList();
                        List<string> primariesNames = (from primary in foreignPrimaries select primary.Name).ToList();

                        List<string> foreignNames = (from foreign in primariesNames select $"{tf.Name}_{foreign}").ToList();
                        string foreignComma = (t.ForiegnReferences.IndexOf(f) == t.ForiegnReferences.Count - 1) ? "" : ",";

                        string onUpdate = "";
                        string onDelete = "";
                        if (f.OnUpdateAction != Action.NoAction)
                        {
                            onUpdate = $"ON UPDATE {ActionFactory.GetActionString(f.OnUpdateAction)} ";
                        }
                        if (f.OnDeleteAction != Action.NoAction)
                        {
                            onDelete = $"ON DELETE {ActionFactory.GetActionString(f.OnDeleteAction)} ";
                        }
                        sqlCommands.AppendLine($"  FOREIGN KEY ({string.Join(", ", foreignNames)}) REFERENCES {tf.Name}({string.Join(", ", primariesNames)}) {onUpdate}{onDelete}{foreignComma}");
                    }
                }
                sqlCommands.AppendLine(");");
                sqlCommands.AppendLine("");
            }
            return sqlCommands.ToString();
        }
    }
}
