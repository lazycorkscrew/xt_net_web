using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    public class Ring
    {
        public Point Position { get; set; }

        public Round ExternalRound;
        public Round InternalRound;

        public Ring(Round internalRound, Round externalRound, Point position)
        {
            if(ExternalRound.R <= InternalRound.R )
            {
                throw new ArgumentOutOfRangeException("Радиус внешней окружности не может быть меньше или равным радиусу внутренней.");
            }

            Position = position;

            ExternalRound = externalRound;
            InternalRound = internalRound;

            ExternalRound.Position = Position;
            InternalRound.Position = Position;
        }

        public Ring(Round round, double thickness, Point position)
        {
            if(thickness <=0 && Math.Abs(thickness) >= round.R)
            {
                throw new ArgumentOutOfRangeException();
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
    }
}
