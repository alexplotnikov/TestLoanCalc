using LoanCalculator.Services;
using LoanCalculator.Services.Models;
using System.Web.Http;

namespace LoanCalculator.WebApi.Controllers
{
    public class LoanSummaryController : ApiController
    {
        [HttpGet]
        public LoanSummary GetLoanSummary(
            [FromUri] decimal amount,
            [FromUri] int apr)
        {
            var loanCalculationService = new LoanCalculationService();
            return loanCalculationService.GetLoanSummary(amount, apr);
        }
    }
}
