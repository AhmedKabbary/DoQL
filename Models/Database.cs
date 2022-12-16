using DoQL.Models.ERD;

namespace DoQL.Models
{
    public class Database
    {
        public string Id { get; set; }
        public string Name { get; set; }
         public string Password { get; set; }
        public DatabaseType Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public List<Table> Tables { get; set; }
        public EntityRelationshipDiagram Erd { get; set; }

        public Database()
        {
            Tables = new List<Table>();
            Erd = new EntityRelationshipDiagram();
        }

        public void SyncErdToTables()
        {
            Tables.Clear();
            foreach (var entity in Erd.Entities)
            {
                var attachedAttributes = Erd.Attributes.Where(a => entity.AttributesReferences.Any(b => b.AttributeId == a.Id));
                Tables.Add(new Table
                {
                    Id = entity.Id,
                    Name = entity.TableName,
                    Columns = attachedAttributes.Select(a => new Column
                    {
                        Id = a.Id,
                        Name = a.ColumnName,
                        DataType = a.DataType,
                        NotNull = a.NotNull,
                        Primary = a.Primary,
                        Unique = a.Unique,
                        AutoIncrement = a.AutoIncrement,
                    }).ToList(),
                });
            }

            foreach (var relationship in Erd.Relationships)
            {
                if (relationship.Entities.Count == 2)
                {
                    if (relationship.IsOneToOne())
                    {
                        var columns = new List<Column>();

                        // add attached attributes
                        var attachedAttributes = Erd.Attributes.Where(a => relationship.Attributes.Any(b => b.AttributeId == a.Id));
                        columns.AddRange(attachedAttributes.Select(a => new Column
                        {
                            Id = a.Id,
                            Name = a.ColumnName,
                            DataType = a.DataType,
                            NotNull = a.NotNull,
                            Primary = a.Primary,
                            Unique = a.Unique,
                            AutoIncrement = a.AutoIncrement,
                        }));

                        // add foreign reference to the first entity
                        var firstEntityId = relationship.Entities[0].EntityId;
                        var secondEntityId = relationship.Entities[1].EntityId;

                        var firstTable = Tables.Find(e => e.Id == firstEntityId);
                        firstTable.Columns.AddRange(columns);
                        firstTable.ForiegnReferences.Add(new Table.ForiegnReference
                        {
                            TableId = secondEntityId,
                        });
                    }
                    else if (relationship.IsManyToMany())
                    {
                        var columns = new List<Column>();

                        // add attached attributes
                        var attachedAttributes = Erd.Attributes.Where(a => relationship.Attributes.Any(b => b.AttributeId == a.Id));
                        columns.AddRange(attachedAttributes.Select(a => new Column
                        {
                            Id = a.Id,
                            Name = a.ColumnName,
                            DataType = a.DataType,
                            NotNull = a.NotNull,
                            Primary = a.Primary,
                            Unique = a.Unique,
                            AutoIncrement = a.AutoIncrement,
                        }));

                        // add the two attached entities as foreign
                        var firstEntityId = relationship.Entities[0].EntityId;
                        var secondEntityId = relationship.Entities[1].EntityId;

                        Tables.Add(new Table
                        {
                            Id = relationship.Id,
                            Name = relationship.TableName,
                            Columns = columns,
                            ForiegnReferences = new List<Table.ForiegnReference>
                            {
                                new Table.ForiegnReference {TableId = firstEntityId},
                                new Table.ForiegnReference {TableId = secondEntityId},
                            }
                        });
                    }
                    else if (relationship.IsOneToMany())
                    {
                        var columns = new List<Column>();

                        // add attached attributes
                        var attachedAttributes = Erd.Attributes.Where(a => relationship.Attributes.Any(b => b.AttributeId == a.Id));
                        columns.AddRange(attachedAttributes.Select(a => new Column
                        {
                            Id = a.Id,
                            Name = a.ColumnName,
                            DataType = a.DataType,
                            NotNull = a.NotNull,
                            Primary = a.Primary,
                            Unique = a.Unique,
                            AutoIncrement = a.AutoIncrement,
                        }));

                        // add foreign reference to the N side
                        var firstEntityId = relationship.Entities.Find(e => e.Cardinality == Relationship.Cardinality.Many).EntityId;
                        var secondEntityId = relationship.Entities.Find(e => e.Cardinality == Relationship.Cardinality.One).EntityId;

                        var firstTable = Tables.Find(e => e.Id == firstEntityId);
                        firstTable.Columns.AddRange(columns);
                    }
                }
            }

        }
    }
}
