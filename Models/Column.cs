namespace DoQL.Models
{
    public class Column
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;
        public bool NotNull { get; set; }
        public bool Primary { get; set; }
        public bool Unique { get; set; }
        public bool AutoIncrement { get; set; }

        [Obsolete]
        public ForiegnReference ForiegnReference { get; set; }
    }
}
