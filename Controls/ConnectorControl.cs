using System.Drawing.Drawing2D;
using DoQL.Controls.ERD;
using DoQL.Interfaces;

namespace DoQL.Controls
{
    public partial class ConnectorControl : UserControl
    {
        public int Index { get; init; }
        public IConnectable ConnectableControl { get; init; }

        public ConnectorControl(IConnectable connectableControl, int index)
        {
            Index = index;
            ConnectableControl = connectableControl;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(ClientRectangle);
                Region = new Region(path);
            }
            base.OnLoad(e);
        }

        #region connector dragging events

        private Connection _activeConnection = null;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _activeConnection = new Connection
            {
                Control1 = new Connection.ControlConnector
                {
                    ConnectorId = Index,
                    ConnectableControl = ConnectableControl,
                    Position = MapPointToParent(new Point(Width / 2, Height / 2)),
                },
                Control2 = new Connection.ControlConnector
                {
                    Position = MapPointToParent(e.Location),
                }
            };
            (Parent as DiagramPanel).Connections.Add(_activeConnection);
            (Parent as DiagramPanel).ShowConnectors(ConnectableControl.GetSupportedSymbols());
            base.OnMouseDown(e);
        }

        private ConnectorControl _activeHoveredConnector = null;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // update connection line while moving
            if (_activeConnection != null)
            {
                _activeConnection.Control2.Position = MapPointToParent(e.Location);
                (Parent as DiagramPanel).RedrawCardinalities();
            }

            // drop effect on other connectors when hovered
            var hoveredControl = Parent.GetChildAtPoint(MapPointToParent(e.Location));
            if (hoveredControl is ConnectorControl hoveredConnector)
            {
                _activeHoveredConnector = hoveredConnector;
                _activeHoveredConnector.SetHoverMode(HoverMode.Focused);
            }
            else
            {
                if (_activeHoveredConnector != null)
                {
                    _activeHoveredConnector.SetHoverMode(HoverMode.Normal);
                    _activeHoveredConnector = null;
                }
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // make a valid connection when there is an active hovered control
            if (_activeHoveredConnector != null)
            {
                _activeHoveredConnector.ConnectableControl.Connect(ConnectableControl);
                _activeConnection.Control2.ConnectableControl = _activeHoveredConnector.ConnectableControl;
                _activeConnection.Control2.ConnectorId = _activeHoveredConnector.Index;
            }

            // remove the connection line if not connected with another connector
            if (_activeConnection != null)
            {
                if (!_activeConnection.IsValidConnection())
                {
                    (Parent as DiagramPanel).Connections.Remove(_activeConnection);
                    _activeConnection = null;
                }
            }

            (Parent as DiagramPanel).RedrawCardinalities();
            (Parent as DiagramPanel).HideAllConnectors();
            base.OnMouseUp(e);
        }

        public Point MapPointToParent(Point point)
        {
            point.Offset(Location);
            return point;
        }

        #endregion

        #region connectors hover events

        protected override void OnMouseEnter(EventArgs e)
        {
            SetHoverMode(HoverMode.Focused);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SetHoverMode(HoverMode.Normal);
            // force hide connectors
            (ConnectableControl as BaseControl).HideConnectors(true);
            base.OnMouseLeave(e);
        }

        public void SetHoverMode(HoverMode mode)
        {
            if (mode == HoverMode.Focused)
                BackColor = Color.DarkGray;
            else
                BackColor = Color.Gray;
        }

        #endregion
    }

    public enum HoverMode
    {
        Normal,
        Focused,
    }
}
