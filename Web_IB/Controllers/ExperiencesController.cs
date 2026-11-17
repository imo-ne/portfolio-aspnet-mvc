using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web_IB.Entities;
using Web_IB.Repository;

namespace Web_IB.Controllers
{
    [Authorize]
    public class ExperiencesController : Controller
    {
        private readonly ExperienceRepos _repo;

        public ExperiencesController(ExperienceRepos repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            int personneId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var experiences = _repo.GetAllByPersonne(personneId);

            return View("~/Views/Portfolio/Experiences.cshtml", experiences);
        }

        [HttpPost]
        public IActionResult Create(string poste, string entreprise, DateTime? dateDebut, DateTime? dateFin, string? description)
        {
            int personneId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (string.IsNullOrWhiteSpace(poste) || string.IsNullOrWhiteSpace(entreprise))
                return RedirectToAction("Index");

            _repo.Create(new Experience
            {
                Poste = poste,
                Entreprise = entreprise,
                DateDebut = dateDebut,
                DateFin = dateFin,
                Description = description,
                PersonneId = personneId,
                DateCreation = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id, string poste, string entreprise, DateTime? dateDebut, DateTime? dateFin, string? description)
        {
            var exp = _repo.Get(id);
            if (exp == null) return RedirectToAction("Index");

            exp.Poste = poste;
            exp.Entreprise = entreprise;
            exp.DateDebut = dateDebut;
            exp.DateFin = dateFin;
            exp.Description = description;

            _repo.Update(exp);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
