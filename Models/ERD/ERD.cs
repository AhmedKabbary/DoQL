namespace DoQL.Models.ERD
{
    public class EntityRelationshipDiagram
    {
        public List<Entity> Entities { get; init; }
        public List<Attribute> Attributes { get; init; }
        public List<Relationship> Relationships { get; init; }

        public EntityRelationshipDiagram()
        {
            Entities = new List<Entity>();
            Attributes = new List<Attribute>();
            Relationships = new List<Relationship>();
        }
    }
}
