using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.ClassLibrary
{
    public class Player : GameObject
    {
        public int Lifes { get; set; }
        public int Score { get; set; }

        public Player(int startLifes, Point startCoordinates, Size size)
        {
            Lifes = startLifes;
            Coordinates = startCoordinates;
            ObjectSize = size;
        }

        public override void Collision(GameObject gameObject)
        {
            if (gameObject is Enemy)
            {
                if (Lifes > 0)
                {
                    Lifes--;
                }
                else
                {
                    WantDestroy = true;
                }
            }

            if (gameObject is Bonus)
            {
                Bonus bonusObject = (gameObject as Bonus);
                if (bonusObject.Type == BonusType.Life)
                {
                    Lifes += bonusObject.Value;
                }

                if (bonusObject.Type == BonusType.Score)
                {
                    Score += bonusObject.Value;
                }
            }

            if(gameObject is Block)
            {
                Block blockObject = (gameObject as Block);
            }
        }

        public override string ToString()
        {
            return $"Player {Coordinates}, {ObjectSize}, Lifes: {Lifes}, Score: {Score}";
        }
    }
}
