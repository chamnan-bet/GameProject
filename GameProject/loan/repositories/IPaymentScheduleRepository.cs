using GameProject.loan.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.loan.repositories
{
    public interface IPaymentScheduleRepository
    {
        List<PaymentScheduleDto> GetSchedules(PaymentScheduleFilter filter);
    }
}
