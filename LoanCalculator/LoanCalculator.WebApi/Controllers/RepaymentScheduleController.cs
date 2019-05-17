using LoanCalculator.Services;
using LoanCalculator.Services.Models;
using System.Web.Http;

namespace LoanCalculator.WebApi.Controllers
{
    public class RepaymentScheduleController : ApiController
    {
        [HttpGet]
        public RepaymentSchedule GetRepaymentSchedule(
            [FromUri] decimal amount,
            [FromUri] int apr)
        {
            var loanCalculationService = new LoanCalculationService();
            return loanCalculationService.GetRepaymentSchedule(amount, apr);
        }
    }
}
