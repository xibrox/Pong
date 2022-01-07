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
        Random rnd = new Random();
        int num = 0;
        int wall1Score = 0;
        int wall2Score = 0;

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
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            this.pbCanvas.BackColor = Color.FromArgb(0, 0, 0);
            this.pbCanvas.Size = this.Size;
            this.pbCanvas.Bounds = this.Bounds;
        }

        //Spawning Ball

        public void SetBall() {
            var size = new Size(50, 50);
            var location = new Point((pbCanvas.Width / 2) - size.Width, (pbCanvas.Height / 2) - size.Height);

            ball = new Ball(Brushes.White, size, location, 5);
        }

        //Spawning Wall1

        public void SetWall1() {
            var size = new Size(50, 200);
            var location = new Point(50, (pbCanvas.Height / 2) - size.Height / 2);

            wall1 = new Wall(Brushes.White, size, location, 5);
        }

        //Spawning Wall2

        public void SetWall2() {
            var size = new Size(50, 200);
            var location = new Point(pbCanvas.Width - 50 - size.Width, (pbCanvas.Height / 2) - size.Height / 2);

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
            direction.Y++;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void Timer3_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.X++;
            direction.Y--;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void Timer4_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.X--;
            direction.Y++;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void Timer5_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.X--;
            direction.Y--;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void ScoreWall1() {
            wall1Score++;
            label1.Text = "" + wall1Score;
        }

        private void ScoreWall2() {
            wall2Score++;
            label2.Text = "" + wall2Score;
        }

        private void HandleCollision() {
            var direction = new Point();
            Boundary boundaryBot = new Boundary(new Point(0, pbCanvas.Location.Y - ball.Size.Height), new Size(pbCanvas.Size.Width, 10));
            Boundary boundaryTop = new Boundary(new Point(0, -1), new Size(pbCanvas.Size.Width, 10));
            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, 0, pbCanvas.Size.Height);

            if (ball.Location.X > boundary.Right) {
                ScoreWall2();
                SetBall();
                SetWall1();
                SetWall2();
            }

            if (ball.Location.X < (boundary.Left - ball.Size.Width)) {
                ScoreWall1();
                SetBall();
                SetWall1();
                SetWall2();
            }

            if (ball.Location.Y > (boundary.Down - ball.Size.Height) && num == 0) {
                Timer2.Enabled = false;
                Timer3.Enabled = true;
                Timer4.Enabled = false;
                Timer5.Enabled = false;
                num = 1;
            }

            if (ball.Location.Y < boundary.Up && num == 1) {
                Timer2.Enabled = true;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = false;
                num = 0;
            }

            if (ball.Location.Y > (boundary.Down - ball.Size.Height) && num == 2) {
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = true;
                num = 3;
            }

            if (ball.Location.Y < boundary.Up && num == 3) {
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = true;
                Timer5.Enabled = false;
                num = 2;
            }

            if (ball.Intersect(wall2.Rectangle) && num == 0) {
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = true;
                Timer5.Enabled = false;

                if (ball.Speed == 10) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 10) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 10) {

                }
                else {
                    wall2.Speed++;
                }
                num = 2;
            }

            if (ball.Intersect(wall2.Rectangle) && num == 1) {
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = true;

                if (ball.Speed == 10) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 10) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 10) {

                }
                else {
                    wall2.Speed++;
                }
                num = 3;
            }

            if (ball.Intersect(wall1.Rectangle) && num == 2) {
                Timer2.Enabled = true;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = false;

                if (ball.Speed == 10) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 10) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 10) {

                }
                else {
                    wall2.Speed++;
                }
                num = 0;
            }

            if (ball.Intersect(wall1.Rectangle) && num == 3) {
                Timer2.Enabled = false;
                Timer3.Enabled = true;
                Timer4.Enabled = false;
                Timer5.Enabled = false;

                if (ball.Speed == 10) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 10) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 10) {

                }
                else {
                    wall2.Speed++;
                }
                num = 1;
            }

            ball.Move(direction);
        }

        private void Form1_Load(object sender, EventArgs e) {
            var randomDirection = rnd.Next(0, 4);

            if (randomDirection == 0) {
                num = 0;
                Timer2.Enabled = true;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = false;
            }

            if (randomDirection == 1) {
                num = 1;
                Timer2.Enabled = false;
                Timer3.Enabled = true;
                Timer4.Enabled = false;
                Timer5.Enabled = false;
            }

            if (randomDirection == 2) {
                num = 2;
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = true;
                Timer5.Enabled = false;
            }

            if (randomDirection == 3) {
                num = 3;
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = true;
            }

            label1.BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label1.Location = new Point(pbCanvas.Width / 2 - label1.Size.Width + label3.Size.Width * 2, 10);
            label1.Font = new Font("Arial", 20);

            label2.BackColor = Color.Black;
            label2.ForeColor = Color.White;
            label2.Location = new Point(pbCanvas.Width / 2 - label2.Size.Width - label3.Size.Width * 2, 10);
            label2.Font = new Font("Arial", 20);

            label3.BackColor = Color.Black;
            label3.ForeColor = Color.White;
            label3.Location = new Point(pbCanvas.Width / 2 - label3.Size.Width, 10);
            label3.Font = new Font("Arial", 20);
        }
    }
}
