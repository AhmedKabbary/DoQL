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
    public partial class EntityControl : BaseControl, IConnectable
    {
        public EntityControl()
        {
            InitializeComponent();
            this.Text = "Entity";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Size padding = new Size(48, 48);
            Size strSize = e.Graphics.MeasureString(this.Text, this.Font).ToSize();
            this.Size = strSize + padding;
            Point centerPoint = new Point(this.Width / 2 - strSize.Width / 2, this.Height / 2 - strSize.Height / 2);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), centerPoint);
            base.OnPaint(e);
        }

        public List<Point> GetConnectablePoints()
        {
            var points = new List<Point>();
            // left
            points.Add(new Point(0, 0));
            points.Add(new Point(0, Height / 2));
            points.Add(new Point(0, Height));
            // center
            points.Add(new Point(Width / 2, 0));
            points.Add(new Point(Width / 2, Height));
            // right
            points.Add(new Point(Width, 0));
            points.Add(new Point(Width, Height / 2));
            points.Add(new Point(Width, Height));
            return points;
        }
    }
}
