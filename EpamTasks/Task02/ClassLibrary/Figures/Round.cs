using System;
using System.Collections.Generic;
using System.Drawing;

namespace Task02.ClassLibrary
{
    public class Round : Figure
    {
        //public Point Position { get; set; }
        private double _p;
        public double P { get { return _p; } }

        private double _area;
        public double Area { get { return _area; } }

        public bool IsFilled { get; set; } = false;

        private double _r;
        public double R
        {
            get
            {
                return _r;
            }
            set
            {
                _r = (value < 0? Math.Abs(value) : value );
                _p = 2 * Math.PI * _r;
                _area = Math.PI * _r * _r;
            }
        }
        
        public Round(Point position, double r, bool isFilled = false)
        {
            if (r <= 0)
            {
                throw new ArgumentOutOfRangeException("r", "Радиус должен быть больше нуля.");
            }

            IsFilled = isFilled;
            Position = position;
            R = r;
        }

        public override List<DoublePoint> PointsToDraw(double step = 2)
        {
            List<DoublePoint> points = new List<DoublePoint>();

            if (!IsFilled)
            {
                for (double i = -R; i <= R; i += step)
                {
                    points.Add(new DoublePoint(i, Math.Sqrt((Math.Pow(R, 2) - Math.Pow(i, 2)))));
                    points.Add(new DoublePoint(i, -Math.Sqrt((Math.Pow(R, 2) - Math.Pow(i, 2)))));

                    points.Add(new DoublePoint((Math.Sqrt((Math.Pow(R, 2) - Math.Pow(i, 2)))), i));
                    points.Add(new DoublePoint((-Math.Sqrt((Math.Pow(R, 2) - Math.Pow(i, 2)))), i));
                }
            }
            else
            {
                for (double i = -R; i <= R; i += step)
                {
                    double y = Math.Sqrt((Math.Pow(R, 2) - Math.Pow(i, 2)));
                    
                    for (double j = -y; j <= y; j += step)
                    {
                            points.Add(new DoublePoint(i, j));
                    }
                }
            }
            return points;
        }

        public override string ToString()
        {
            string filled = (IsFilled ? "Filled " : string.Empty);
            return $"{filled}Round, P = {P}, R = {R}, Area = {Area}";
        }
    }
}
