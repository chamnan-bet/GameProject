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
        public double Principal { get; set; }      // P
        public double AnnualRate { get; set; }     // r (percent)
        public int Years { get; set; }             // n
        public int Months { get; set; }

        public Calculator(double principal, double annualRate, int years, int months)
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

        public double MonthlyRate()
        {
            return (AnnualRate / 100.0) / 12.0;
        }

        public double MonthlyPayment()
        {
            double r = MonthlyRate();
            int n = TotalMonths();

            double pow = Math.Pow(1 + r, n);

            return Principal * r * pow / (pow - 1);
        }

        public double TotalPayment()
        {
            return MonthlyPayment() * TotalMonths();
        }

        public double TotalInterest()
        {
            return TotalPayment() - Principal;
        }

        
    }
}
