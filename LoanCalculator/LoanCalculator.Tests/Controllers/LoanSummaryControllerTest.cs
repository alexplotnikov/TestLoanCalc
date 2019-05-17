using LoanCalculator.Services.Models;
using LoanCalculator.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http;

namespace LoanCalculator.Tests.Controllers
{
    [TestClass]
    public class LoanSummaryControllerTest
    {
        [TestMethod]
        public void GetLoanSummary_Exists()
        {
            var method = typeof(LoanSummaryController)
                .GetMethods()
                .SingleOrDefault(m => m.Name == nameof(LoanSummaryController.GetLoanSummary));

            Assert.IsNotNull(method);
        }

        [TestMethod]
        public void GetLoanSummary_HasHttpGetAttribute()
        {
            var method = typeof(LoanSummaryController)
                .GetMethods()
                .SingleOrDefault(m => m.Name == nameof(LoanSummaryController.GetLoanSummary));

            var attribute = method
                .GetCustomAttributes(typeof(HttpGetAttribute), true)
                .Single() as HttpGetAttribute;

            Assert.IsNotNull(attribute);
        }

        [TestMethod]
        public void GetLoanSummary_ReturnsNotNull()
        {
            LoanSummaryController controller = new LoanSummaryController();
            LoanSummary result = controller.GetLoanSummary(50000m, 19);
            Assert.IsNotNull(result);
        }
    }
}
