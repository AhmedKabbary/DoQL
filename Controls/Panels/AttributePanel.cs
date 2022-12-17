using DoQL.Forms;
using DoQL.Models.ERD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Attribute = DoQL.Models.ERD.Attribute;

namespace DoQL.Controls.Panels
{
    public partial class AttributePanel : UserControl
    {
        public string Id { get; init; }
        public AttributePanel()
        {
            InitializeComponent();
        }

        private Attribute _attribute { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            var diagramForm = (ParentForm as DiagramForm);
            _attribute = diagramForm.Database.Erd.Attributes.Find(e => e.Id == Id);

            comboBox1.Items.AddRange(diagramForm.DatabaseProvider.GetDataTypes().ToArray());
            comboBox1.SelectedIndex = 0;

            base.OnLoad(e);
        }

        private void ChangeAttributeName(object sender, EventArgs e)
        {
            _attribute.DisplayName = attributeName.Text;
        }
    }
}
