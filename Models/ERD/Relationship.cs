namespace DoQL.Models.ERD
{
    public class Relationship
    {
        public string RelationshipId { get; set; }
        public string Name { get; set; }
        public Point Position { get; set; }
        public List<EntityReference> Entity { get; set; }
        public List<Attribute.Reference> Attributes { get; set; }

        public class EntityReference
        {
            public string EntityId { get; set; }
            public int EntityConnectorId { get; set; }
            public int RelationshipConnectorId { get; set; }
            public Cardinality Cardinality { get; set; }
        }

        public enum Cardinality
        {
            One,
            Many,
        }
    }
}
