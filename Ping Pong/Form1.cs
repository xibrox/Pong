using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_Pong {
    public partial class Form1 : Form {
        Ball ball;
        Wall wall1;
        Wall wall2;

        enum Position {
            Up, Down, Null
        }

        enum Position1 {
            W, S, Null
        }

        private Position position;
        private Position1 position1;

        public Form1() {
            InitializeComponent();
            Init();

            position = Position.Null;
            position1 = Position1.Null;
            SetBall();
            SetWall1();
            SetWall2();
        }

        //Screen Settings

        public void Init() {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.TopMost = true;

            this.pbCanvas.BackColor = Color.FromArgb(0, 0, 0);
            this.pbCanvas.Size = this.Size;
            this.pbCanvas.Location = new Point(0, 0);
        }

        //Spawning Ball

        public void SetBall() {
            var size = new Size(50, 50);
            var location = new Point(50 + size.Width, (pbCanvas.Height / 2) - size.Height);

            ball = new Ball(Brushes.White, size, location, 5);
        }

        //Spawning Wall1

        public void SetWall1() {
            var size = new Size(50, 200);
            var location = new Point(50, (pbCanvas.Height / 2) - size.Height);

            wall1 = new Wall(Brushes.White, size, location, 5);
        }

        //Spawning Wall2

        public void SetWall2() {
            var size = new Size(50, 200);
            var location = new Point(pbCanvas.Width - 50 - size.Width, (pbCanvas.Height / 2) - size.Height);

            wall2 = new Wall(Brushes.White, size, location, 5);
        }

        //Drawing on Canvas

        private void pbCanvas_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;

            ball.Draw(g);

            wall1.Draw(g);

            wall2.Draw(g);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }

            //Movement for Player1

            if (Keys.W == e.KeyCode) {
                position1 = Position1.W;
            }

            if (Keys.S == e.KeyCode) {
                position1 = Position1.S;
            }

            //Movement for Player2

            if (Keys.Up == e.KeyCode) {
                position = Position.Up;
            }

            if (Keys.Down == e.KeyCode) {
                position = Position.Down;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            //Movement for Player1

            if (Keys.W == e.KeyCode) {
                position1 = Position1.Null;
            }

            if (Keys.S == e.KeyCode) {
                position1 = Position1.Null;
            }

            //Movement for Player2

            if (Keys.Up == e.KeyCode) {
                position = Position.Null;
            }

            if (Keys.Down == e.KeyCode) {
                position = Position.Null;
            }
        }

        private void Timer_Tick(object sender, EventArgs e) {
            var direction = new Point();

            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, 0, pbCanvas.Size.Height);

            if (position1 == Position1.W && wall1.Location.Y > boundary.Up) {
                direction.Y--;
            }

            if (position1 == Position1.S && wall1.Location.Y < (boundary.Down - wall2.Size.Height)) {
                direction.Y++;
            }

            wall1.Move(direction);

            this.pbCanvas.Refresh();
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            var direction = new Point();

            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, 0, pbCanvas.Size.Height);

            if (position == Position.Up && wall2.Location.Y > boundary.Up) {
                direction.Y--;
            }

            if (position == Position.Down && wall2.Location.Y < (boundary.Down - wall2.Size.Height)) {
                direction.Y++;
            }

            wall2.Move(direction);

            this.pbCanvas.Refresh();
        }

        private void Timer2_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.X++;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void Timer3_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.X--;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void Timer4_Tick(object sender, EventArgs e) {
            var direction = new Point();

            
            direction.Y++;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void Timer5_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.Y--;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void HandleCollision() {
            var direction = new Point();
            Boundary boundary = new Boundary(new Size(0, pbCanvas.Size.Height), new Point(0, 0));

            //if (ball.Intersect(boundary.Rectangle)) {
            //    Timer4.Enabled = false;
            //    Timer4.Enabled = true;
            //}

            //if (ball.Intersect(boundary.Rectangle)) {
            //    Timer4.Enabled = false;
            //    Timer4.Enabled = true;
            //}

            if (ball.Intersect(wall1.Rectangle)) {
                Timer2.Enabled = true;
                Timer3.Enabled = false;
            }

            if (ball.Intersect(wall2.Rectangle)) {
                Timer2.Enabled = false;
                Timer3.Enabled = true;
            }

            ball.Move(direction);
        }
    }
}
