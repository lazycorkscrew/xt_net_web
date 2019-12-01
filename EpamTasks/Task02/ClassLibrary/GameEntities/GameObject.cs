using System;
using System.Drawing;

namespace Task02.ClassLibrary
{
    public enum Direction
    {
        None = 0,
        Up = 1,
        Left = 2,
        Down = 4,
        Right = 8,
        UpLeft = Up | Left,
        DownLeft = Down | Left,
        UpRight = Up | Right,
        DownRight = Down | Right
    }

    public abstract class GameObject
    {
        private Point _coordinates;
        public Point Coordinates {get; protected set;}
        
        public Point Center;

        public Direction ForbiddenDirection { get; set; }

        public Size ObjectSize { get; set; }
        public Bitmap Texture { get; private set; }
        public bool WantDestroy = false;

        public abstract void Collision(GameObject gameObject);

        public bool IsCollide(GameObject gameObject)
        {
            int x1 = Coordinates.X;
            int y1 = Coordinates.Y;
            int w1 = ObjectSize.Width;
            int h1 = ObjectSize.Height;

            int x2 = gameObject.Coordinates.X;
            int y2 = gameObject.Coordinates.Y;
            int w2 = gameObject.ObjectSize.Width;
            int h2 = gameObject.ObjectSize.Height;

            return (((x1 + w1) > x2) && (x1 < (x2 + w2)) && ((y1 + h1) > y2) && (y1 < (y2 + h2)));
        }

        public virtual void Move(Direction direction, int value)
        {
            if(direction.HasFlag(Direction.Up) && !ForbiddenDirection.HasFlag(Direction.Up))
                _coordinates.Y -= value;
            if (direction.HasFlag(Direction.Left) && !ForbiddenDirection.HasFlag(Direction.Left))
                _coordinates.X -= value;
            if (direction.HasFlag(Direction.Down) && !ForbiddenDirection.HasFlag(Direction.Down))
                _coordinates.Y += value;
            if (direction.HasFlag(Direction.Right) && !ForbiddenDirection.HasFlag(Direction.Right))
                _coordinates.X += value;

            /*
            switch (direction)
            {
                case Direction.Up: _coordinates.Y -= value; break;
                case Direction.Left: _coordinates.X -= value; break;
                case Direction.Down: _coordinates.Y += value; break;
                case Direction.Right: _coordinates.X += value; break;
                case Direction.UpLeft { _coordinates.Y -= value; _coordinates.X -= value; break; }
                case Direction.DownLeft { _coordinates.Y += value; _coordinates.X -= value; break; }
                case Direction.UpRight { _coordinates.Y -= value; _coordinates.X += value; break; }
                case Direction.DownRight { _coordinates.Y += value; _coordinates.X += value; break; }
                default: break;
            }*/
        }

        public override string ToString()
        {
            return $"GameObject {Coordinates}, {ObjectSize}";
        }
    }
}
