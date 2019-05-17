using LoanCalculator.Services;
using LoanCalculator.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LoanCalculator.Tests.Controllers
{
    [TestClass]
    public class LoanCalculatorServiceTest
    {
        #region GetLoanSummary tests

        [TestMethod]
        public void GetLoanSummary_WeeklyRepaymentIsCorrect()
        {
            LoanCalculationService service = new LoanCalculationService();
            LoanSummary result = service.GetLoanSummary(50000m, 19);
            Assert.AreEqual(result.WeeklyRepayment, 1058.0m);
        }

        [TestMethod]
        public void GetLoanSummary_TotalRepaidIsCorrect()
        {
            LoanCalculationService service = new LoanCalculationService();
            LoanSummary result = service.GetLoanSummary(50000m, 19);
            Assert.AreEqual(result.TotalRepaid, 55016.0m);
        }

        [TestMethod]
        public void GetLoanSummary_TotalInterestIsCorrect()
        {
            LoanCalculationService service = new LoanCalculationService();
            LoanSummary result = service.GetLoanSummary(50000m, 19);
            Assert.AreEqual(result.TotalInterest, 5016.0m);
        }

        #endregion

        #region GetRepaymentSchedule tests

        [TestMethod]
        public void GetRepaymentSchedule_ReturnsCorrectValueNumber()
        {
            LoanCalculationService service = new LoanCalculationService();
            RepaymentSchedule result = service.GetRepaymentSchedule(50000m, 19);
            Assert.AreEqual(result.Installments.Count, 52);
        }

        [DataRow(1, 50000, 875, 183)]
        [DataRow(2, 49125.17, 878, 179)]
        [DataRow(10, 42010.44, 904, 153)]
        [DataRow(26, 27142.80, 958, 99)]
        [DataRow(52, 1053.68, 1054, 4)]
        [DataTestMethod]
        public void GetRepaymentSchedule_ReturnsCorrectValues(
            int installmentNumber,
            double amountDue,
            double principal,
            double interest)
        {
            LoanCalculationService service = new LoanCalculationService();
            RepaymentSchedule result = service.GetRepaymentSchedule(50000m, 19);

            var installments = new List<Installment>();
            installments.AddRange(result.Installments);

            Assert.IsTrue(
                InstallmentHasValues(
                    installments[installmentNumber - 1],
                    installmentNumber,
                    (decimal)amountDue,
                    (decimal)principal,
                    (decimal)interest));
        }

        #endregion

        #region Private methods

        private static bool InstallmentHasValues(
            Installment installment,
            int installmentNumber,
            decimal amountDue,
            decimal principal,
            decimal interest)
        {
            if (installment == null)
                return false;

            return
                installment.InstallmentNumber == installmentNumber &&
                installment.AmountDue == amountDue &&
                installment.Principal == principal &&
                installment.Interest == interest;
        }

        #endregion
    }
}
