using System.Drawing.Drawing2D;
using DoQL.Controls.Panels;
using DoQL.Forms;
using DoQL.Interfaces;
using DoQL.Models;
using DoQL.Utilities;
using Attribute = DoQL.Models.ERD.Attribute;

namespace DoQL.Controls.ERD
{
    public partial class AttributeControl : BaseControl, IConnectable, IDeletable
    {
        public string Id { get; init; }

        public AttributeControl()
        {
            InitializeComponent();
            Text = "Attribute";
        }

        private Size strSize;

        protected override void OnLoad(EventArgs e)
        {
            using (Graphics graphics = CreateGraphics())
            {
                var padding = new Size(48, 48);
                strSize = graphics.MeasureString(Text, Font).ToSize();
                Size = strSize + padding;
            }

            using (var path = new GraphicsPath())
            {
                path.AddEllipse(ClientRectangle);
                Region = new Region(path);
            }

            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var centerPoint = new Point(Width / 2 - strSize.Width / 2, Height / 2 - strSize.Height / 2);
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), centerPoint);
            base.OnPaint(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (IsHandleCreated)
            {
                Database db = (ParentForm as DiagramForm).Database;
                db.Erd.Attributes.Find(a => a.Id == Id).Position = Location;
            }
            base.OnLocationChanged(e);
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
            return new[] { ErdSymbol.Entity, ErdSymbol.Relationship };
        }

        public void Connect(IConnectable connectableControl)
        {
            if (connectableControl is EntityControl || connectableControl is RelationshipControl)
            {
                var diagramPanel = Parent as DiagramPanel;

                Connection currentConnection = diagramPanel.Connections
                    .Where(c => c.IsValidConnection())
                    .FirstOrDefault(c => c.Control1.ConnectableControl == this || c.Control2.ConnectableControl == this);

                if (currentConnection != null)
                {
                    diagramPanel.RemoveConnection(currentConnection);
                }
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
            Attribute attribute = diagramForm.Database.Erd.Attributes.Find(a => a.Id == Id);
            diagramForm.Database.Erd.Attributes.Remove(attribute);

            Parent.Controls.Remove(this);

            diagramPanel.RedrawConnections();
        }

        private void showAttributePanel(object sender, EventArgs e)
        {
            (ParentForm as DiagramForm).SidePanel.Controls.Clear();
            AttributePanel attributePanel = new AttributePanel() { Id = Id };
            attributePanel.AutoScroll = true;
            attributePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            attributePanel.Margin = new System.Windows.Forms.Padding(0);
            attributePanel.Size = new System.Drawing.Size(345, 518);
            attributePanel.TabIndex = 1;
            (ParentForm as DiagramForm).SidePanel.Controls.Add(attributePanel);
        }
    }
}
