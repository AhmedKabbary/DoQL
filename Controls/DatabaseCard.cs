using DoQL.Forms;
using DoQL.Models;

namespace DoQL.Controls
{
    public partial class DatabaseCard : UserControl
    {
        public DatabaseCard()
        {
            InitializeComponent();
        }

        private string _id;

        public Database Database
        {
            set
            {
                _id = value.Id;
                DatabaseName.Text = value.Id;
                DatabaseType.Text = value.Type.ToString();
                LastModified.Text = value.LastModified.ToString();
            }

        }

        private void DatabaseCard_Load(object sender, EventArgs e)
        {

        }

        private void OpenDiagram(object sender, EventArgs e)
        {
            DiagramForm diagramForm = new DiagramForm(_id);
            diagramForm.Show();
        }
    }
}
