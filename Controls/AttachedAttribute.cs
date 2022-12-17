using DoQL.Controls.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoQL.Controls
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            (Parent.Parent as RelationshipPanel).CalculateCardinality();
        }
        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GetCardinality();
        //    if (Parent.Controls[1].GetCardi)
        //}
        public string GetCardinality()
        {
            if (comboBox1.SelectedItem == null) return "1";

            if (comboBox1.SelectedItem.ToString() == "M")
                return "M";
            else
                return "1";
        }
    }
}
