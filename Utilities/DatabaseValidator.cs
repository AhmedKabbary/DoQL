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

            HashSet<string> entities = new HashSet<string>();
            foreach (var entity in db.Erd.Entities)
            {
                if (!databaseProvider.ValidateTableName(entity.TableName))
                    throw new Exception($"Table name of {entity.DisplayName} entity is invalid");

                if (!entities.Add(entity.TableName))
                    throw new Exception($"Table {entity.TableName} is duplicated ");
            }

            var entitiesAttributes = new Dictionary<string, HashSet<string>>(); // <entityId, attributesNames>
            var relationshipsAttributes = new Dictionary<string, HashSet<string>>(); // <relationshipID, attributesNames>
            foreach (var attribute in db.Erd.Attributes)
            {
                if (!databaseProvider.ValidateAttributeName(attribute.ColumnName))
                    throw new Exception($"Column name of {attribute.DisplayName} attribute is invalid");
                if (!databaseProvider.ValidateDataType(attribute.DataType))
                    throw new Exception($"Data type of {attribute.DisplayName} attribute is invalid");

                // check duplicated attributes in the same entity
                Entity parentEntity = db.Erd.Entities.Find(e => e.AttributesReferences.Any(a => a.AttributeId == attribute.Id));
                if (parentEntity != null)
                {
                    if (entitiesAttributes.ContainsKey(parentEntity.Id))
                    {
                        if (!entitiesAttributes[parentEntity.Id].Add(attribute.ColumnName))
                        {
                            throw new Exception($"{parentEntity.DisplayName} entity has duplicated column names");
                        }
                    }
                    else entitiesAttributes[parentEntity.Id] = new HashSet<string>() { attribute.ColumnName };
                }

                // check duplicated attributes in the same relationship
                Relationship parentRelationship = db.Erd.Relationships.Find(e => e.Attributes.Any(a => a.AttributeId == attribute.Id));
                if (parentRelationship != null)
                {
                    if (relationshipsAttributes.ContainsKey(parentRelationship.Id))
                    {
                        if (!relationshipsAttributes[parentRelationship.Id].Add(attribute.ColumnName))
                        {
                            throw new Exception($"{parentRelationship.DisplayName} relationship has duplicated column names");
                        }
                    }
                    else relationshipsAttributes[parentRelationship.Id] = new HashSet<string>() { attribute.ColumnName };
                }
            }

            HashSet<string> relationships = new HashSet<string>();
            foreach (var relationship in db.Erd.Relationships)
            {
                if (relationship.IsManyToMany())
                {
                    if (!databaseProvider.ValidateTableName(relationship.TableName))
                        throw new Exception($"Table name of {relationship.DisplayName} relationship is invalid");

                    if (!relationships.Add(relationship.TableName))
                        throw new Exception($"Table {relationship.TableName} is duplicated ");
                }
            }
        }
    }
}
