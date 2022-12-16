using DoQL.Controls.ERD;
using DoQL.DatabaseProviders;
using DoQL.Models;
using DoQL.Models.ERD;

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
            Database = new Database {
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
            var control = new EntityControl();
            control.Location = PointToClient(contextMenuStrip1.Bounds.Location);
            diagramPanel.Controls.Add(control);
        }

        private void newAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = new AttributeControl();
            control.Location = PointToClient(contextMenuStrip1.Bounds.Location);
            diagramPanel.Controls.Add(control);
        }

        private void newRelationshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = new RelationshipControl();
            control.Location = PointToClient(contextMenuStrip1.Bounds.Location);
            diagramPanel.Controls.Add(control);
        }

        #endregion

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.E:
                        var entityControl = new EntityControl();
                        entityControl.Location = PointToClient(new Point(diagramPanel.Width / 2, diagramPanel.Height / 2));
                        diagramPanel.Controls.Add(entityControl);
                        break;
                    case Keys.A:
                        var attributeControl = new AttributeControl();
                        attributeControl.Location = PointToClient(new Point(diagramPanel.Width / 2, diagramPanel.Height / 2));
                        diagramPanel.Controls.Add(attributeControl);
                        break;
                    case Keys.R:
                        var relationshipControl = new RelationshipControl();
                        relationshipControl.Location = PointToClient(new Point(diagramPanel.Width / 2, diagramPanel.Height / 2));
                        diagramPanel.Controls.Add(relationshipControl);
                        break;
                }
            }
            base.OnKeyDown(e);
        }
    }
}