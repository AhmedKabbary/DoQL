using DoQL.Controls.ERD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoQL.Controls
{
    public partial class ConnectorControl : UserControl
    {
        public ConnectorControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(this.ClientRectangle);
                this.Region = new Region(path);
            }
            base.OnLoad(e);
        }

        public BaseControl BaseControl { get; set; }

        #region connector dragging events

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        #endregion

        #region connectors visibility events

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BaseControl.HideConnectors(true);
        }

        #endregion
    }
}
