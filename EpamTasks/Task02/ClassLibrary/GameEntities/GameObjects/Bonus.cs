using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{ 
    enum BonusType
    {
        Life = 1,
        Score = 2
    }

    class Bonus : GameObject
    {
        public BonusType Type { get; private set; }
        public int Value {get; private set;} = 1;

        public Bonus(Point startCoordinates, Size size, BonusType type, int value = 1)
        {
            Value = value;
            Type = type;
        }

        public override void Collision(GameObject gameObject)
        {
            if(gameObject is Player)
            {
                WantDestroy = true;
                //не придумал
            }
        }

        public override string ToString()
        {
            return $"Bonus {Coordinates}, {ObjectSize}, Type: {Type}, Value: {Value}";
        }
    }
}
