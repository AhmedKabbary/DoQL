using DoQL.Controls;
using DoQL.Models;

namespace DoQL.Forms
{
    public partial class DatabasesForm : Form
    {
        public DatabasesForm()
        {
            InitializeComponent();
        }

        private void DatabasesForm_Load(object sender, EventArgs e)
        {
            LoadDatabases();
        }

        public void LoadDatabases()
        {
            List<Database> databases = DatabasesManager.GetInstance().LoadDatabases();
            flowLayoutPanel1.Controls.Clear();
            foreach (Database database in databases)
            {
                DatabaseCard userControl = new DatabaseCard();
                userControl.Database = database;
                flowLayoutPanel1.Controls.Add(userControl);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewDatabaseForm newDatabaseForm = new NewDatabaseForm();
            DialogResult result = newDatabaseForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadDatabases();
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (openFileDialog1.CheckFileExists)
                {
                    DatabasesManager.GetInstance().ImportDatabase(openFileDialog1.FileName);
                    LoadDatabases();
                }
            }
        }
    }
}
