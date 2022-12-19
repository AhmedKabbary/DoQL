using System.Drawing.Drawing2D;
using DoQL.Controls.Panels;
using DoQL.Forms;
using DoQL.Interfaces;
using DoQL.Models;
using DoQL.Models.ERD;
using DoQL.Utilities;

namespace DoQL.Controls.ERD
{
    public partial class RelationshipControl : BaseControl, IConnectable, IDeletable
    {
        public string Id { get; init; }
        public string DisplayName { get; set; } = "Has";

        public RelationshipControl()
        {
            InitializeComponent();
        }

        private Size strSize;

        protected override void OnLoad(EventArgs e)
        {
            AdjustSize();
            base.OnLoad(e);
        }

        private void AdjustSize()
        {
            using (Graphics graphics = CreateGraphics())
            {
                var padding = new Size(64, 64);
                strSize = graphics.MeasureString(DisplayName, Font).ToSize();
                Size = strSize + padding;
            }

            using (var path = new GraphicsPath())
            {
                path.AddPolygon(new Point[]
                {
                    new Point(0, Height/2),
                    new Point(Width/2, 0),
                    new Point(Width, Height/2),
                    new Point(Width/2, Height),
                });
                Region = new Region(path);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var centerPoint = new Point(Width / 2 - strSize.Width / 2, Height / 2 - strSize.Height / 2);
            e.Graphics.DrawString(DisplayName, Font, new SolidBrush(ForeColor), centerPoint);
            base.OnPaint(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (IsHandleCreated)
            {
                Database db = (ParentForm as DiagramForm).Database;
                db.Erd.Relationships.Find(r => r.Id == Id).Position = Location;
            }
            base.OnLocationChanged(e);
        }

        public void SetDisplayName(string name)
        {
            if (name != "")
            {
                DisplayName = name;
                AdjustSize();
                Invalidate();
            }
        }

        #region connections

        public Point[] GetConnectablePoints()
        {
            return new[]
            {
                // left
                new Point(0, Height / 2),
                // center
                new Point(Width / 2, 0),
                new Point(Width / 2, Height),
                // right
                new Point(Width, Height / 2)
            };
        }

        public ErdSymbol[] GetSupportedSymbols()
        {
            return new[] { ErdSymbol.Entity, ErdSymbol.Attribute };
        }

        public void Connect(IConnectable connectableControl)
        {
            // make sure it is connected with 2 entities only
            if (connectableControl is EntityControl entityControl)
            {
                var diagramPanel = Parent as DiagramPanel;

                IEnumerable<Connection> currentConnections = diagramPanel.Connections
                    .Where(c => c.IsValidConnection())
                    .Where(c => c.Control1.ConnectableControl == this || c.Control2.ConnectableControl == this)
                    .Where(c => c.Control1.ConnectableControl is EntityControl || c.Control2.ConnectableControl is EntityControl);

                // in case it connects with the same entity again
                Connection duplicateConnection = currentConnections.FirstOrDefault(c => c.Control1.ConnectableControl == entityControl || c.Control2.ConnectableControl == entityControl);
                if (duplicateConnection != null)
                    diagramPanel.RemoveConnection(duplicateConnection);

                if (currentConnections.Count() == 2)
                    diagramPanel.RemoveConnection(currentConnections.First());
            }

            if (connectableControl is AttributeControl attributeControl)
            {
                attributeControl.Connect(this);
            }
        }

        #endregion

        public void Delete()
        {
            // delete connections
            DiagramPanel diagramPanel = (Parent as DiagramPanel);
            var oldConnections = diagramPanel.Connections.Where(connection => connection.Control1.ConnectableControl == this || connection.Control2.ConnectableControl == this);
            foreach (var oldConnection in oldConnections.ToList())
            {
                diagramPanel.RemoveConnection(oldConnection);
            }

            DiagramForm diagramForm = (ParentForm as DiagramForm);
            Relationship relationship = diagramForm.Database.Erd.Relationships.Find(r => r.Id == Id);
            diagramForm.Database.Erd.Relationships.Remove(relationship);

            Parent.Controls.Remove(this);

            diagramPanel.RedrawConnections();
        }

        private void ShowRelationshipPanel(object sender, EventArgs e)
        {
            (ParentForm as DiagramForm).SidePanel.Controls.Clear();
            RelationshipPanel relationshipPanel = new RelationshipPanel()
            {
                Id = Id,
                RelationshipControl = this,
            };
            relationshipPanel.AutoScroll = true;
            relationshipPanel.Dock = DockStyle.Fill;
            relationshipPanel.Margin = new Padding(0);
            relationshipPanel.TabIndex = 1;
            (ParentForm as DiagramForm).SidePanel.Controls.Add(relationshipPanel);
        }
    }
}
