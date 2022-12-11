using System.Drawing.Drawing2D;
using DoQL.Interfaces;
using DoQL.Utilities;

namespace DoQL.Controls.ERD
{
    public partial class RelationshipControl : BaseControl, IConnectable
    {
        public RelationshipControl()
        {
            InitializeComponent();
            this.Text = "Has";
        }

        private Size strSize;

        protected override void OnLoad(EventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            {
                var padding = new Size(64, 64);
                strSize = graphics.MeasureString(this.Text, this.Font).ToSize();
                this.Size = strSize + padding;
            }

            using (var path = new GraphicsPath())
            {
                path.AddPolygon(new Point[]
                {
                    new Point(0, this.Height/2),
                    new Point(this.Width/2, 0),
                    new Point(this.Width, this.Height/2),
                    new Point(this.Width/2, this.Height),
                });
                this.Region = new Region(path);
            }

            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var centerPoint = new Point(this.Width / 2 - strSize.Width / 2, this.Height / 2 - strSize.Height / 2);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), centerPoint);
            base.OnPaint(e);
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
            return new[] { ErdSymbol.Entity };
        }

        public void Connect(IConnectable connectableControl)
        {
            // make sure it is connected with 2 entities only
            if (connectableControl is EntityControl entityControl)
            {
                var diagramPanel = Parent as DiagramPanel;

                IEnumerable<Connection> currentConnections = diagramPanel.Connections
                    .Where(c => c.IsValidConnection())
                    .Where(c => c.Control1.ConnectableControl == this || c.Control2.ConnectableControl == this);

                if (currentConnections.Count() == 2)
                {
                    Connection duplicateConnection = currentConnections.FirstOrDefault(c => c.Control1.ConnectableControl == entityControl || c.Control2.ConnectableControl == entityControl);
                    if (duplicateConnection != null)
                        diagramPanel.Connections.Remove(duplicateConnection);
                    else
                        diagramPanel.Connections.Remove(currentConnections.First());
                }
            }
        }

        #endregion
    }
}
