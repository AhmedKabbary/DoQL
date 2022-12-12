namespace DoQL.Models.ERD
{
    public class Entity
    {
        public string EntityId { get; set; }
        public string Name { get; set; }
        public Point Position { get; set; }
        public List<Attribute.Reference> Attributes { get; set; }
    }
}
