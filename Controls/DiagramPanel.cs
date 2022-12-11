using System.Drawing.Drawing2D;
using DoQL.Controls.ERD;
using DoQL.Interfaces;
using DoQL.Utilities;

namespace DoQL.Controls
{
    public partial class DiagramPanel : Panel
    {
        public DiagramPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Connections = new List<Connection>();
        }

        #region dragging

        private bool _selected;
        private Point _point;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _selected = true;
            _point = e.Location;
            Cursor = Cursors.Hand;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_selected)
            {
                SuspendLayout();
                foreach (BaseControl control in Controls.OfType<BaseControl>())
                {
                    control.SuspendLayout();
                    control.Left += e.X - _point.X;
                    control.Top += e.Y - _point.Y;
                    control.ResumeLayout();
                }
                ResumeLayout();
                _point = e.Location;
                RedrawCardinalities();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _selected = false;
            Cursor = Cursors.Default;
            base.OnMouseUp(e);
        }

        #endregion

        #region connections drawing

        public List<Connection> Connections { get; set; }

        public void RedrawCardinalities() => Invalidate();

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var pen = new Pen(Brushes.Gray, 2);
            foreach (var connection in Connections)
            {
                Point p1;
                Point p2;

                if (connection.Control1.IsValidConnection())
                {
                    p1 = MapChildPointToThis(connection.Control1.ConnectableControl as Control, connection.Control1.ConnectableControl.GetConnectablePoints()[connection.Control1.ConnectorId]);
                }
                else p1 = connection.Control1.Position;

                if (connection.Control2.IsValidConnection())
                {
                    p2 = MapChildPointToThis(connection.Control2.ConnectableControl as Control, connection.Control2.ConnectableControl.GetConnectablePoints()[connection.Control2.ConnectorId]);
                }
                else p2 = connection.Control2.Position;

                e.Graphics.DrawLine(pen, p1, p2);
            }
            base.OnPaint(e);
        }

        public static Point MapChildPointToThis(Control control, Point point)
        {
            point.Offset(control.Location);
            return point;
        }

        #endregion

        #region symbols connectors visibility

        public void ShowConnectors(params ErdSymbol[] symbols)
        {
            foreach (BaseControl control in Controls.OfType<BaseControl>().ToList())
            {
                if (symbols.Contains(ErdSymbol.Entity))
                    if (control is EntityControl)
                        control.ShowConnectors();

                if (symbols.Contains(ErdSymbol.Attribute))
                    if (control is AttributeControl)
                        control.ShowConnectors();

                if (symbols.Contains(ErdSymbol.Relationship))
                    if (control is RelationshipControl)
                        control.ShowConnectors();
            }
        }

        public void HideAllConnectors()
        {
            foreach (BaseControl control in Controls.OfType<BaseControl>().ToList())
                control.HideConnectors();
        }

        #endregion
    }

    public class Connection
    {
        public ControlConnector Control1 { get; set; }
        public ControlConnector Control2 { get; set; }

        public bool IsValidConnection() => Control1.IsValidConnection() && Control2.IsValidConnection();

        public class ControlConnector
        {
            public Point Position { get; set; }
            public int ConnectorId { get; set; }
            public IConnectable ConnectableControl { get; set; }

            public bool IsValidConnection() => ConnectableControl != null;
        }
    }
}
