
namespace LoanCalculator.Services.Models
{
    public class LoanSummary
    {
        public LoanSummary(decimal weeklyRepayment, decimal totalRepaid, decimal totalInterest)
        {
            WeeklyRepayment = weeklyRepayment;
            TotalRepaid = totalRepaid;
            TotalInterest = totalInterest;
        }

        public decimal WeeklyRepayment { get; }
        public decimal TotalRepaid { get; }
        public decimal TotalInterest { get; }
    }
}
