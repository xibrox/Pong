
namespace Ping_Pong {
    partial class Form2 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Player1 = new System.Windows.Forms.Button();
            this.Player2 = new System.Windows.Forms.Button();
            this.PongLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Location = new System.Drawing.Point(369, 157);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(75, 25);
            this.Player1.TabIndex = 0;
            this.Player1.Text = "Player1";
            this.Player1.UseVisualStyleBackColor = true;
            this.Player1.Click += new System.EventHandler(this.Player1_Click);
            this.Player1.MouseEnter += new System.EventHandler(this.Player1_MouseEnter);
            this.Player1.MouseLeave += new System.EventHandler(this.Player1_MouseLeave);
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Location = new System.Drawing.Point(369, 228);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(75, 25);
            this.Player2.TabIndex = 1;
            this.Player2.Text = "Player2";
            this.Player2.UseVisualStyleBackColor = true;
            this.Player2.Click += new System.EventHandler(this.Player2_Click);
            this.Player2.MouseEnter += new System.EventHandler(this.Player2_MouseEnter);
            this.Player2.MouseLeave += new System.EventHandler(this.Player2_MouseLeave);
            // 
            // PongLabel
            // 
            this.PongLabel.AutoSize = true;
            this.PongLabel.Location = new System.Drawing.Point(369, 81);
            this.PongLabel.Name = "PongLabel";
            this.PongLabel.Size = new System.Drawing.Size(35, 15);
            this.PongLabel.TabIndex = 2;
            this.PongLabel.Text = "Pong";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(13, 423);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(73, 15);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.Text = "versionLabel";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.PongLabel);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Player1;
        private System.Windows.Forms.Button Player2;
        private System.Windows.Forms.Label PongLabel;
        private System.Windows.Forms.Label versionLabel;
    }
}