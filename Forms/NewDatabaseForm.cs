using DoQL.Models;

namespace DoQL.Forms
{
    public partial class NewDatabaseForm : Form
    {
        private DatabaseType databaseType;
        private DatabaseBuilder Builder;

        public NewDatabaseForm()
        {
            InitializeComponent();
            Builder = new DatabaseBuilder();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbType.SelectedIndex)
            {
                case 0:
                    databaseType = DatabaseType.SQLite;
                    break;
                case 1:
                    databaseType = DatabaseType.MySQL;
                    break;
                case 2:
                    databaseType = DatabaseType.SQLServer;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Builder.SetName(txtName.Text);
            Builder.SetType(databaseType);
            Builder.SetPassword(txtPassword.Text == string.Empty ? null : txtPassword.Text);

            Database db = Builder.Build();
            DatabasesManager.GetInstance().SaveDatabase(db);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
