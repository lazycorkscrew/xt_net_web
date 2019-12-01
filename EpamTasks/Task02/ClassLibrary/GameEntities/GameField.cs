using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task02.ClassLibrary
{
    public class GameField
    {
        public readonly Size FieldSize;
        public List<GameObject> GameObjects { get; private set; }
        public Player GamePlayer { get; private set; }
        public bool GameOver { get; private set; } = false;
        private int _gameRate = 1;

        public GameField(int width, int height)
        {
            GameObjects = new List<GameObject>();
            FieldSize = new Size(width, height);
        }

        public void SetGameObjects(List<GameObject> gameObjects)
        {
            GameObjects = gameObjects;
        }

        public void AddGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void SetPlayer(Player gamePlayer)
        {
            GamePlayer = gamePlayer;
        }

        public void PlayerMove(KeyEventArgs keyCode)
        {
            Direction d = Direction.None;

            if(keyCode.KeyCode.HasFlag(Keys.W))
            {
                d ^= Direction.Up;
            }
            if (keyCode.KeyCode.HasFlag(Keys.A))
            {
                d ^= Direction.Left;
            }
            if (keyCode.KeyCode.HasFlag(Keys.S))
            {
                d ^= Direction.Down;
            }
            if (keyCode.KeyCode.HasFlag(Keys.D))
            {
                d ^= Direction.Right;
            }

            if(GamePlayer != null || !GamePlayer.WantDestroy)
            {
                GamePlayer.Move(d, _gameRate);
            }
        }

        public void CheckCollision(Player player)
        {
            int gameObjectsCount = GameObjects.Count;
            for (int i = 0; i < gameObjectsCount; i++)
            {
                for (int j = 0; j < gameObjectsCount; j++)
                {
                    if(i != j)
                    {
                        int x1 = GameObjects[i].Coordinates.X;
                        int y1 = GameObjects[i].Coordinates.Y;
                        int w1 = GameObjects[i].ObjectSize.Width;
                        int h1 = GameObjects[i].ObjectSize.Height;

                        int x2 = GameObjects[j].Coordinates.X;
                        int y2 = GameObjects[j].Coordinates.Y;
                        int w2 = GameObjects[j].ObjectSize.Width;
                        int h2 = GameObjects[j].ObjectSize.Height;

                        if ((x1+w1) > x2 && x1< (x2+w2) && (y1 + h1) > y2 && y1 < (y2 + h2))
                        {
                            GameObjects[i].Collision(GameObjects[j]);
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"GameField {FieldSize}");
            if (GamePlayer != null)
            {
                builder.AppendLine($"\t{GamePlayer}");
            }
            foreach(GameObject gameObject in GameObjects)
            {
                builder.AppendLine( $"\t{gameObject}");
            }

            return builder.ToString();
        }

    }
}
