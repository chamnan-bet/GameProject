using GameProject.loan.models;
using GameProject.loan.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.loan.services
{
    public class PaymentScheduleService
    {
        private readonly IPaymentScheduleRepository _repository;

        public PaymentScheduleService(IPaymentScheduleRepository repository)
        {
            _repository = repository;
        }

        public List<PaymentScheduleDto> GetFilteredSchedules(PaymentScheduleFilter filter)
        {
            // You can add business rules here later
            return _repository.GetSchedules(filter);
        }
    }
}
