using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    public class Ring : Figure
    {
        //public Point Position { get; set; }
        public Color RingColor = Color.Black;
        public Round ExternalRound;
        public Round InternalRound;


        public Ring(Round internalRound, Round externalRound, Point position, Color color)
        {
            if(externalRound.R <= internalRound.R )
            {
                throw new ArgumentOutOfRangeException("Радиус внешней окружности не может быть меньше или равным радиусу внутренней.");
            }

            Position = position;
            RingColor = color;
            ExternalRound = externalRound;
            InternalRound = internalRound;

            ExternalRound.Position = Position;
            InternalRound.Position = Position;
        }

        public Ring(Round round, double thickness, Point position)
        {
            if (thickness == 0)
            {
                throw new ArgumentOutOfRangeException("Толщина кольца не может быть нулевой.");
            }

            if (thickness <0 && Math.Abs(thickness) >= round.R)
            {
                throw new ArgumentOutOfRangeException("Толщина кольца не может быть больше радиуса.");
            }

            Position = position;

            if(thickness > 0)
            {
                InternalRound = round;
                ExternalRound = new Round(position, round.R + thickness);
            }

            if (thickness < 0)
            {
                InternalRound = new Round(position, round.R + thickness); 
                ExternalRound = round;
            }

            ExternalRound.Position = Position;
            InternalRound.Position = Position;
        }

        public double Thickness
        {
            get
            {
                return ExternalRound.R - InternalRound.R;
            }
        }

        public double Area
        {
            get
            {
                return ExternalRound.Area - InternalRound.Area;
            }
        }

        public double P
        {
            get
            {
                return ExternalRound.P + InternalRound.P;
            }
        }

        public override List<DoublePoint> PointsToDraw(double step)
        {
            List<DoublePoint> points = new List<DoublePoint>();

            double R = ExternalRound.R;
            double r = InternalRound.R;


            for (double i = -R; i <= R; i += step)
            {
                double y = Math.Sqrt((Math.Pow(R, 2) - Math.Pow(i, 2)));
                double negativey = -y;

                double ry = Math.Sqrt((Math.Pow(r, 2) - Math.Pow(i, 2)));

                for (double j  = negativey; j <= y; j+=step)
                {

                    //if ((j < rnegativey || j > ry) || (i < negativey || i > y))  //|| (i < -r || i > r)


                    if
                        (
                            ((j >= -y || j <= y) && (j <= -ry || j >= ry)) || ((i < -y) || i > y)

                            //(j > negativey && j < rnegativey) || (j > ry && j < y) 
                        
                        )
                        points.Add(new DoublePoint(i, j));
                }

                /*points.Add(new DoublePoint(i, Math.Sqrt((Math.Pow(R, 2) - Math.Pow(i, 2)))));
                points.Add(new DoublePoint(i, -Math.Sqrt((Math.Pow(R, 2) - Math.Pow(i, 2)))));*/

                
            }
            return points;
        }

        public override string ToString()
        {
            return $"Ring, position: {Position.ToString()},"+
                $"Радиус внешней окружности: {ExternalRound.R}, внутренней: {InternalRound.R}, "+
                $"ширина кольца: {Thickness},\nплощадь кольца: {Area} m2,\nсумма длин окружностей: {P} m,\nцвет: {RingColor}\n";
        }
    }
}
