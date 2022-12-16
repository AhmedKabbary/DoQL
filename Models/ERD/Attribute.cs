namespace DoQL.Models.ERD
{
    public class Attribute
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string ColumnName { get; set; }
        public Point Position { get; set; }

        public string DataType { get; set; } = string.Empty;
        public bool NotNull { get; set; }
        public bool Primary { get; set; }
        public bool Unique { get; set; }
        public bool AutoIncrement { get; set; }
        public ForiegnReference ForiegnReference { get; set; }



        public class Reference
        {
            public string AttributeId { get; set; }
            public int ParentConnectorIndex { get; set; }
            public int AttributeConnectorIndex { get; set; }
        }
    }
}
