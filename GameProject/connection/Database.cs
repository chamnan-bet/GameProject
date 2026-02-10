using GameProject.connection;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GameProject.loan.connection
{
    public class Database : IDatabaseService
    {
        private string connectionString;

        public Database()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["LoanDB"]
                .ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection(connectionString);
            }
            catch (ConfigurationErrorsException)
            {
                throw new ApplicationException("Database configuration is invalid.");
            }
        }

        public string GenerateCustomerId(SqlConnection connection)
        {
            string sql = "SELECT TOP 1 CID FROM Customer ORDER BY CID DESC";

            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    return "C00001";
                }

                string lastCId = result.ToString();
                int number = int.Parse(lastCId.Substring(1));
                number++;

                return "C" + number.ToString("D5");
            }
        }

        public string GenerateLoanContractId(SqlConnection connection)
        {
            string sql = "SELECT TOP 1 LC FROM LoanContract ORDER BY LC DESC";

            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    return "LC00001";
                }

                string lastLC = result.ToString();
                int number = int.Parse(lastLC.Substring(2));
                number++;

                return "LC" + number.ToString("D3");
            }
        }

        public bool ValidateLogin(string username, string password)
        {
            string sql = @"SELECT COUNT(*) 
                   FROM Users 
                   WHERE Username = @username 
                     AND PasswordHash = @password
                     AND Status = 'Active'";

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


        public void TestConnection()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("SQL Server connection successful!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex.Message);
                }
            }
        }
    }
}
