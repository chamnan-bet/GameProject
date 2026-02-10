using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    partial class TicTacToe
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
            this.comboBoxOptions = new System.Windows.Forms.ComboBox();
            this.labelOption = new System.Windows.Forms.Label();
            this.startGame = new System.Windows.Forms.Button();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxOptions
            // 
            this.comboBoxOptions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOptions.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBoxOptions.ForeColor = System.Drawing.Color.Black;
            this.comboBoxOptions.Location = new System.Drawing.Point(157, 21);
            this.comboBoxOptions.Name = "comboBoxOptions";
            this.comboBoxOptions.Size = new System.Drawing.Size(125, 33);
            this.comboBoxOptions.TabIndex = 1;
            // 
            // labelOption
            // 
            this.labelOption.AutoSize = true;
            this.labelOption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelOption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelOption.Location = new System.Drawing.Point(40, 24);
            this.labelOption.Name = "labelOption";
            this.labelOption.Size = new System.Drawing.Size(111, 25);
            this.labelOption.TabIndex = 2;
            this.labelOption.Text = "Play Mode:";
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.startGame.FlatAppearance.BorderSize = 0;
            this.startGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGame.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.startGame.ForeColor = System.Drawing.Color.White;
            this.startGame.Location = new System.Drawing.Point(459, 24);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(130, 40);
            this.startGame.TabIndex = 5;
            this.startGame.Text = "START";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.BackColor = System.Drawing.Color.White;
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Location = new System.Drawing.Point(40, 107);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(820, 640);
            this.panelGrid.TabIndex = 7;
            this.panelGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGrid_Paint);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(730, 24);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 40);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Leelawadee UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStatus.Location = new System.Drawing.Point(41, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 24);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Turn: X";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 820);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.comboBoxOptions);
            this.Controls.Add(this.labelOption);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panelGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tic Tac Toe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label labelOption;
        private System.Windows.Forms.Button startGame;
        internal System.Windows.Forms.ComboBox comboBoxOptions;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Timer timerPlay;
        private System.Windows.Forms.Button btnReset;
        private Label lblStatus;
    }
}

