using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoQL.Controls.Panels
{
    public partial class AttachedAttribute : UserControl
    {
        public AttachedAttribute()
        {
            InitializeComponent();
        }

        private void DeleteAttchd_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
        /*public List<string> GetCardinality()
        {
            if (comboBox1.SelectedItem.ToString() != "M") return null;
            List <string> list = new List<string>()
            {
                comboBox1.SelectedItem.ToString(),
            };
            return list;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            (Parent.Parent as RelationshipPanel).CalculateCardinality();
        }
        */
    }
}
