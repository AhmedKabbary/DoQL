namespace DoQL.Models
{
    public class Table
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}
