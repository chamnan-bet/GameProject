using GameProject.connection;
using GameProject.loan.connection;
using System;
using System.Data;
using System.Data.SqlClient;
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
            }
            catch
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
            finally
            {
                btnSaveLoan.Enabled = true;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Get CID from the "CID" column of the selected row
                selectedCustomerId = dataGridView1.CurrentRow.Cells["CID"].Value.ToString();
                txtCID.Text = selectedCustomerId;
            }
        }

        private void LoadCustomers()
        {
            IDatabaseService db = new Database();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"SELECT CID, firstname, lastname, gender, 
                                 currentAddress, status 
                                 FROM Customer";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            new CustomerForm().ShowDialog();
            LoadCustomers(); // refresh after add
        }

        private void btnSaveLoan_Click(object sender, EventArgs e)
        {
            IDatabaseService db = new Database();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string lc = db.GenerateLoanContractId(conn);

                string sql = @"
                    INSERT INTO LoanContract
                    (LC, CID, loanAmount, MonthlyInterest, LoanDate,
                     startPaymentDate, status, scheduleStatus)
                    VALUES
                    (@LC, @CID, @Amount, @Monthly, GETDATE(),
                     GETDATE(), 'Active', 'Not Generated')
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@LC", lc);
                    cmd.Parameters.AddWithValue("@CID", selectedCustomerId);
                    cmd.Parameters.AddWithValue("@Amount", decimal.Parse(loanAmount.Text));
                    cmd.Parameters.AddWithValue("@Monthly", _monthlyPayment);

                    cmd.ExecuteNonQuery();
                }

                GeneratePaymentSchedule(conn, lc);

                MessageBox.Show(
                    $"Loan contract {lc} saved successfully.\nPayment schedule generated.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void GeneratePaymentSchedule(SqlConnection conn, string lc)
        {
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

                string sql = @"
                    INSERT INTO PaymentSchedule
                    (LC, dueDate, monthlyPayment, principal, interest,
                     service, balance, action)
                    VALUES
                    (@LC, @date, @pay, @principal, @interest,
                     0, @balance, 'Pending')
                ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
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

            using (SqlCommand updateCmd = new SqlCommand(
                "UPDATE LoanContract SET scheduleStatus='Generated' WHERE LC=@LC", conn))
            {
                updateCmd.Parameters.AddWithValue("@LC", lc);
                updateCmd.ExecuteNonQuery();
            }
        } 
    }
}
