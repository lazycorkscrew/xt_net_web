using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    class Block : GameObject
    {

        public Block(Point objectPoint, Size objectSize)
        {
            Coordinates = objectPoint;
            ObjectSize = objectSize;
        }

        public override void Collision(GameObject gameObject)
        {

        }

        public override string ToString()
        {
            return $"Block {Coordinates}, {ObjectSize}";
        }
    }
}
