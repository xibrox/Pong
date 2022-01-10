using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ping_Pong {
    class Wall {
        public Brush Brush { get; set; }
        public Size Size { get; set; }
        public Point Location { get; set; }
        public Rectangle Rectangle {
            get {
                return new Rectangle(Location, Size);
            }
        }
        public int Speed { get; set; }

        public int Left { get; set; }
        public int Right { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }

        public Wall(Brush brush, Size size, Point location, int speed) {
            Brush = brush;
            Size = size;
            Location = location;
            Speed = speed;
        }

        public Wall(int left, int right, int up, int down) {
            Left = left;
            Right = right;
            Up = up;
            Down = down;
        }

        public void Draw(Graphics graphics) {
            graphics.FillRectangle(Brush, Rectangle);
        }

        public void Move(Point direction) {
            Location = new Point(Location.X + direction.X * Speed, Location.Y + direction.Y * Speed);
        }

        public bool Intersect(Rectangle rectangle) {
            return Rectangle.IntersectsWith(rectangle);
        }
    }
}
