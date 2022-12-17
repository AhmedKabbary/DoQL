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
    public partial class AttributePanel : UserControl
    {
        public string Id { get; init; }

        public AttributePanel()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
    }
}
