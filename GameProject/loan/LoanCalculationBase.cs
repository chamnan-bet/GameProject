using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.loan
{
    public abstract class LoanCalculationBase
    {
        public decimal Principal { get; protected set; }
        public decimal AnnualRate { get; protected set; }
        public int Years { get; protected set; }
        public int Months { get; protected set; }

        public abstract decimal MonthlyPayment();
        public abstract decimal TotalPayment();
        public abstract decimal TotalInterest();
    }
}
