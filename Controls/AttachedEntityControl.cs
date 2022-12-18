using DoQL.Controls.Panels;
using DoQL.Forms;
using DoQL.Models.ERD;
using static DoQL.Models.ERD.Relationship;

namespace DoQL.Controls
{
    public partial class AttachedEntityControl : UserControl
    {
        public string Title { get; init; }
        public string EntityId { get; init; }
        public string RelationshipId { get; init; }
        public Cardinality InitialCardinality { get; init; }
        public Connection Connection { get; init; }

        public AttachedEntityControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            AttchdName.Text = Title;

            if (InitialCardinality == Cardinality.One)
                comboBox1.Text = "1";
            else if (InitialCardinality == Cardinality.Many)
                comboBox1.Text = "N";
            base.OnLoad(e);
        }

        private void DeleteAttchd_Click(object sender, EventArgs e)
        {
            var diagramPanel = (ParentForm as DiagramForm).DiagramPanel;
            diagramPanel.RemoveConnection(Connection);
            diagramPanel.RedrawConnections();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cardinality cardinality = Cardinality.One;
            if (comboBox1.SelectedItem.ToString() == "N")
                cardinality = Cardinality.Many;

            Relationship relationship = (ParentForm as DiagramForm).Database.Erd.Relationships.Find(r => r.Id == RelationshipId);
            relationship.Entities.Find(e => e.EntityId == EntityId).Cardinality = cardinality;

            (Parent.Parent as RelationshipPanel).CalculateCardinality();
        }

        public Cardinality GetCardinality()
        {
            if (comboBox1.SelectedItem.ToString() == "N")
                return Cardinality.Many;

            return Cardinality.One;
        }
    }
}
