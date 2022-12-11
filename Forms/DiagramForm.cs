using DoQL.Controls.ERD;

namespace DoQL
{
    public partial class DiagramForm : Form
    {
        public DiagramForm()
        {
            InitializeComponent();
        }

        #region context menu

        private void newEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = new EntityControl();
            control.Location = this.PointToClient(contextMenuStrip1.Bounds.Location);
            diagramPanel.Controls.Add(control);
        }

        private void newAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = new AttributeControl();
            control.Location = this.PointToClient(contextMenuStrip1.Bounds.Location);
            diagramPanel.Controls.Add(control);
        }

        private void newRelationshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = new RelationshipControl();
            control.Location = this.PointToClient(contextMenuStrip1.Bounds.Location);
            diagramPanel.Controls.Add(control);
        }

        #endregion
    }
}