using GameProject.loan.connection;
using GameProject.tictactoe;
using MySql.Data.MySqlClient;
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
        private string selectedCustomerId;
        private decimal _monthlyPayment;
        private decimal _totalPayment;
        private decimal _totalInterest;
        public LoanCalculator()
        {
           
            InitializeComponent();
            LoadCustomers();
            yearsTxt.Text = "0";
            monthsTxt.Text = "0";
        }

        private void calBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedCustomerId))
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            try
            {
                decimal principal = decimal.Parse(loanAmount.Text);
                decimal rate = decimal.Parse(rateTxt.Text);

                int years = string.IsNullOrWhiteSpace(yearsTxt.Text) ? 0 : int.Parse(yearsTxt.Text);
                int months = string.IsNullOrWhiteSpace(monthsTxt.Text) ? 0 : int.Parse(monthsTxt.Text);

                Calculator loan = new Calculator(principal, rate, years, months);

                _monthlyPayment = Math.Round(loan.MonthlyPayment(), 2);
                _totalPayment = Math.Round(loan.TotalPayment(), 2);
                _totalInterest = Math.Round(loan.TotalInterest(), 2);

                txtMonthlyPay.Text = _monthlyPayment.ToString("N2");
                txtTotalPay.Text = _totalPayment.ToString("N2");
                txtTotalInt.Text = _totalInterest.ToString("N2");

                MessageBox.Show(
                    $"Monthly Payment: {_monthlyPayment:C2}\n\n" +
                    $"Total Payment: {_totalPayment:C2}\n" +
                    $"Total Interest: {_totalInterest:C2}",
                    "Loan Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }


        private void dataGridView1_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var cid = dataGridView1.CurrentRow.Cells["CID"].Value;
            selectedCustomerId = cid?.ToString() ?? "";
            txtCID.Text = cid?.ToString() ?? "";

        }

        private void LoadCustomers()
        {
            Database db = new Database();
            using (var conn = db.GetConnection())
            {
                conn.Open(); string query = "SELECT CID, firstname, lastname, gender, currentAddress, status FROM Customer";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                conn.Close();
            }


        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customer = new CustomerForm();
            customer.ShowDialog();
        }

        private void btnSaveLoan_Click(object sender, EventArgs e)
        {

            Database db = new Database();

            using (var conn = db.GetConnection())
            {
                conn.Open();

                string lc = db.gernerateLoanContractId(conn);
                string sql = @"INSERT INTO LoanContract
                                (LC, CID, loanAmount, MonthlyInterest, LoanDate,
                                startPaymentDate, status, scheduleStatus)
                            VALUES
                                (@LC, @CID, @Amount, @Monthly, CURDATE(),
                                CURDATE(), 'Active', 'Not Generated')";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LC", lc);
                cmd.Parameters.AddWithValue("@CID", selectedCustomerId);
                cmd.Parameters.AddWithValue("@Amount", loanAmount.Text);
                cmd.Parameters.AddWithValue("@Monthly",
                    txtMonthlyPay.Text.Replace("$", ""));

                cmd.ExecuteNonQuery();
                GeneratePaymentSchedule(conn, lc);

                MessageBox.Show($"Loan contract {lc} saved successfully for customer {selectedCustomerId}.\n" + 
                    $"Payment schedule has been generated.", 
                    "Success", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information 
                );
            }
        }

        private void GeneratePaymentSchedule(MySqlConnection conn, string lc)
        {
            // Create calculator from current form inputs
            decimal principal = decimal.Parse(loanAmount.Text); 
            decimal annualRate = decimal.Parse(rateTxt.Text); 
            int years = int.Parse(yearsTxt.Text); 
            int months = int.Parse(monthsTxt.Text);

            Calculator calc = new Calculator(principal, annualRate, years, months);

            int totalMonths = calc.TotalMonths(); 
            decimal monthlyRate = calc.MonthlyRate(); 
            decimal monthlyPayment = Math.Round(calc.MonthlyPayment(), 2);

            decimal balance = principal; 
            DateTime dueDate = DateTime.Today.AddMonths(1);


            for (int i = 1; i <= totalMonths; i++)
            {
                decimal interest = Math.Round(balance * monthlyRate, 2);
                decimal principalPart = Math.Round(monthlyPayment - interest, 2); 
                balance = Math.Round(balance - principalPart, 2);


                string sql = @"INSERT INTO PaymentSchedule 
                                (LC, dueDate, monthlyPayment, principal, interest, 
                                service, balance, action) 
                            VALUES 
                                (@LC, @date, @pay, @principal, @interest, 
                                0, @balance, 'Pending')";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                { 
                    cmd.Parameters.AddWithValue("@LC", lc); 
                    cmd.Parameters.AddWithValue("@date", dueDate); 
                    cmd.Parameters.AddWithValue("@pay", monthlyPayment); 
                    cmd.Parameters.AddWithValue("@principal", principalPart); 
                    cmd.Parameters.AddWithValue("@interest", interest); 
                    cmd.Parameters.AddWithValue("@balance", balance); 
                    cmd.ExecuteNonQuery(); 
                }

                dueDate = dueDate.AddMonths(1);
            }
            using (MySqlCommand updateCmd = new MySqlCommand
                ("UPDATE LoanContract SET scheduleStatus='Generated' WHERE LC=@LC", conn)) 
            { 
                updateCmd.Parameters.AddWithValue("@LC", lc); 
                updateCmd.ExecuteNonQuery(); 
            }
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
        

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtMonthlyPay_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalPay_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        
    }
}
