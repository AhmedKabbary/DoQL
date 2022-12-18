using DoQL.DatabaseProviders;
using DoQL.Interfaces;
using DoQL.Models;
using DoQL.Utilities;

namespace DoQL.Forms
{
    public partial class ExportForm : Form
    {
        public Database Database { get; init; }

        public ExportForm()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (doqlRadioBtn.Checked)
            {
                var result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DatabasesManager.GetInstance().ExportDatabase(Database.Id, folderBrowserDialog1.SelectedPath);
                    this.Close();
                }
            }
            else if (sqlRadioBtn.Checked)
            {
                try
                {
                    DatabaseValidator.Validate(Database);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                DatabaseProvider databaseProvider = DatabaseProvidersFactory.GetDatabaseProvider(Database.Type);
                if (databaseProvider is ISQLExporter exporter)
                {
                    Database.SyncErdWithTables();
                    string commands = exporter.Export(Database);
                    saveFileDialog1.FileName = Database.Name;
                    saveFileDialog1.DefaultExt = "sql";

                    var result = saveFileDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        using var stream = File.Create(saveFileDialog1.FileName);
                        using var streamWriter = new StreamWriter(stream);
                        streamWriter.Write(commands);
                        this.Close();
                    }
                }
            }
        }
    }
}
