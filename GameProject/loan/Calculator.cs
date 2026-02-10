using GameProject.loan.connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject.loan
{
    internal class Calculator : LoanCalculationBase
    {
        public Calculator(decimal principal, decimal rate, int years, int months)
        {
            Principal = principal;
            AnnualRate = rate;
            Years = years;
            Months = months;
        }

        public int TotalMonths() => (Years * 12) + Months;

        public decimal MonthlyRate() => (AnnualRate / 100m) / 12m;

        public override decimal MonthlyPayment()
        {
            int n = TotalMonths();
            if (n == 0) throw new DivideByZeroException();

            decimal r = MonthlyRate();
            decimal pow = (decimal)Math.Pow((double)(1 + r), n);
            return Principal * r * pow / (pow - 1);
        }

        public override decimal TotalPayment() =>
            MonthlyPayment() * TotalMonths();

        public override decimal TotalInterest() =>
            TotalPayment() - Principal;
    }

}
