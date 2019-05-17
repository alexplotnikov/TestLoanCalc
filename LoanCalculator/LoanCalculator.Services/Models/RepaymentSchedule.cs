using System.Collections.Generic;

namespace LoanCalculator.Services.Models
{
    public class RepaymentSchedule
    {
        public RepaymentSchedule()
        {
            Installments = new List<Installment>();
        }

        public RepaymentSchedule(ICollection<Installment> installments)
        {
            Installments = installments;
        }

        public ICollection<Installment> Installments { get; }
    }
}
