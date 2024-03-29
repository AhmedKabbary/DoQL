﻿using DoQL.DatabaseProviders;
using DoQL.Forms;
using DoQL.Models;
using DoQL.Utilities;

namespace DoQL.Controls.Panels
{
    public partial class DatabasePanel : UserControl
    {
        public Database Database { get; init; }

        public DatabasePanel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            databaseName.Text = Database.Name;
            databaseType.SelectedText = DatabaseTypeFactory.GetDatabaseTypeString(Database.Type);
            if (Database.IsPasswordProtected == false)
            {
                passwordButton.Text = "Set password";
            }
            else
                passwordButton.Text = "Change password";
            base.OnLoad(e);
        }

        private void ChangeDatabaseName(object sender, EventArgs e)
        {
            Database.Name = databaseName.Text;
            ParentForm.Text = Database.Name;
        }

        private void ChangeDatabaseType(object sender, EventArgs e)
        {
            switch (databaseType.SelectedIndex)
            {
                case 0:
                    Database.Type = (DatabaseType)databaseType.SelectedIndex;
                    break;
                case 1:
                    Database.Type = (DatabaseType)databaseType.SelectedIndex;
                    break;
                case 2:
                    Database.Type = (DatabaseType)databaseType.SelectedIndex;
                    break;
            }
            (ParentForm as DiagramForm).DatabaseProvider = DatabaseProvidersFactory.GetDatabaseProvider(Database.Type);

            if (databaseType.Text != "MySQL" && databaseType.Text != "SQLite" && databaseType.Text != "SQL Server")
                databaseType.SelectedIndex = 0;
        }

        private void SetPassword(object sender, EventArgs e)
        {
            if (databasePassword.Text == "")
                MessageBox.Show("Password can not be empty");
            else
            {
                Database.Password = databasePassword.Text;
                MessageBox.Show("Password updated");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var form = (ParentForm as DiagramForm);
            var exportForm = new ExportForm() { Database = form.Database };
            exportForm.Show();
        }
    }
}
