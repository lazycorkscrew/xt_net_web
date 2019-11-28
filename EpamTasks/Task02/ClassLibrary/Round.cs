using System;
using System.Drawing;

namespace Task02.ClassLibrary
{
    public class Round
    {
        public Point Position { get; set; }
        private double _p;
        public double P { get { return _p; } }

        private double _area;
        public double Area { get { return _area; } }

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
        
        public Round(Point position, double r)
        {
            if (r <= 0)
            {
                throw new ArgumentOutOfRangeException("r", "Радиус должен быть больше нуля.");
            }

            this.Position = position;
            R = r;
        }
    }
}
