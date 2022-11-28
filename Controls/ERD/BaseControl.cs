using DoQL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoQL.Controls.ERD
{
    public partial class BaseControl : UserControl
    {
        public BaseControl()
        {
            InitializeComponent();
            _connectors = new List<ConnectorControl>();
        }

        // relations

        private readonly List<ConnectorControl> _connectors;

        protected override void OnMouseEnter(EventArgs e)
        {
            ShowConnectors();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HideConnectors();
            base.OnMouseLeave(e);
        }

        public void ShowConnectors()
        {
            if (this is IConnectable)
            {
                IConnectable connectable = (IConnectable)this;
                foreach (Point point in connectable.GetConnectablePoints())
                {
                    point.Offset(this.Location);
                    var connector = new ConnectorControl();
                    point.Offset(-connector.Width / 2, -connector.Height / 2);
                    connector.Location = point;
                    _connectors.Add(connector);
                    Parent.Controls.Add(connector);
                    Parent.Controls.SetChildIndex(connector, 0);
                }
            }
        }

        public void HideConnectors()
        {
            foreach (ConnectorControl connector in _connectors)
            {
                Parent.Controls.Remove(connector);
            }
            _connectors.Clear();
        }

        // dragging

        Point point;
        bool selected;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            selected = true;
            point = e.Location;
            HideConnectors();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            selected = false;
            ShowConnectors();
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (selected)
            {
                // move control itself
                this.SuspendLayout();
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
                this.ResumeLayout();
            }
            base.OnMouseMove(e);
        }
    }
}
