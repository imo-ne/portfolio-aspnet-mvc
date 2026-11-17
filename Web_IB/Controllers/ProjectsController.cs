using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web_IB.Entities;
using Web_IB.Repository;

namespace Web_IB.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly ProjetRepos _repo;

        public ProjectsController(ProjetRepos repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            int personneId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var projects = _repo.GetAllByPersonne(personneId);

            return View("~/Views/Portfolio/Projects.cshtml", projects);
        }

        [HttpPost]
        public IActionResult Create(string titre, string? description, string? lien)
        {
            int personneId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (string.IsNullOrWhiteSpace(titre))
                return RedirectToAction("Index");

            _repo.Create(new Projet
            {
                Titre = titre,
                Description = description,
                Lien = lien,
                PersonneId = personneId,
                DateCreation = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id, string titre, string? description, string? lien)
        {
            var projet = _repo.Get(id);
            if (projet == null) return RedirectToAction("Index");

            projet.Titre = titre;
            projet.Description = description;
            projet.Lien = lien;

            _repo.Update(projet);
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
