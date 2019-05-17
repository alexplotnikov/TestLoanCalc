using System.Collections.Generic;

namespace LoanCalculator.Services.Models
{
    public class RepaymentSchedule
    {
        public RepaymentSchedule()
        {
            Installments = new List<Installment>();
        }

        public ICollection<Installment> Installments { get; }
    }
}
