using Web_IB.Models;
using Web_IB.Repository;
namespace Web_IB.Services
{
    public class PortfolioService
    {
        private readonly CompetenceRepos _competenceRepos;
        private readonly ProjetRepos _projetRepos;
        private readonly ExperienceRepos _experienceRepos;

        public PortfolioService(CompetenceRepos c, ProjetRepos p, ExperienceRepos e)
        {
            _competenceRepos = c;
            _projetRepos = p;
            _experienceRepos = e;
        }

        public PortfolioViewModel GetPortfolio(int personneId)
        {
            var vm = new PortfolioViewModel();

            vm.Skills = _competenceRepos.GetAllByPersonne(personneId)
                .Select(x => new SkillItemVM
                {
                    Id = x.Id,
                    Nom = x.Nom,
                    Niveau = x.Niveau.HasValue ? x.Niveau.Value.ToString() : null
                }).ToList();


            vm.Projects = _projetRepos.GetAllByPersonne(personneId)
                .Select(x => new ProjectItemVM { Id = x.Id, Titre = x.Titre, Description = x.Description, Lien = x.Lien }).ToList();

            vm.Experiences = _experienceRepos.GetAllByPersonne(personneId)
                .Select(x => new ExperienceItemVM
                {
                    Id = x.Id,
                    Poste = x.Poste,
                    Entreprise = x.Entreprise,
                    Periode = $"{x.DateDebut:yyyy-MM} → {(x.DateFin == null ? "Present" : x.DateFin.Value.ToString("yyyy-MM"))}",
                    Description = x.Description
                }).ToList();

            return vm;
        }
    }
}
