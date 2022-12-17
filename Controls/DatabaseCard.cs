using DoQL.Forms;
using DoQL.Models;
using DoQL.Utilities;
using System.Drawing.Drawing2D;

namespace DoQL.Controls
{
    public partial class DatabaseCard : UserControl
    {
        public DatabaseCard()
        {
            InitializeComponent();
        }

        private string _id;
        public Database Database { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            _id = Database.Id;
            DatabaseName.Text = Database.Name;
            LastModified.Text = Database.LastModified.ToString();

            var chip = new ChipControl()
            {
                Title = DatabaseTypeFactory.GetDatabaseTypeString(Database.Type),
                Color = DatabaseTypeFactory.GetDatabaseTypeColor(Database.Type),
            };
            chip.Location = new Point(27, 80);
            chip.Click += OpenDiagram;
            Controls.Add(chip);

            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var brush = new SolidBrush(Color.FromArgb(238, 238, 255));

            using var path = new GraphicsPath();
            path.AddRoundedRectangle(ClientRectangle, 8, 8, 8, 8);
            e.Graphics.FillPath(brush, path);
            base.OnPaint(e);
        }

        private void OpenDiagram(object sender, EventArgs e)
        {
            try
            {
                DiagramForm diagramForm = new DiagramForm(_id);
                diagramForm.Show();
                diagramForm.FormClosed += formClosedEventHandler;
            }
            catch (Exception)
            {

            }
        }

        private void formClosedEventHandler(object sender, EventArgs e)
        {
            (ParentForm as DatabasesForm).LoadDatabases();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabasesManager.GetInstance().DeleteDatabase(_id);
            (ParentForm as DatabasesForm).LoadDatabases();
        }
    }
}
