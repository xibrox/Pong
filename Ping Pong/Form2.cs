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

            BackColor = Color.FromArgb(26, 26, 26);
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
            PongLabel.ForeColor = Color.FromArgb(179, 179, 179);
            PongLabel.Font = new Font("Ariel", 80);
            PongLabel.Location = new Point(Size.Width / 2 - PongLabel.Width / 2, Size.Height / 2 - PongLabel.Width - 50);

            versionLabel.ForeColor = Color.FromArgb(179, 179, 179);
            versionLabel.Font = new Font("Ariel", 15);
            versionLabel.Location = new Point(10, Size.Height - versionLabel.Size.Height * 3);
            versionLabel.Text = "v1.1.3";

            Player1.Text = "One Player";
            Player1.ForeColor = Color.FromArgb(179, 179, 179);
            Player1.Location = new Point(Size.Width / 2 - Player1.Width / 2 - 40, Size.Height / 2 + 20 - Player1.Width * 2);
            Player1.Size = new Size(150, 70);
            Player1.Font = new Font("Ariel", 20);
            Player1.FlatStyle = FlatStyle.Flat;
            Player1.FlatAppearance.BorderColor = Color.FromArgb(77, 77, 77);

            Player2.Text = "Two Players";
            Player2.ForeColor = Color.FromArgb(179, 179, 179);
            Player2.Location = new Point(Size.Width / 2 - Player2.Width / 2 - 45, Size.Height / 2);
            Player2.Size = new Size(150, 70);
            Player2.Font = new Font("Ariel", 20);
            Player2.FlatStyle = FlatStyle.Flat;
            Player2.FlatAppearance.BorderColor = Color.FromArgb(77, 77, 77);

            Bitmap bmp = new Bitmap(Player1.Width, Player1.Height);
            using (Graphics g = Graphics.FromImage(bmp)) {
                Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    Color.FromArgb(77, 77, 77),
                                                    Color.FromArgb(31, 31, 31),
                                                    LinearGradientMode.Vertical)) {
                    g.FillRectangle(br, r);
                }
            }

            Player1.BackgroundImage = bmp;
            Player2.BackgroundImage = bmp;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Close();
            }
        }

        private void Player1_MouseEnter(object sender, EventArgs e) {
            Bitmap bmp = new Bitmap(Player1.Width, Player1.Height);
            using (Graphics g = Graphics.FromImage(bmp)) {
                Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    Color.FromArgb(47, 47, 47),
                                                    Color.FromArgb(21, 21, 21),
                                                    LinearGradientMode.Vertical)) {
                    g.FillRectangle(br, r);
                }
            }

            Player1.BackgroundImage = bmp;
        }

        private void Player1_MouseLeave(object sender, EventArgs e) {
            Bitmap bmp = new Bitmap(Player1.Width, Player1.Height);
            using (Graphics g = Graphics.FromImage(bmp)) {
                Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    Color.FromArgb(77, 77, 77),
                                                    Color.FromArgb(31, 31, 31),
                                                    LinearGradientMode.Vertical)) {
                    g.FillRectangle(br, r);
                }
            }

            Player1.BackgroundImage = bmp;
        }

        private void Player2_MouseEnter(object sender, EventArgs e) {
            Bitmap bmp = new Bitmap(Player2.Width, Player2.Height);
            using (Graphics g = Graphics.FromImage(bmp)) {
                Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    Color.FromArgb(47, 47, 47),
                                                    Color.FromArgb(21, 21, 21),
                                                    LinearGradientMode.Vertical)) {
                    g.FillRectangle(br, r);
                }
            }

            Player2.BackgroundImage = bmp;
        }

        private void Player2_MouseLeave(object sender, EventArgs e) {
            Bitmap bmp = new Bitmap(Player2.Width, Player2.Height);
            using (Graphics g = Graphics.FromImage(bmp)) {
                Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    Color.FromArgb(77, 77, 77),
                                                    Color.FromArgb(31, 31, 31),
                                                    LinearGradientMode.Vertical)) {
                    g.FillRectangle(br, r);
                }
            }

            Player2.BackgroundImage = bmp;
        }
    }
}
