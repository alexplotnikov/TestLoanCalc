using LoanCalculator.Services.Models;
using LoanCalculator.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http;

namespace LoanCalculator.Tests.Controllers
{
    [TestClass]
    public class RepaymentScheduleControllerTest
    {
        [TestMethod]
        public void GetRepaymentSchedule_Exists()
        {
            var method = typeof(RepaymentScheduleController)
                .GetMethods()
                .SingleOrDefault(m => m.Name == nameof(RepaymentScheduleController.GetRepaymentSchedule));

            Assert.IsNotNull(method);
        }

        [TestMethod]
        public void GetRepaymentSchedule_HasHttpGetAttribute()
        {
            var method = typeof(RepaymentScheduleController)
                .GetMethods()
                .SingleOrDefault(m => m.Name == nameof(RepaymentScheduleController.GetRepaymentSchedule));

            var attribute = method
                .GetCustomAttributes(typeof(HttpGetAttribute), true)
                .Single() as HttpGetAttribute;

            Assert.IsNotNull(attribute);
        }

        [TestMethod]
        public void GetRepaymentSchedule_ReturnsNotNull()
        {
            RepaymentScheduleController controller = new RepaymentScheduleController();
            RepaymentSchedule result = controller.GetRepaymentSchedule(50000m, 19);
            Assert.IsNotNull(result);
        }
    }
}
