using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ping_Pong {
    class Ball {
        public Brush Brush { get; set; }
        public Size Size { get; set; }
        public Point Location { get; set; }
        public Rectangle Rectangle {
            get {
                return new Rectangle(Location, Size);
            }
        }
        public int Speed { get; set; }

        public Ball(Brush brush, Size size, Point location, int speed) {
            Brush = brush;
            Size = size;
            Location = location;
            Speed = speed;
        }

        public void Draw(Graphics graphics) {
            graphics.FillEllipse(Brush, Rectangle);
        }

        public void Move(Point direction) {
            Location = new Point(Location.X + direction.X * Speed, Location.Y + direction.Y * Speed);
        }

        public bool Intersect(Rectangle rectangle) {
            return Rectangle.IntersectsWith(rectangle);
        }
    }
}
