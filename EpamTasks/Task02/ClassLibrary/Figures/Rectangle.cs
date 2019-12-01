using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    public class Rectangle : Figure
    {
        double Width { get; set; }
        double Height { get; set; }

        public Rectangle(Point position, double width, double height)
        {
            Position = position;
            Width = width;
            Height = height;
        }

        public override List<DoublePoint> PointsToDraw(double step)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Rectangle, W={Width}, H={Height}";
        }
    }
}
