namespace DoQL.Models.ERD
{
    public class Relationship
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string TableName { get; set; }
        public Point Position { get; set; }
        public List<EntityReference> Entities { get; set; }
        public List<Attribute.Reference> Attributes { get; set; }

        public Relationship()
        {
            Entities = new List<EntityReference>();
            Attributes = new List<Attribute.Reference>();
        }

        public class EntityReference
        {
            public string EntityId { get; set; }
            public int EntityConnectorIndex { get; set; }
            public int RelationshipConnectorIndex { get; set; }
            public Cardinality Cardinality { get; set; }
        }

        public enum Cardinality
        {
            One,
            Many,
        }

        public bool IsOneToOne() => Entities.All(e => e.Cardinality == Cardinality.One);
        public bool IsOneToMany() => Entities.Any(e => e.Cardinality == Cardinality.One) && Entities.Any(e => e.Cardinality == Cardinality.Many);
        public bool IsManyToMany() => Entities.All(e => e.Cardinality == Cardinality.Many);
    }
}
