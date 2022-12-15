using DoQL.Controls.ERD;
using DoQL.Models;

namespace DoQL.Forms
{
    public partial class DiagramForm : Form
    {
        public readonly string Id;
        public Database Database;

        public DiagramForm()
        {
            // TODO get id from constructor
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            // load database by id from the StorageManager
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

        private void diagramPanel_Paint(object sender, PaintEventArgs e)
        {

        }
          
        private void button1_Click(object sender, EventArgs e)
        {
            DatabasesForm databasesForm = new DatabasesForm();
            databasesForm.ShowDialog();
            this.Hide();
        }
    }
}