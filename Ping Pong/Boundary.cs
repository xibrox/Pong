using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Ping_Pong {
    class Boundary {
        public int Left { get; set; }
        public int Right { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }

        public Boundary(int left, int right, int up, int down) {
            Left = left;
            Right = right;
            Up = up;
            Down = down;
        }
    }
}
