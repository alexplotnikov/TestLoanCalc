using LoanCalculator.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Services
{
    // This service is a subject to inject into Controller code with Dependency Injection
    public class LoanCalculationService
    {
        #region Public methods

        public LoanSummary GetLoanSummary(decimal amount, int apr)
        {
            ValidateAmount(amount);
            ValidateApr(apr);

            return new LoanSummary(0, 0, 0);
        }

        public RepaymentSchedule GetRepaymentSchedule(decimal amount, int apr)
        {
            ValidateAmount(amount);
            ValidateApr(apr);

            return new RepaymentSchedule();
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
