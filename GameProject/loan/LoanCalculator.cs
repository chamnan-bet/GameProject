using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject.loan
{
    public partial class LoanCalculator : Form
    {
        public LoanCalculator()
        {
           
            InitializeComponent();

            yearsTxt.Text = "0";
            monthsTxt.Text = "0";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void loanAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void rate_TextChanged(object sender, EventArgs e)
        {

        }
        private void year_TextChanged(object sender, EventArgs e)
        {

        }

        private void month_TextChanged(object sender, EventArgs e)
        {

        }
        private void calBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double principal = double.Parse(loanAmount.Text);
                double rate = double.Parse(rateTxt.Text);

                int years = string.IsNullOrEmpty(yearsTxt.Text) ? 0 : int.Parse(yearsTxt.Text);
                int months = string.IsNullOrEmpty(monthsTxt.Text) ? 0 : int.Parse(monthsTxt.Text);

                Calculator loan = new Calculator(principal, rate, years, months);

                double monthly = Math.Round(loan.MonthlyPayment(), 2);
                double totalPay = Math.Round(loan.TotalPayment(), 2);
                double interest = Math.Round(loan.TotalInterest(), 2);

                MessageBox.Show(
                    $"Monthly Payment: ${monthly}\n\n" +
                    $"Total Payment: ${totalPay}\n" +
                    $"Total Interest: ${interest}"
                );
            }
            catch
            {
                MessageBox.Show("Please enter valid numbers.");
            }

        }


    }
}
