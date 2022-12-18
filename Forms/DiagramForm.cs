using DoQL.Controls;
using DoQL.Controls.ERD;
using DoQL.Controls.Panels;
using DoQL.DatabaseProviders;
using DoQL.Models;
using DoQL.Models.ERD;
using System.ComponentModel;
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

            Database = DatabasesManager.GetInstance().LoadDatabase(Id);
            if (Database.IsPasswordProtected)
            {
                EnterPasswordForm enterPasswordForm = new EnterPasswordForm();
                DialogResult result = enterPasswordForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        Database = DatabasesManager.GetInstance().LoadDatabase(Id, enterPasswordForm.Password);
                        Database.Password = enterPasswordForm.Password;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Incorrect password");
                        Close();
                    }
                }
                else Close();
            }

            DatabaseProvider = DatabaseProvidersFactory.GetDatabaseProvider(Database.Type);
            Text = Database.Name;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DatabasesManager.GetInstance().SaveDatabase(Database);
            base.OnClosing(e);
        }

        #region context menu

        private void newEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            Point location = diagramPanel.PointToClient(contextMenuStrip1.Bounds.Location);

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
            control.Location = location;
            diagramPanel.Controls.Add(control);
        }

        private void newAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            Point location = diagramPanel.PointToClient(contextMenuStrip1.Bounds.Location);

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
            control.Location = location;
            diagramPanel.Controls.Add(control);
        }

        private void newRelationshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            Point location = diagramPanel.PointToClient(contextMenuStrip1.Bounds.Location);

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
            control.Location = location;
            diagramPanel.Controls.Add(control);
        }

        #endregion

        #region panels

        public DiagramPanel DiagramPanel
        {
            get => diagramPanel;
        }

        public Panel SidePanel
        {
            get => sidePanel;
        }

        private void ShowDatabasePanel(object sender, EventArgs e)
        {
            sidePanel.Controls.Clear();
            DatabasePanel databasePanel = new DatabasePanel() {Database = Database};
            databasePanel.AutoScroll = true;
            databasePanel.Dock = DockStyle.Fill;
            databasePanel.Margin = new Padding(0);
            databasePanel.Size = new Size(345, 518);
            databasePanel.TabIndex = 1;
            sidePanel.Controls.Add(databasePanel);

        }

        #endregion
    }
}