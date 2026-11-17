using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web_IB.Services;

namespace Web_IB.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly PortfolioService _portfolioService;

        public PortfolioController(PortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            int personneId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var vm = _portfolioService.GetPortfolio(personneId);
            return View(vm);
        }
    }
}
