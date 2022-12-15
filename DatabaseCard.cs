using DoQL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoQL.Forms
{
    public partial class DatabaseCard : UserControl
    {
        public DatabaseCard()
        {
            InitializeComponent();
        }
        public Database db
        {
            set
            {
                DatabaseName.Text = value.Id;
                DatabaseType.Text = value.Type.ToString();
                LastModified.Text = value.LastModified.ToString();
                _Id = value.Id;
            }

        }
        private string _Id;
        private void DatabaseCard_Load(object sender, EventArgs e)
        {
         
        }
        private void OpenDiagram(object sender, EventArgs e)
        {
            DiagramForm diagramForm = new DiagramForm(_Id);
            diagramForm.Show();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
