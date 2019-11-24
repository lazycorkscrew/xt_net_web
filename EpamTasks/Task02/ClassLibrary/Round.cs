using System;
using System.Drawing;

namespace Task02.ClassLibrary
{
    public class Round
    {
        public Point position { get; set; }
        private double _p;
        public double P { get { return _p; } }

        private double _s;
        public double S { get { return _s; } }

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
                _s = Math.PI * _r * _r;
            }
        }
        
        public Round(Point position, double r)
        {
            this.position = position;
            R = (r < 0? Math.Abs(r) : r);
        }
    }
}
