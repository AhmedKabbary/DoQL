namespace DoQL.Models.ERD
{
    public class Entity
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string TableName { get; set; }
        public Point Position { get; set; }
        public List<Attribute.Reference> AttributesReferences { get; set; }

        public Entity()
        {
            AttributesReferences = new List<Attribute.Reference>();
        }
    }
}
