using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web_IB.Entities;
using Web_IB.Repository;
using Web_IB.shared;

namespace Web_IB.Controllers
{
    [Authorize]
    public class SkillsController : Controller
    {
        private readonly CompetenceRepos _repo;

        public SkillsController(CompetenceRepos repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            int personneId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var skills = _repo.GetAllByPersonne(personneId);
            return View("~/Views/Portfolio/Skills.cshtml" ,skills);
        }

        [HttpPost]
        public IActionResult Create(string nom, NiveauCompetence? niveau)
        {
            int personneId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (string.IsNullOrWhiteSpace(nom))
                return RedirectToAction("Index");

            _repo.Create(new Competence { Nom = nom, Niveau = niveau, PersonneId = personneId });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id, string nom, NiveauCompetence? niveau)
        {
            var skill = _repo.Get(id);
            if (skill == null) return RedirectToAction("Index");

            skill.Nom = nom;
            skill.Niveau = niveau;
            _repo.Update(skill);

            return RedirectToAction("Index");
        }
    }
}
