using System.Drawing.Drawing2D;

namespace DoQL.Utilities
{
    public static class Extensions
    {
        public static GraphicsPath AddRoundedRectangle(this GraphicsPath path, Rectangle bounds, int topLeft, int topRight, int bottomRight, int bottomLeft)
        {
            int diameter1 = topLeft * 2;
            int diameter2 = topRight * 2;
            int diameter3 = bottomRight * 2;
            int diameter4 = bottomLeft * 2;

            Rectangle arc1 = new Rectangle(bounds.Location, new Size(diameter1, diameter1));
            Rectangle arc2 = new Rectangle(bounds.Location, new Size(diameter2, diameter2));
            Rectangle arc3 = new Rectangle(bounds.Location, new Size(diameter3, diameter3));
            Rectangle arc4 = new Rectangle(bounds.Location, new Size(diameter4, diameter4));

            // top left arc  
            if (topLeft == 0)
                path.AddLine(arc1.Location, arc1.Location);
            else
                path.AddArc(arc1, 180, 90);

            // top right arc  
            arc2.X = bounds.Right - diameter2;
            if (topRight == 0)
                path.AddLine(arc2.Location, arc2.Location);
            else
                path.AddArc(arc2, 270, 90);

            // bottom right arc  
            arc3.X = bounds.Right - diameter3;
            arc3.Y = bounds.Bottom - diameter3;
            if (bottomRight == 0)
                path.AddLine(arc3.Location, arc3.Location);
            else
                path.AddArc(arc3, 0, 90);

            // bottom left arc 
            arc4.X = bounds.Left;
            arc4.Y = bounds.Bottom - diameter4;
            if (bottomLeft == 0)
                path.AddLine(arc4.Location, arc4.Location);
            else
                path.AddArc(arc4, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
