namespace GameProject.loan
{
    partial class LoanCalculator
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
            this.label1 = new System.Windows.Forms.Label();
            this.bg = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loanAmount = new System.Windows.Forms.TextBox();
            this.yearsTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rateTxt = new System.Windows.Forms.TextBox();
            this.calBtn = new System.Windows.Forms.Button();
            this.monthsTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loan Calculator";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bg
            // 
            this.bg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bg.Location = new System.Drawing.Point(46, 105);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(541, 333);
            this.bg.TabIndex = 1;
            this.bg.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loan Amount($)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loan Term";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // loanAmount
            // 
            this.loanAmount.Location = new System.Drawing.Point(222, 137);
            this.loanAmount.Name = "loanAmount";
            this.loanAmount.Size = new System.Drawing.Size(284, 22);
            this.loanAmount.TabIndex = 4;
            this.loanAmount.TextChanged += new System.EventHandler(this.loanAmount_TextChanged);
            // 
            // yearsTxt
            // 
            this.yearsTxt.Location = new System.Drawing.Point(222, 176);
            this.yearsTxt.Name = "yearsTxt";
            this.yearsTxt.Size = new System.Drawing.Size(81, 22);
            this.yearsTxt.TabIndex = 5;
            this.yearsTxt.TextChanged += new System.EventHandler(this.year_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Interest rate";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // rateTxt
            // 
            this.rateTxt.Location = new System.Drawing.Point(222, 216);
            this.rateTxt.Name = "rateTxt";
            this.rateTxt.Size = new System.Drawing.Size(284, 22);
            this.rateTxt.TabIndex = 7;
            this.rateTxt.TextChanged += new System.EventHandler(this.rate_TextChanged);
            // 
            // calBtn
            // 
            this.calBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.calBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calBtn.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.calBtn.Location = new System.Drawing.Point(117, 294);
            this.calBtn.Name = "calBtn";
            this.calBtn.Size = new System.Drawing.Size(264, 62);
            this.calBtn.TabIndex = 8;
            this.calBtn.Text = "Calculate";
            this.calBtn.UseVisualStyleBackColor = false;
            this.calBtn.Click += new System.EventHandler(this.calBtn_Click);
            // 
            // monthsTxt
            // 
            this.monthsTxt.Location = new System.Drawing.Point(361, 176);
            this.monthsTxt.Name = "monthsTxt";
            this.monthsTxt.Size = new System.Drawing.Size(81, 22);
            this.monthsTxt.TabIndex = 9;
            this.monthsTxt.TextChanged += new System.EventHandler(this.month_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(309, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Years";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(448, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Months";
            // 
            // LoanCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(751, 666);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.monthsTxt);
            this.Controls.Add(this.calBtn);
            this.Controls.Add(this.rateTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yearsTxt);
            this.Controls.Add(this.loanAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bg);
            this.Controls.Add(this.label1);
            this.Name = "LoanCalculator";
            this.Text = "LoanCalculator";
            ((System.ComponentModel.ISupportInitialize)(this.bg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox loanAmount;
        private System.Windows.Forms.TextBox yearsTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rateTxt;
        private System.Windows.Forms.Button calBtn;
        private System.Windows.Forms.TextBox monthsTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}