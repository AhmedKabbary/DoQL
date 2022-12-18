using DoQL.DatabaseProviders;
using DoQL.Forms;
using DoQL.Models;
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
using static DoQL.Models.Table;

namespace DoQL.Controls.Panels
{
    public partial class RelationshipPanel : UserControl
    {
        public string Id { get; init; }
        private Relationship _relationship { get; set; }

        public RelationshipPanel()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            var diagramForm = (ParentForm as DiagramForm);
            _relationship = diagramForm.Database.Erd.Relationships.Find(e => e.Id == Id);
            relationshipName.Text = _relationship.DisplayName;
            updateAction.SelectedText = _relationship.UpdateAction.ToString();
            deleteAction.SelectedText = _relationship.DeleteAction.ToString();
            TableName.Text = _relationship.TableName;
            base.OnLoad(e);
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

        private void relationshipName_TextChanged(object sender, EventArgs e)
        {
            _relationship.DisplayName = relationshipName.Text;
        }

        private void updateAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (updateAction.SelectedIndex)
            {
                case 0:
                    _relationship.UpdateAction = Models.Action.NoAction;
                    break;
                case 1:
                    _relationship.UpdateAction = Models.Action.Restrict;
                    break;
                case 2:
                    _relationship.UpdateAction = Models.Action.Cascade;
                    break;
                case 3:
                    _relationship.UpdateAction = Models.Action.SetNull;
                    break;
                case 4:
                    _relationship.UpdateAction = Models.Action.SetDefault;
                    break;
            }
            if (updateAction.Text != "Restrict" && updateAction.Text != "Cascade" && updateAction.Text != "NoAction" && updateAction.Text != "SetNull" && updateAction.Text != "SetDefault")
                updateAction.SelectedIndex = 0;
        }

        private void deleteAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (deleteAction.SelectedIndex)
            {
                case 0:
                    _relationship.DeleteAction = Models.Action.NoAction;
                    break;
                case 1:
                    _relationship.DeleteAction = Models.Action.Restrict;
                    break;
                case 2:
                    _relationship.DeleteAction = Models.Action.Cascade;
                    break;
                case 3:
                    _relationship.DeleteAction = Models.Action.SetNull;
                    break;
                case 4:
                    _relationship.DeleteAction = Models.Action.SetDefault;
                    break;
            }
            if (deleteAction.Text != "Restrict" && deleteAction.Text != "Cascade" && deleteAction.Text != "NoAction" && deleteAction.Text != "SetNull" && deleteAction.Text != "SetDefault")
                deleteAction.SelectedIndex = 0;
        }

        private void TableName_TextChanged(object sender, EventArgs e)
        {
            _relationship.TableName = TableName.Text;
        }
    }
}
