using System;
using System.Collections.Generic;
using System.Drawing;

namespace Task02.ClassLibrary
{
    class Line :Figure
    {
        //Лист для того, чтобы можно было создать ломанную линию, если надо
        List<Point> NextPositions { get; set; }

        public Line(Point p1, Point p2)
        {
            Position = p1;
            NextPositions = new List<Point>();
            NextPositions.Add(p2);
        }

        public Line(Point startPosition, List<Point> pn)
        {
            Position = startPosition;
            NextPositions = pn;
        }

        public override List<DoublePoint> PointsToDraw(double step)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string s = $"Линия {Position} ";

            foreach(Point nextPos in NextPositions)
            {
                s = $"{s} {nextPos}";
            }

            return s;
        }
    }
}
