using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.connection
{
    internal interface IDatabaseService
    {
        SqlConnection GetConnection();
        string GenerateCustomerId(SqlConnection conn);
        string GenerateLoanContractId(SqlConnection conn);
    }
}
