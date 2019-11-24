using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    class Triangle
    {
        public double a;
        public double b;
        public double c;

        public double P
        {
            get
            {
                return a + b + c;
            }
        }

        public double S
        {
            get
            {
                double halfP = P/2;
                return Math.Sqrt(halfP * (halfP - a) * (halfP - b) * (halfP - c));
            }
        }

        public Triangle(double a, double b, double c)
        {
            this.a = (a > 0 ? a : Math.Abs(a));
            this.b = (b > 0 ? b : Math.Abs(b));
            this.c = (c > 0 ? c : Math.Abs(c));
        }
    }
}
