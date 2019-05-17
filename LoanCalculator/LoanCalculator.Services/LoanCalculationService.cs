using LoanCalculator.Services.Models;
using System;

namespace LoanCalculator.Services
{
    // This service is a subject to inject into Controller code with Dependency Injection
    public class LoanCalculationService
    {
        private const int totalPayments = 52; // Number of weekly payments

        #region Public methods

        public LoanSummary GetLoanSummary(decimal amount, int apr)
        {
            ValidateAmount(amount);
            ValidateApr(apr);

            var repayment = Math.Round(GetInstallmentAmount(amount, totalPayments, apr), 0, MidpointRounding.AwayFromZero);
            var totalRepaid = repayment * totalPayments;
            var totalInterest = totalRepaid - amount;

            var loanSummary = new LoanSummary(repayment, totalRepaid, totalInterest);
            return loanSummary;
        }

        public RepaymentSchedule GetRepaymentSchedule(decimal amount, int apr)
        {
            ValidateAmount(amount);
            ValidateApr(apr);

            var currentAmount = amount;
            var interestRate = 0.01m * apr / totalPayments;
            var installmentAmount = GetInstallmentAmount(amount, totalPayments, apr);

            var repaymentSchedule = new RepaymentSchedule();

            for (var installmentNumber = 1; installmentNumber <= totalPayments; installmentNumber++)
            {
                var currentInterest = currentAmount * interestRate;
                var currentPrincipal = installmentAmount - currentInterest;

                var installment = new Installment(
                    installmentNumber,
                    Math.Round(currentAmount, 2, MidpointRounding.AwayFromZero),
                    Math.Round(currentPrincipal, 0, MidpointRounding.AwayFromZero),
                    Math.Round(currentInterest, 0, MidpointRounding.AwayFromZero));
                repaymentSchedule.Installments.Add(installment);

                currentAmount -= currentPrincipal;
            }
            return repaymentSchedule;
        }

        #endregion

        #region Private methods

        private static decimal GetInstallmentAmount(decimal principal, int totalPayments, int apr)
        {
            var interestRate = 0.01m * apr / totalPayments; // r
            return principal * (interestRate / (decimal)(1 - Math.Pow(1 + (double)interestRate, -totalPayments)));
        }

        #endregion

        #region Validation

        private static void ValidateAmount(decimal amount)
        {
            if (amount <= 0m)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero!");
            }
        }

        private static void ValidateApr(int apr)
        {
            if (apr <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(apr), "APR must be greater than zero!");
            }
        }

        #endregion
    }
}
