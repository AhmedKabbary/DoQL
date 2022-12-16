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
            List<Database> list1 = new List<Database>();
            flowLayoutPanel1.Controls.Clear();
            foreach (Database i in list1)
            {
                DatabaseCard userControl = new DatabaseCard();
                userControl.Database = i;
                flowLayoutPanel1.Controls.Add(userControl);
            }
        }
    }
}
