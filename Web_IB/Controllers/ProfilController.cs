using Microsoft.AspNetCore.Mvc;
using Web_IB.Models;
using Web_IB.Services;

namespace Web_IB.Controllers
{
    public class ProfilController : Controller
    {
        private readonly ProfilService _profilService;
        private readonly ExploreService _exploreService;

        public ProfilController(ProfilService profilService, ExploreService exploreService)
        {
            _profilService = profilService;
            _exploreService = exploreService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var vm = _exploreService.GetExploreProfile(id);
            if (vm == null) return NotFound();

            return View(vm);
        }


        [HttpPost]
        public IActionResult Create(FormulaireCreationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _profilService.CreateProfil(model);

            ViewBag.Success = "Profil créé avec succès.";
            return View();
        }
    }
}
