using Car_Racing;
using GameProject.loan;
using GameProject.loan.connection;
using GameProject.tictactoe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject.manu
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            LoanCalculator loan = new LoanCalculator();
            loan.ShowDialog(); // modal
        }

        private void btnCarRacing_Click(object sender, EventArgs e)
        {
            carRacing car = new carRacing();
            car.ShowDialog();
        }

        private void btnTicTacToe_Click(object sender, EventArgs e)
        {
            TicTacToe tic = new TicTacToe();
            tic.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // returns to LoginForm
        }

        private void btnTestDb_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            //if (db.testConnection(out string msg))
            //{
            //    MessageBox.Show(msg,
            //            "Success",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show(msg,
            //            "Database Error",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //}

            db.testConnection(); 
        }
    }
}
