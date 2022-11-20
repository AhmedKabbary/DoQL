namespace DoQL
{
    public partial class DiagramForm : Form
    {
        public DiagramForm()
        {
            InitializeComponent();
        }

        // context menu (TODO use Factory)

        private void newTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control control = new Panel();
            control.Location = this.PointToClient(contextMenuStrip1.Bounds.Location);
            panel1.Controls.Add(control);
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
                foreach (Control control in panel1.Controls)
                {
                    control.SuspendLayout();
                    control.Left += e.X - point.X;
                    control.Top += e.Y - point.Y;
                    control.ResumeLayout();
                }
                point = e.Location;
            }
        }
    }
}