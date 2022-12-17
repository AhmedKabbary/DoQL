using DoQL.Utilities;
using System.Drawing.Drawing2D;

namespace DoQL.Controls
{
    public partial class ChipControl : UserControl
    {
        public string Title { get; init; }
        public Color Color { get; init; }

        public ChipControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            lblTitle.Text = Title;
            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var borderRadius = 18;
            var brush = new SolidBrush(Color);

            using var path = new GraphicsPath();
            path.AddRoundedRectangle(ClientRectangle, borderRadius, borderRadius, borderRadius, borderRadius);
            e.Graphics.FillPath(brush, path);
            base.OnPaint(e);
        }
    }
}
