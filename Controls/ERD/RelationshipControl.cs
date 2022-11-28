using DoQL.Interfaces;
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
                Size padding = new Size(64, 64);
                strSize = graphics.MeasureString(this.Text, this.Font).ToSize();
                this.Size = strSize + padding;
            }

            using (GraphicsPath path = new GraphicsPath())
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
            Point centerPoint = new Point(this.Width / 2 - strSize.Width / 2, this.Height / 2 - strSize.Height / 2);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), centerPoint);
            base.OnPaint(e);
        }

        public List<Point> GetConnectablePoints()
        {
            var points = new List<Point>();
            // left
            points.Add(new Point(0, Height / 2));
            // center
            points.Add(new Point(Width / 2, 0));
            points.Add(new Point(Width / 2, Height));
            // right
            points.Add(new Point(Width, Height / 2));
            return points;
        }
    }
}
