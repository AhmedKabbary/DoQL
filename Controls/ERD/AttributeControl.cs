using System.Drawing.Drawing2D;
using DoQL.Interfaces;
using DoQL.Utilities;

namespace DoQL.Controls.ERD
{
    public partial class AttributeControl : BaseControl, IConnectable
    {
        public AttributeControl()
        {
            InitializeComponent();
            this.Text = "Attribute";
        }

        private Size strSize;

        protected override void OnLoad(EventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            {
                var padding = new Size(48, 48);
                strSize = graphics.MeasureString(this.Text, this.Font).ToSize();
                this.Size = strSize + padding;
            }

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(this.ClientRectangle);
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
            if (connectableControl is EntityControl entityControl)
            {
                var diagramPanel = Parent as DiagramPanel;

                Connection currentConnection = diagramPanel.Connections
                    .Where(c => c.IsValidConnection())
                    .FirstOrDefault(c => c.Control1.ConnectableControl == this || c.Control2.ConnectableControl == this);

                if (currentConnection != null)
                {
                    diagramPanel.Connections.Remove(currentConnection);
                }
            }
        }

        #endregion
    }
}
