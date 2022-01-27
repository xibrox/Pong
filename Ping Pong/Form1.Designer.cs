
namespace Ping_Pong {
    partial class Pong {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.Timer3 = new System.Windows.Forms.Timer(this.components);
            this.Timer4 = new System.Windows.Forms.Timer(this.components);
            this.Timer5 = new System.Windows.Forms.Timer(this.components);
            this.GameOver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCanvas.Location = new System.Drawing.Point(0, 0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(800, 450);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // Timer
            // 
            this.Timer.Interval = 10;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 10;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Timer2
            // 
            this.Timer2.Interval = 10;
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Timer3
            // 
            this.Timer3.Interval = 10;
            this.Timer3.Tick += new System.EventHandler(this.Timer3_Tick);
            // 
            // Timer4
            // 
            this.Timer4.Interval = 10;
            this.Timer4.Tick += new System.EventHandler(this.Timer4_Tick);
            // 
            // Timer5
            // 
            this.Timer5.Interval = 10;
            this.Timer5.Tick += new System.EventHandler(this.Timer5_Tick);
            // 
            // GameOver
            // 
            this.GameOver.AutoSize = true;
            this.GameOver.Location = new System.Drawing.Point(398, 219);
            this.GameOver.Name = "GameOver";
            this.GameOver.Size = new System.Drawing.Size(72, 15);
            this.GameOver.TabIndex = 4;
            this.GameOver.Text = "GAME OVER";
            // 
            // Pong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameOver);
            this.Controls.Add(this.pbCanvas);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Pong";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.Timer Timer3;
        private System.Windows.Forms.Timer Timer4;
        private System.Windows.Forms.Timer Timer5;
        private System.Windows.Forms.Label GameOver;
    }
}

