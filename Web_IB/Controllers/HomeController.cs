using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Web_IB.Models;
using Web_IB.Services;

namespace Web_IB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProfilService _profilService;

        public HomeController(ProfilService profilService)
        {
            _profilService = profilService;
        }

        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                int me = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
                var profils = _profilService.GetProfilsIndexExcept(me);
                return View(profils);
            }

            var all = _profilService.GetProfilsIndex();
            return View(all);
        }
    }
}
