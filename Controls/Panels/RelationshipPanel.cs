using DoQL.Controls.ERD;
using DoQL.Forms;
using DoQL.Models.ERD;
using System.Collections.Specialized;
using static DoQL.Models.ERD.Relationship;

namespace DoQL.Controls.Panels
{
    public partial class RelationshipPanel : UserControl
    {
        public string Id { get; init; }
        public RelationshipControl RelationshipControl { get; init; }

        public RelationshipPanel()
        {
            InitializeComponent();
        }

        private Relationship _relationship;
        private DiagramForm _diagramForm;

        protected override void OnLoad(EventArgs e)
        {
            _diagramForm = (ParentForm as DiagramForm);
            _relationship = _diagramForm.Database.Erd.Relationships.Find(e => e.Id == Id);
            relationshipName.Text = _relationship.DisplayName;
            updateAction.SelectedText = _relationship.UpdateAction.ToString();
            deleteAction.SelectedText = _relationship.DeleteAction.ToString();
            TableName.Text = _relationship.TableName;

            // get all connections of this relationship to show
            var diagramPanel = _diagramForm.DiagramPanel;

            var validConnections = diagramPanel.Connections
                .Where(c => c.IsValidConnection())
                .Where(c => c.Control1.ConnectableControl is EntityControl || c.Control2.ConnectableControl is EntityControl)
                .Where(c =>
                    (c.Control1.ConnectableControl is RelationshipControl && (c.Control1.ConnectableControl as RelationshipControl).Id == Id)
                    ||
                    (c.Control2.ConnectableControl is RelationshipControl && (c.Control2.ConnectableControl as RelationshipControl).Id == Id)
                );

            foreach (var connection in validConnections)
            {
                EntityControl entityControl = null;
                if (connection.Control1.ConnectableControl is EntityControl)
                    entityControl = connection.Control1.ConnectableControl as EntityControl;
                if (connection.Control2.ConnectableControl is EntityControl)
                    entityControl = connection.Control2.ConnectableControl as EntityControl;

                var attachedEntityControl = new AttachedEntityControl()
                {
                    Connection = connection,
                    EntityId = entityControl.Id,
                    RelationshipId = _relationship.Id,
                    InitialCardinality = _relationship.Entities.Find(e => e.EntityId == entityControl.Id).Cardinality,
                    Title = _diagramForm.Database.Erd.Entities.Find(e => e.Id == entityControl.Id).DisplayName,
                };
                flowLayoutPanel1.Controls.Add(attachedEntityControl);
            }

            diagramPanel.Connections.CollectionChanged += connectionsChangedEvent;

            base.OnLoad(e);
        }

        private void connectionsChangedEvent(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Connection newConnection in e.NewItems)
                {
                    if (newConnection.IsValidConnection())
                    {
                        bool isEntity = newConnection.Control1.ConnectableControl is EntityControl || newConnection.Control2.ConnectableControl is EntityControl;
                        bool isRelationship = newConnection.Control1.ConnectableControl is RelationshipControl || newConnection.Control2.ConnectableControl is RelationshipControl;

                        if (isEntity && isRelationship)
                        {

                            EntityControl entityControl = null;
                            if (newConnection.Control1.ConnectableControl is EntityControl)
                                entityControl = newConnection.Control1.ConnectableControl as EntityControl;
                            if (newConnection.Control2.ConnectableControl is EntityControl)
                                entityControl = newConnection.Control2.ConnectableControl as EntityControl;

                            var attachedEntityControl = new AttachedEntityControl()
                            {
                                Connection = newConnection,
                                EntityId = entityControl.Id,
                                RelationshipId = _relationship.Id,
                                Title = _diagramForm.Database.Erd.Entities.Find(e => e.Id == entityControl.Id).DisplayName,
                            };
                            flowLayoutPanel1.Controls.Add(attachedEntityControl);
                            flowLayoutPanel1.Controls.SetChildIndex(attachedEntityControl, 0);
                        }
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Connection oldConnection in e.OldItems)
                {
                    if (oldConnection.IsValidConnection())
                    {
                        bool isEntity = oldConnection.Control1.ConnectableControl is EntityControl || oldConnection.Control2.ConnectableControl is EntityControl;
                        bool isRelationship = oldConnection.Control1.ConnectableControl is RelationshipControl || oldConnection.Control2.ConnectableControl is RelationshipControl;

                        if (isEntity && isRelationship)
                        {
                            var attachedEntities = flowLayoutPanel1.Controls.OfType<AttachedEntityControl>();
                            if (attachedEntities.Count() > 0)
                            {
                                var attachedEntityControl = attachedEntities.FirstOrDefault(a => a.Connection == oldConnection);
                                if (attachedEntityControl != null)
                                    flowLayoutPanel1.Controls.Remove(attachedEntityControl);
                            }
                        }
                    }
                }
            }
        }

        private void HideTableNameControls(object sender, ControlEventArgs e)
        {
            TblNameLbl.Visible = false;
            TableName.Visible = false;
        }

        public void CalculateCardinality()
        {
            var cardinalities = new List<Cardinality>();
            var flowPanel = Controls.OfType<FlowLayoutPanel>().First();
            foreach (var attachedAttribute in flowLayoutPanel1.Controls.OfType<AttachedEntityControl>())
            {
                cardinalities.Add(attachedAttribute.GetCardinality());
            }
            if (cardinalities.Count == 2 && cardinalities.All(c => c == Cardinality.Many))
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
            RelationshipControl.SetDisplayName(relationshipName.Text);
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
