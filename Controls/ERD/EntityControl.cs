﻿using DoQL.Controls.Panels;
using DoQL.Forms;
using DoQL.Interfaces;
using DoQL.Models;
using DoQL.Models.ERD;
using DoQL.Utilities;

namespace DoQL.Controls.ERD
{
    public partial class EntityControl : BaseControl, IConnectable, IDeletable
    {
        public string Id { get; init; }
        public string DisplayName { get; set; } = "Entity";

        public EntityControl()
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
                var padding = new Size(48, 48);
                strSize = graphics.MeasureString(DisplayName, Font).ToSize();
                Size = strSize + padding;
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
                db.Erd.Entities.Find(e => e.Id == Id).Position = Location;
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
                new Point(0, 0),
                new Point(0, Height / 2),
                new Point(0, Height),
                // center
                new Point(Width / 2, 0),
                new Point(Width / 2, Height),
                // right
                new Point(Width, 0),
                new Point(Width, Height / 2),
                new Point(Width, Height)
            };
        }

        public ErdSymbol[] GetSupportedSymbols()
        {
            return new[] { ErdSymbol.Attribute, ErdSymbol.Relationship };
        }

        public void Connect(IConnectable connectableControl)
        {
            if (connectableControl is AttributeControl attributeControl)
            {
                attributeControl.Connect(this);
            }
            if (connectableControl is RelationshipControl relationshipControl)
            {
                relationshipControl.Connect(this);
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
            Entity entity = diagramForm.Database.Erd.Entities.Find(e => e.Id == Id);
            diagramForm.Database.Erd.Entities.Remove(entity);

            Parent.Controls.Remove(this);

            diagramPanel.RedrawConnections();
        }

        private void ShowEntityPanel(object sender, EventArgs e)
        {
            (ParentForm as DiagramForm).SidePanel.Controls.Clear();
            EntityPanel entityPanel = new EntityPanel()
            {
                Id = Id,
                EntityControl = this,
            };
            entityPanel.AutoScroll = true;
            entityPanel.Dock = DockStyle.Fill;
            entityPanel.Margin = new Padding(0);
            entityPanel.TabIndex = 1;
            (ParentForm as DiagramForm).SidePanel.Controls.Add(entityPanel);
        }
    }
}
