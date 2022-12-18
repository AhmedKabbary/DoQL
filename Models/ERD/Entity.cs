namespace DoQL.Models.ERD
{
    public class Entity
    {
        public string Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;
        public Point Position { get; set; }
        public List<Attribute.Reference> AttributesReferences { get; set; }

        public Entity()
        {
            AttributesReferences = new List<Attribute.Reference>();
        }
    }
}
