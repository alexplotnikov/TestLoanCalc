
namespace LoanCalculator.Services.Models
{
    public class Installment
    {
        public Installment(int installmentNumber, decimal amountDue, decimal principal, decimal interest)
        {
            InstallmentNumber = installmentNumber;
            AmountDue = amountDue;
            Principal = principal;
            Interest = interest;
        }

        public int InstallmentNumber { get; }
        public decimal AmountDue { get; }
        public decimal Principal { get; }
        public decimal Interest { get; }

    }
}
