using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    public class WorkSpace
    {
        int Width;
        int Height;
        public List<Figure> Figures { get; set; }

        public WorkSpace(int width, int height)
        {
            Width = width;
            Height = height;
            Figures = new List<Figure>();
        }

        public Bitmap Render(double step = 1)
        {
            Bitmap workPlace = new Bitmap( Width, Height);
            
            foreach (Figure figure in Figures)
            {
                try
                {
                    List<DoublePoint> points = figure.PointsToDraw(step);
                    Color countorColor = figure.ContourColor;

                    foreach (DoublePoint p in points)
                    {
                        workPlace.SetPixel((int)p.X + figure.Position.X, (int)p.Y + figure.Position.Y, countorColor);
                    }
                }
                catch (Exception drawEx)
                {

                }
            }

            return workPlace;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach(Figure figure in Figures)
            {
                builder.AppendLine(figure.ToString());
            }

            return builder.ToString();
        }

    }
}
