using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_Pong {
    public partial class Pong : Form {
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
            W, S, Null, Space
        }

        private int position1R = 0;

        private Position position;
        private Position1 position1;

        public Pong() {
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

            this.pbCanvas.BackColor = Color.FromArgb(0, 0, 0);
            this.pbCanvas.Size = this.Size;
            this.pbCanvas.Bounds = this.Bounds;
        }

        //Spawning Ball

        public void SetBall() {
            var size = new Size(50, 50);
            var location = new Point((pbCanvas.Width / 2) - size.Width / 2, (pbCanvas.Height / 2) - size.Height);

            ball = new Ball(Brushes.White, size, location, 5);
        }

        //Spawning Wall1

        public void SetWall1() {
            var size = new Size(50, 200);
            var location = new Point(50, (pbCanvas.Height / 2) - size.Height / 2);

            wall1 = new Wall(Brushes.White, size, location, 3);
        }

        //Spawning Wall2

        public void SetWall2() {
            var size = new Size(50, 200);
            var location = new Point(pbCanvas.Width - 50 - size.Width, (pbCanvas.Height / 2) - size.Height / 2);

            wall2 = new Wall(Brushes.White, size, location, 3);
        }

        //Start Game Method

        private void StartGame() {
            Timer.Enabled = true;
            Timer1.Enabled = true;

            var randomDirection = rnd.Next(0, 4);

            if (Timer.Enabled == true && Timer1.Enabled == true && Timer2.Enabled == false && Timer3.Enabled == false && Timer4.Enabled == false && Timer5.Enabled == false) {
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
            }
        }

        //Game Over Method

        private void EndGame() {
            var randomDirection = rnd.Next(0, 4);

            if (GameOver.Visible == true) {
                GameOver.Visible = false;

                wall1Score = 0;
                wall2Score = 0;

                Timer.Enabled = true;
                Timer1.Enabled = true;

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
            }
        }

        //Drawing on Canvas

        private void pbCanvas_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;

            ball.Draw(g);

            wall1.Draw(g);

            wall2.Draw(g);

            g.DrawString(":", new Font("Arial", 30), Brushes.White, new Point(pbCanvas.Width / 2 - 4, 15));
            g.DrawString("" + wall1Score, new Font("Arial", 40), Brushes.White, new Point(pbCanvas.Width / 2 + 11, 10));
            g.DrawString("" + wall2Score, new Font("Arial", 40), Brushes.White, new Point(pbCanvas.Width / 2 - 10 * 4, 10));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }

            if (Keys.Space == e.KeyCode) {
                position1 = Position1.Space;
                StartGame();

                EndGame();
            }

            if (Keys.W == e.KeyCode) {
                position1R = Form2.Position1W;
            }

            if (Keys.S == e.KeyCode) {
                position1R = Form2.Position1S;
            }

            if (Keys.Up == e.KeyCode) {
                position = Position.Up;
            }

            if (Keys.Down == e.KeyCode) {
                position = Position.Down;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {

            if (Keys.W == e.KeyCode) {
                position1R = 0;
            }

            if (Keys.S == e.KeyCode) {
                position1R = 0;
            }


            if (Keys.Up == e.KeyCode) {
                position = Position.Null;
            }

            if (Keys.Down == e.KeyCode) {
                position = Position.Null;
            }
        }

        //Player1 on left Movement

        private void Timer_Tick(object sender, EventArgs e) {
            var direction = new Point();

            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, 0, pbCanvas.Size.Height);

            if (position1R == Form2.Position1W && wall1.Location.Y > boundary.Up) {
                direction.Y--;
            }

            if (position1R == Form2.Position1S && wall1.Location.Y < (boundary.Down - wall2.Size.Height)) {
                direction.Y++;
            }

            if (position1 == Position1.Space && Form2.Bot == true && wall1.Location.Y + wall1.Size.Height / 2 > ball.Location.Y && wall1.Location.Y > boundary.Up) {
                direction.Y--;
            }

            if (position1 == Position1.Space && Form2.Bot == true && wall1.Location.Y + wall1.Size.Height / 2 < ball.Location.Y && wall1.Location.Y < (boundary.Down - wall2.Size.Height)) {
                direction.Y++;
            }

            wall1.Move(direction);

            this.pbCanvas.Refresh();
        }

        //Player2 on right Movement

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

        //Right
        //Down

        private void Timer2_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.X++;
            direction.Y++;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Right
        //Up

        private void Timer3_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.X++;
            direction.Y--;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Left
        //Down

        private void Timer4_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.X--;
            direction.Y++;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Left
        //Up

        private void Timer5_Tick(object sender, EventArgs e) {
            var direction = new Point();

            direction.X--;
            direction.Y--;

            ball.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Score for Player1

        private void ScoreWall1() {
            wall1Score++;
        }

        //Score for Player2

        private void ScoreWall2() {
            wall2Score++;
        }

        private void HandleCollision() {
            var direction = new Point();

            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, 0, pbCanvas.Size.Height);
            
            var wall1Boun = new Wall(Brushes.White, new Size(1, wall1.Size.Height - 2), new Point(wall1.Location.X + wall1.Size.Width - 1, wall1.Location.Y + 1), 5);
            var wall2Boun = new Wall(Brushes.White, new Size(1, wall2.Size.Height - 2), new Point(wall2.Location.X, wall2.Location.Y + 1), 5);

            var wall1BounTop = new Wall(Brushes.White, new Size(wall1.Size.Width, 1), new Point(wall1.Location.X, wall1.Location.Y - 1), 5);
            var wall2BounTop = new Wall(Brushes.White, new Size(wall1.Size.Width, 1), new Point(wall2.Location.X, wall2.Location.Y - 1), 5);

            var wall1BounBot = new Wall(Brushes.White, new Size(wall1.Size.Width, 1), new Point(wall1.Location.X, wall1.Size.Height + 1), 5);
            var wall2BounBot = new Wall(Brushes.White, new Size(wall1.Size.Width, 1), new Point(wall2.Location.X, wall2.Size.Height + 1), 5);

            if (ball.Location.X > boundary.Right) {
                ScoreWall2();
                SetBall();

                wall1.Speed = 3;
                wall2.Speed = 3;
                ball.Speed = 5;

                if (wall2Score == 5) {
                    GameOver.Text = "         Player 1 Won\nPress Space to Continue";
                    GameOver.Visible = true;
                    Timer.Enabled = false;
                    Timer1.Enabled = false;
                    Timer2.Enabled = false;
                    Timer3.Enabled = false;
                    Timer4.Enabled = false;
                    Timer5.Enabled = false;
                    SetWall1();
                    SetWall2();
                }
            }

            if (ball.Location.X < (boundary.Left - ball.Size.Width)) {
                ScoreWall1();
                SetBall();

                wall1.Speed = 3;
                wall2.Speed = 3;
                ball.Speed = 5;

                if (wall1Score == 5) {
                    GameOver.Text = "         Player 2 Won\nPress Space to Continue";
                    GameOver.Visible = true;
                    Timer.Enabled = false;
                    Timer1.Enabled = false;
                    Timer2.Enabled = false;
                    Timer3.Enabled = false;
                    Timer4.Enabled = false;
                    Timer5.Enabled = false;
                    SetWall1();
                    SetWall2();
                }
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

            if (ball.Intersect(wall2Boun.Rectangle) && num == 0) {
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = true;
                Timer5.Enabled = false;

                if (ball.Speed == 25) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 23) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 23) {

                }
                else {
                    wall2.Speed++;
                }
                num = 2;
            }

            if (ball.Intersect(wall2Boun.Rectangle) && num == 1) {
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = true;

                if (ball.Speed == 25) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 23) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 23) {

                }
                else {
                    wall2.Speed++;
                }
                num = 3;
            }

            if (ball.Intersect(wall2BounTop.Rectangle) && num == 0) {
                Timer2.Enabled = false;
                Timer3.Enabled = true;
                Timer4.Enabled = false;
                Timer5.Enabled = false;

                if (ball.Speed == 25) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 23) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 23) {

                }
                else {
                    wall2.Speed++;
                }
                num = 1;
            }

            if (ball.Intersect(wall2BounBot.Rectangle) && num == 1) {
                Timer2.Enabled = true;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = false;

                if (ball.Speed == 25) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 23) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 23) {

                }
                else {
                    wall2.Speed++;
                }
                num = 0;
            }

            if (ball.Intersect(wall1Boun.Rectangle)&& num == 2) {
                Timer2.Enabled = true;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = false;

                if (ball.Speed == 20) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 20) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 20) {

                }
                else {
                    wall2.Speed++;
                }
                num = 0;
            }

            if (ball.Intersect(wall1Boun.Rectangle) && num == 3) {
                Timer2.Enabled = false;
                Timer3.Enabled = true;
                Timer4.Enabled = false;
                Timer5.Enabled = false;

                if (ball.Speed == 20) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 20) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 20) {

                }
                else {
                    wall2.Speed++;
                }
                num = 1;
            }

            if (ball.Intersect(wall1BounTop.Rectangle) && num == 2) {
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = true;

                if (ball.Speed == 20) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 20) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 20) {

                }
                else {
                    wall2.Speed++;
                }
                num = 3;
            }

            if (ball.Intersect(wall1BounBot.Rectangle) && num == 3) {
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = true;
                Timer5.Enabled = false;

                if (ball.Speed == 20) {

                }
                else {
                    ball.Speed++;
                }

                if (wall1.Speed == 20) {

                }
                else {
                    wall1.Speed++;
                }

                if (wall2.Speed == 20) {

                }
                else {
                    wall2.Speed++;
                }
                num = 2;
            }

            ball.Move(direction);
        }

        private void Form1_Load(object sender, EventArgs e) {
            GameOver.BackColor = Color.Black;
            GameOver.ForeColor = Color.White;
            GameOver.Location = new Point(pbCanvas.Width / 2 - GameOver.Size.Width * 5, pbCanvas.Height / 2 - GameOver.Size.Height * 8);
            GameOver.Font = new Font("Arial", 50);
            GameOver.Visible = false;

            if (this.Visible == false) {
                SetWall1();
                SetWall2();
                SetBall();

                position = Position.Null;
                position1 = Position1.Null;

                wall1Score = 0;
                wall2Score = 0;

                Timer.Enabled = false;
                Timer1.Enabled = false;
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                Timer5.Enabled = false;
            }
        }

    }
}
