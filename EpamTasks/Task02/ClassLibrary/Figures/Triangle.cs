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
            if(a > b + c || b > a + c || c > a + b || a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Каждый параметр должен быть положительным, и не больше суммы двух других.");
            }

            this.a = a;
            this.b = b;
            this.c = c;
            
        }
    }
}
