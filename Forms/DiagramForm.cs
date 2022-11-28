using DoQL.Controls.ERD;

namespace DoQL
{
    public partial class DiagramForm : Form
    {
        public DiagramForm()
        {
            InitializeComponent();
        }

        // dragging

        bool selected;
        Point point;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            point = e.Location;
            this.Cursor = Cursors.Hand;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            selected = false;
            this.Cursor = Cursors.Default;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected)
            {
                panel1.SuspendLayout();
                foreach (BaseControl control in panel1.Controls.OfType<BaseControl>())
                {
                    control.SuspendLayout();
                    control.Left += e.X - point.X;
                    control.Top += e.Y - point.Y;
                    control.ResumeLayout();
                }
                panel1.ResumeLayout();
                point = e.Location;
            }
        }

        // context menu (TODO use Factory)

        private void newEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control control = new EntityControl();
            control.Location = this.PointToClient(contextMenuStrip1.Bounds.Location);
            panel1.Controls.Add(control);
        }

        private void newAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control control = new AttributeControl();
            control.Location = this.PointToClient(contextMenuStrip1.Bounds.Location);
            panel1.Controls.Add(control);
        }

        private void newRelationshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control control = new RelationshipControl();
            control.Location = this.PointToClient(contextMenuStrip1.Bounds.Location);
            panel1.Controls.Add(control);
        }
    }
}