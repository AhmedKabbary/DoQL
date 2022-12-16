using DoQL.Controls.ERD;
using DoQL.DatabaseProviders;
using DoQL.Models;
using DoQL.Models.ERD;
using System.Text.Json;
using Attribute = DoQL.Models.ERD.Attribute;

namespace DoQL.Forms
{
    public partial class DiagramForm : Form
    {
        public readonly string Id;
        public Database Database;
        public DatabaseProvider DatabaseProvider;

        public DiagramForm(string id)
        {
            Id = id;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Database = new Database
            {
                Id = "id",
                Name = "Clinic",
                Type = DatabaseType.SQLite,
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                Tables = new List<Table>(),
                Erd = new EntityRelationshipDiagram(),

            };
            DatabaseProvider = DatabaseProvidersFactory.GetDatabaseProvider(Database.Type);

            // TODO
            // load database by id from the DatabasesManager
            // add controls on panel

            base.OnLoad(e);
        }

        #region context menu

        private void newEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            Point location = contextMenuStrip1.Bounds.Location;

            Database.Erd.Entities.Add(
                new Entity
                {
                    Id = id,
                    DisplayName = "Entity",
                    TableName = "Entity",
                    Position = location,
                }
            );

            var control = new EntityControl() { Id = id };
            control.Location = PointToClient(location);
            diagramPanel.Controls.Add(control);
        }

        private void newAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            Point location = contextMenuStrip1.Bounds.Location;

            Database.Erd.Attributes.Add(
                new Attribute
                {
                    Id = id,
                    DisplayName = "Attribute",
                    ColumnName = "Attribute",
                    Position = location,
                }
            );

            var control = new AttributeControl() { Id = id };
            control.Location = PointToClient(location);
            diagramPanel.Controls.Add(control);
        }

        private void newRelationshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            Point location = contextMenuStrip1.Bounds.Location;

            Database.Erd.Relationships.Add(
                new Relationship
                {
                    Id = id,
                    DisplayName = "Has",
                    TableName = "Has",
                    Position = location,
                }
            );

            var control = new RelationshipControl() { Id = id };
            control.Location = PointToClient(location);
            diagramPanel.Controls.Add(control);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var content = JsonSerializer.Serialize(Database);
            using var stream = File.Create("debug.json");
            using var writer = new StreamWriter(stream);
            writer.Write(content);
        }
    }
}