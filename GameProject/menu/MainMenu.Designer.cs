namespace GameProject.manu
{
    partial class MainMenu
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
            this.btnLoan = new System.Windows.Forms.Button();
            this.btnCarRacing = new System.Windows.Forms.Button();
            this.btnTicTacToe = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnTestDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoan
            // 
            this.btnLoan.Location = new System.Drawing.Point(62, 49);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(185, 55);
            this.btnLoan.TabIndex = 0;
            this.btnLoan.Text = "Loan Calculator";
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnCarRacing
            // 
            this.btnCarRacing.Location = new System.Drawing.Point(62, 130);
            this.btnCarRacing.Name = "btnCarRacing";
            this.btnCarRacing.Size = new System.Drawing.Size(185, 55);
            this.btnCarRacing.TabIndex = 1;
            this.btnCarRacing.Text = "Car Racing";
            this.btnCarRacing.UseVisualStyleBackColor = true;
            this.btnCarRacing.Click += new System.EventHandler(this.btnCarRacing_Click);
            // 
            // btnTicTacToe
            // 
            this.btnTicTacToe.Location = new System.Drawing.Point(62, 212);
            this.btnTicTacToe.Name = "btnTicTacToe";
            this.btnTicTacToe.Size = new System.Drawing.Size(185, 55);
            this.btnTicTacToe.TabIndex = 2;
            this.btnTicTacToe.Text = "Tic Tac Toe";
            this.btnTicTacToe.UseVisualStyleBackColor = true;
            this.btnTicTacToe.Click += new System.EventHandler(this.btnTicTacToe_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Location = new System.Drawing.Point(62, 307);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(185, 55);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnTestDb
            // 
            this.btnTestDb.Location = new System.Drawing.Point(282, 49);
            this.btnTestDb.Name = "btnTestDb";
            this.btnTestDb.Size = new System.Drawing.Size(185, 55);
            this.btnTestDb.TabIndex = 4;
            this.btnTestDb.Text = "Test DB connection";
            this.btnTestDb.UseVisualStyleBackColor = true;
            this.btnTestDb.Click += new System.EventHandler(this.btnTestDb_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTestDb);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnTicTacToe);
            this.Controls.Add(this.btnCarRacing);
            this.Controls.Add(this.btnLoan);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button btnCarRacing;
        private System.Windows.Forms.Button btnTicTacToe;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnTestDb;
    }
}