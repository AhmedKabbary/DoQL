namespace DoQL.Models
{
    public class Table
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
        public List<ForiegnReference> ForiegnReferences { get; set; }

        public Table()
        {
            Columns = new List<Column>();
            ForiegnReferences = new List<ForiegnReference>();
        }

        public class ForiegnReference
        {
            public string TableId { get; set; }
            public Action OnUpdateAction { get; set; }
            public Action OnDeleteAction { get; set; }
        }

        public enum Action
        {
            NoAction,
            Restrict,
            Cascade,
            SetNull,
            SetDefault
        }
    }
}
