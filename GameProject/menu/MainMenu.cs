using Car_Racing;
using GameProject.loan;
using GameProject.loan.connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe;

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
            db.TestConnection(); 
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
