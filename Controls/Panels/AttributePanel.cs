using DoQL.Controls.ERD;
using DoQL.Forms;
using Attribute = DoQL.Models.ERD.Attribute;

namespace DoQL.Controls.Panels
{
    public partial class AttributePanel : UserControl
    {
        public string Id { get; init; }
        public AttributeControl AttributeControl { get; init; }

        public AttributePanel()
        {
            InitializeComponent();
        }

        private Attribute _attribute { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            var diagramForm = (ParentForm as DiagramForm);
            _attribute = diagramForm.Database.Erd.Attributes.Find(e => e.Id == Id);

            attributeDatatype.Items.AddRange(diagramForm.DatabaseProvider.GetDataTypes().ToArray());
            attributeName.Text = _attribute.DisplayName;
            columnName.Text = _attribute.ColumnName;

            if(_attribute.DataType == "")
                attributeDatatype.SelectedIndex = 0;
            else
                attributeDatatype.SelectedItem = _attribute.DataType;

            primaryChechBox.Checked = _attribute.Primary;
            notNullCheckBox.Checked = _attribute.NotNull;
            uniqueCheckBox.Checked = _attribute.Unique;
            autoincreamentCheckBox.Checked = _attribute.AutoIncrement;
            base.OnLoad(e);
        }

        private void ChangeAttributeName(object sender, EventArgs e)
        {
            _attribute.DisplayName = attributeName.Text;
            AttributeControl.SetDisplayName(attributeName.Text);
        }

        private void columnName_TextChanged(object sender, EventArgs e)
        {
            _attribute.ColumnName = columnName.Text;
        }

        private void attributeDatatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((ParentForm as DiagramForm).DatabaseProvider.ValidateDataType(attributeDatatype.Text))
                _attribute.DataType = attributeDatatype.Text;
            else
                MessageBox.Show("Incorrect datatype");
        }

        private void primaryChechBox_CheckedChanged(object sender, EventArgs e)
        {
            _attribute.Primary = primaryChechBox.Checked;
            if (primaryChechBox.Checked)
            {
                notNullCheckBox.Checked = false;
                notNullCheckBox.Enabled = false;
                uniqueCheckBox.Enabled = false;
                uniqueCheckBox.Checked = false;
            }
            else
            {
                notNullCheckBox.Enabled = true;
                uniqueCheckBox.Enabled = true;
            }
        }

        private void notNullCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _attribute.NotNull = notNullCheckBox.Checked;
        }

        private void uniqueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _attribute.Unique = uniqueCheckBox.Checked;
        }

        private void autoincreamentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _attribute.AutoIncrement = autoincreamentCheckBox.Checked;
        }
    }
}
