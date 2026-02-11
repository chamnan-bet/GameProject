using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.loan.models
{
    public class PaymentScheduleFilter
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CID { get; set; }
        public string LC { get; set; }

        public bool HasCustomer => !string.IsNullOrEmpty(CID);
        public bool HasLoan => !string.IsNullOrEmpty(LC);
    }
}
