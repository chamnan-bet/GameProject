using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.loan.models
{
    public class PaymentScheduleDto
    {
        public DateTime DueDate { get; set; }
        public string LC { get; set; }
        public string CID { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Service { get; set; }
        public decimal Balance { get; set; }
        public string Action { get; set; }
    }
}
