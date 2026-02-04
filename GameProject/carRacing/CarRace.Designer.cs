namespace GameProject
{
    partial class CarRace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.middleLine1 = new System.Windows.Forms.PictureBox();
            this.middleLine2 = new System.Windows.Forms.PictureBox();
            this.middleLine3 = new System.Windows.Forms.PictureBox();
            this.middleLine4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.middleLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // middleLine1
            // 
            this.middleLine1.BackColor = System.Drawing.SystemColors.Control;
            this.middleLine1.Location = new System.Drawing.Point(371, 583);
            this.middleLine1.Name = "middleLine1";
            this.middleLine1.Size = new System.Drawing.Size(20, 153);
            this.middleLine1.TabIndex = 0;
            this.middleLine1.TabStop = false;
            // 
            // middleLine2
            // 
            this.middleLine2.BackColor = System.Drawing.SystemColors.Control;
            this.middleLine2.Location = new System.Drawing.Point(371, 386);
            this.middleLine2.Name = "middleLine2";
            this.middleLine2.Size = new System.Drawing.Size(20, 153);
            this.middleLine2.TabIndex = 1;
            this.middleLine2.TabStop = false;
            // 
            // middleLine3
            // 
            this.middleLine3.BackColor = System.Drawing.SystemColors.Control;
            this.middleLine3.Location = new System.Drawing.Point(371, 186);
            this.middleLine3.Name = "middleLine3";
            this.middleLine3.Size = new System.Drawing.Size(20, 153);
            this.middleLine3.TabIndex = 2;
            this.middleLine3.TabStop = false;
            // 
            // middleLine4
            // 
            this.middleLine4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.middleLine4.Location = new System.Drawing.Point(371, -7);
            this.middleLine4.Name = "middleLine4";
            this.middleLine4.Size = new System.Drawing.Size(20, 153);
            this.middleLine4.TabIndex = 3;
            this.middleLine4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(12, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 765);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.Location = new System.Drawing.Point(768, -7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 765);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CarRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 748);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.middleLine4);
            this.Controls.Add(this.middleLine3);
            this.Controls.Add(this.middleLine2);
            this.Controls.Add(this.middleLine1);
            this.Name = "CarRace";
            this.Text = "CarRace";
            ((System.ComponentModel.ISupportInitialize)(this.middleLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox middleLine1;
        private System.Windows.Forms.PictureBox middleLine2;
        private System.Windows.Forms.PictureBox middleLine3;
        private System.Windows.Forms.PictureBox middleLine4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer;
    }
}