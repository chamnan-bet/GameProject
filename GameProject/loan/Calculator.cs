using GameProject.loan.connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject.loan
{
    internal class Calculator
    {
        public decimal Principal { get; set; }
        public decimal AnnualRate { get; set; }
        public int Years { get; set; }
        public int Months { get; set; }

        public Calculator(decimal principal, decimal annualRate, int years, int months)
        {
            Principal = principal;
            AnnualRate = annualRate;
            Years = years;
            Months = months;
        }

        public int TotalMonths()
        {
            return (Years * 12) + Months;
        }

        public decimal MonthlyRate()
        {
            return (AnnualRate / 100m) / 12m;
        }

        public decimal MonthlyPayment()
        {
            decimal r = MonthlyRate();
            int n = TotalMonths();

            decimal pow = (decimal)Math.Pow((double)(1 + r), n);

            return Principal * r * pow / (pow - 1);
        }

        public decimal TotalPayment()
        {
            return MonthlyPayment() * TotalMonths();
        }

        public decimal TotalInterest()
        {
            return TotalPayment() - Principal;
        }
    }

}
