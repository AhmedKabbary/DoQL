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
    public partial class DatabasesForm : Form
    {
        public DatabasesForm()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DatabasesForm_Load(object sender, EventArgs e)
        {
            List<Database> list1 = new List<Database>();
            flowLayoutPanel1.Controls.Clear();
            foreach (Database i in list1)
            {
                DatabaseCard userControl = new DatabaseCard();
                userControl.db = i;
                flowLayoutPanel1.Controls.Add(userControl);
            }
        }
    }
}
