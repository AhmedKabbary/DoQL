namespace DoQL.Models.ERD
{
    public class Attribute
    {
        public string AttributeId { get; set; }
        public string Name { get; set; }
        public Point Position { get; set; }

        public class Reference
        {
            public string AttributeId { get; set; }
            public int ParentConnectorId { get; set; }
            public int AttributeConnectorId { get; set; }
        }
    }
}
