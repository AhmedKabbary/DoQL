using DoQL.DatabaseProviders;
using DoQL.Models;
using DoQL.Models.ERD;

namespace DoQL.Utilities
{
    public class DatabaseValidator
    {
        public static void Validate(Database db)
        {
            DatabaseProvider databaseProvider = DatabaseProvidersFactory.GetDatabaseProvider(db.Type);

            HashSet<string> errors = new HashSet<string>();
            foreach(var entity in db.Erd.Entities)
            {
                if (!databaseProvider.ValidateTableName(entity.TableName))
                    throw new Exception($"Table name of {entity.DisplayName} entity is invalid");
                
                if(!errors.Add(entity.TableName))
                    throw new Exception($"Table {entity.TableName} is duplicated ");
            }
            errors.Clear();

            foreach (var attribute in db.Erd.Attributes)
            {
                if (!databaseProvider.ValidateAttributeName(attribute.ColumnName))
                    throw new Exception($"Column name of {attribute.DisplayName} attribute is invalid");
                if (!databaseProvider.ValidateDataType(attribute.DataType))
                    throw new Exception($"Data type of {attribute.DisplayName} attribute is invalid");
            }
            errors.Clear();

            foreach (var relationship in db.Erd.Relationships)
            {
                if (relationship.IsManyToMany())
                {
                    if (!databaseProvider.ValidateTableName(relationship.TableName))
                        throw new Exception($"Table name of {relationship.DisplayName} relationship is invalid");
                    if (!errors.Add(relationship.TableName))
                        throw new Exception($"Table {relationship.TableName} is duplicated ");
                }
            }
        }
    }
}
