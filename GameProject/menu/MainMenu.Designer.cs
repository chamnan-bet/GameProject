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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoan
            // 
            this.btnLoan.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoan.Font = new System.Drawing.Font("Leelawadee UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoan.Location = new System.Drawing.Point(572, 152);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(185, 55);
            this.btnLoan.TabIndex = 0;
            this.btnLoan.Text = "Loan Calculator";
            this.btnLoan.UseVisualStyleBackColor = false;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // btnCarRacing
            // 
            this.btnCarRacing.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCarRacing.Font = new System.Drawing.Font("Leelawadee UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarRacing.Location = new System.Drawing.Point(314, 152);
            this.btnCarRacing.Name = "btnCarRacing";
            this.btnCarRacing.Size = new System.Drawing.Size(185, 55);
            this.btnCarRacing.TabIndex = 1;
            this.btnCarRacing.Text = "Car Racing";
            this.btnCarRacing.UseVisualStyleBackColor = false;
            this.btnCarRacing.Click += new System.EventHandler(this.btnCarRacing_Click);
            // 
            // btnTicTacToe
            // 
            this.btnTicTacToe.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTicTacToe.Font = new System.Drawing.Font("Leelawadee UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicTacToe.Location = new System.Drawing.Point(53, 153);
            this.btnTicTacToe.Name = "btnTicTacToe";
            this.btnTicTacToe.Size = new System.Drawing.Size(185, 55);
            this.btnTicTacToe.TabIndex = 2;
            this.btnTicTacToe.Text = "Tic Tac Toe";
            this.btnTicTacToe.UseVisualStyleBackColor = false;
            this.btnTicTacToe.Click += new System.EventHandler(this.btnTicTacToe_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Location = new System.Drawing.Point(678, 399);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(99, 39);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnTestDb
            // 
            this.btnTestDb.Location = new System.Drawing.Point(314, 284);
            this.btnTestDb.Name = "btnTestDb";
            this.btnTestDb.Size = new System.Drawing.Size(185, 55);
            this.btnTestDb.TabIndex = 4;
            this.btnTestDb.Text = "Test DB connection";
            this.btnTestDb.UseVisualStyleBackColor = true;
            this.btnTestDb.Click += new System.EventHandler(this.btnTestDb_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumBlue;
            this.button1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(227, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(375, 55);
            this.button1.TabIndex = 5;
            this.button1.Text = "Welcome to OOP Projects";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTestDb);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnTicTacToe);
            this.Controls.Add(this.btnCarRacing);
            this.Controls.Add(this.btnLoan);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Button btnCarRacing;
        private System.Windows.Forms.Button btnTicTacToe;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnTestDb;
        private System.Windows.Forms.Button button1;
    }
}