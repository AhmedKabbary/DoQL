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
    public partial class RelationshipPanel : UserControl
    {
        public string Id { get; init; }

        public RelationshipPanel()
        {
            InitializeComponent();
        }

        private void HideTable(object sender, ControlEventArgs e)
        {
            TblNameLbl.Visible = false;
            TableName.Visible = false;
        }

        public void CalculateCardinality()
        {
            var cardinalities = new List<string>();
            var flowPanel = Controls.OfType<FlowLayoutPanel>().First();
            foreach (var attachedAttribute in flowLayoutPanel1.Controls.OfType<AttachedAttribute>())
            {
                cardinalities.Add(attachedAttribute.GetCardinality());
            }
            if (cardinalities.Count == 2 && cardinalities.All(c => c == "M"))
            {
                TblNameLbl.Visible = true;
                TableName.Visible = true;
            }
            else
            {
                TblNameLbl.Visible = false;
                TableName.Visible = false;
            }
        }
    }
}
