using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace GameProject.loan.connection
{
    public class Database
    {
        private string connectionString;

        public Database()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LoanDB"].ConnectionString;
        }

        public MySqlConnection GetConnection() 
        { 
            return new MySqlConnection(connectionString); 
        }

        public void testConnection()
        {

            //try
            //{
            //    using (MySqlConnection conn = getConnection())
            //    {
            //        conn.Open();

            //        // Real test — MySQL responds
            //        using (MySqlCommand cmd = new MySqlCommand("SELECT 1", conn))
            //        {
            //            cmd.ExecuteScalar();
            //        }

            //        message = "Database connection successful!";
            //        return true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    message = ex.Message;
            //    return false;
            //}


            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Connection successfully!"); 
                }
                catch (Exception e)
                {
                    MessageBox.Show("Connection failed: " + e.Message);
                    
                }
            }
        }
    }
}
