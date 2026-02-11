using GameProject.loan.connection;
using GameProject.loan.models;
using GameProject.loan.repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

public class PaymentScheduleRepository : IPaymentScheduleRepository
{
    private readonly Database _database;

    public PaymentScheduleRepository(Database database)
    {
        _database = database;
    }

    public List<PaymentScheduleDto> GetSchedules(PaymentScheduleFilter filter)
    {
        var list = new List<PaymentScheduleDto>();

        using (SqlConnection conn = _database.GetConnection())
        {
            conn.Open();

            string sql = @"
                SELECT 
                    ps.dueDate,
                    ps.LC,
                    lc.CID,
                    ps.monthlyPayment,
                    ps.principal,
                    ps.interest,
                    ps.service,
                    ps.balance,
                    ps.action
                FROM PaymentSchedule ps
                INNER JOIN LoanContract lc ON ps.LC = lc.LC
                WHERE ps.dueDate BETWEEN @from AND @to";

            if (filter.HasCustomer)
                sql += " AND lc.CID = @CID";

            if (filter.HasLoan)
                sql += " AND ps.LC = @LC";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@from", filter.FromDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", filter.ToDate.ToString("yyyy-MM-dd"));

                if (filter.HasCustomer)
                    cmd.Parameters.AddWithValue("@CID", filter.CID.ToString());

                if (filter.HasLoan)
                    cmd.Parameters.AddWithValue("@LC", filter.LC.ToString());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PaymentScheduleDto
                        {
                            DueDate = reader.GetDateTime(reader.GetOrdinal("dueDate")),
                            LC = reader.GetString(reader.GetOrdinal("LC")),
                            CID = reader.GetString(reader.GetOrdinal("CID")),
                            MonthlyPayment = reader.GetDecimal(reader.GetOrdinal("monthlyPayment")),
                            Principal = reader.GetDecimal(reader.GetOrdinal("principal")),
                            Interest = reader.GetDecimal(reader.GetOrdinal("interest")),
                            Service = reader.GetDecimal(reader.GetOrdinal("service")),
                            Balance = reader.GetDecimal(reader.GetOrdinal("balance")),
                            Action = reader["action"] == DBNull.Value
                                        ? ""
                                        : reader.GetString(reader.GetOrdinal("action"))
                        });
                    }
                }
            }
        }

        return list;
    }
}
