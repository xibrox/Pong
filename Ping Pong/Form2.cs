using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Ping_Pong {
    public partial class Form2 : Form {
        Pong pg = new Pong();
        public static int Position1S = 1;
        public static int Position1W = 2;
        public static bool Bot = true;

        public Form2() {
            InitializeComponent();
            Init();
        }

        public void Init() {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;

            BackColor = Color.Black;
        }

        private void Player1_Click(object sender, EventArgs e) {
            this.Hide();

            Position1S = 0;
            Position1W = 0;
            Bot = true;

            pg.ShowDialog();

            this.Show();
        }

        private void Player2_Click(object sender, EventArgs e) {
            this.Hide();

            Position1S = 1;
            Position1W = 2;
            Bot = false;

            pg.ShowDialog();

            this.Show();
        }

        private void Form2_Load(object sender, EventArgs e) {
            PongLabel.ForeColor = Color.White;
            PongLabel.Font = new Font("Ariel", 80);
            PongLabel.Location = new Point(Size.Width / 2 - PongLabel.Width / 2, Size.Height / 2 - PongLabel.Width - 50);

            Player1.ForeColor = Color.White;
            Player1.Location = new Point(Size.Width / 2 - Player1.Width / 2 - 40, Size.Height / 2 - Player1.Width * 2);
            Player1.Size = new Size(150, 75);
            Player1.Font = new Font("Ariel", 20);

            Player2.ForeColor = Color.White;
            Player2.Location = new Point(Size.Width / 2 - Player2.Width / 2 - 40, Size.Height / 2);
            Player2.Size = new Size(150, 75);
            Player2.Font = new Font("Ariel", 20);

            Bitmap bmp = new Bitmap(Player1.Width, Player1.Height);
            using (Graphics g = Graphics.FromImage(bmp)) {
                Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    Color.DarkGray,
                                                    Color.Black,
                                                    LinearGradientMode.Vertical)) {
                    g.FillRectangle(br, r);
                }
            }

            Bitmap bmp1 = new Bitmap(PongLabel.Width, PongLabel.Height);
            using (Graphics g = Graphics.FromImage(bmp1)) {
                Rectangle r = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    Color.DarkGray,
                                                    Color.Black,
                                                    LinearGradientMode.Vertical)) {
                    g.FillRectangle(br, r);
                }
            }

            Player1.BackgroundImage = bmp;
            Player2.BackgroundImage = bmp;
            PongLabel.BackgroundImage = bmp1;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Close();
            }
        }
    }
}
