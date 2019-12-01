using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    class Enemy : GameObject
    {
        public Enemy(Point startCoordinates, Size objectSize)
        {
            Coordinates = startCoordinates;
            ObjectSize = objectSize;
        }

        public override void Collision(GameObject gameObject)
        {

        }

        public override string ToString()
        {
            return $"Enemy {Coordinates}, {ObjectSize}";
        }
    }
}
