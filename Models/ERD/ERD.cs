namespace DoQL.Models.ERD
{
    public class EntityRelationshipDiagram
    {
        public List<Entity> Entities { get; set; }
        public List<Attribute> Attributes { get; set; }
        public List<Relationship> Relationships { get; set; }
    }
}
