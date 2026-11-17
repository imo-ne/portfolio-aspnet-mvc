using Web_IB.Models;
using Web_IB.Repository;

namespace Web_IB.Services
{
    public class ProfilService
    {
        private readonly PersonneRepos _personneRepos;

        public ProfilService(PersonneRepos personneRepos)
        {
            _personneRepos = personneRepos;
        }

        public void CreateProfil(FormulaireCreationViewModel model)
        {
            var nouvellePersonne = new Web_IB.Entities.Personne
            {
                Nom = model.Nom,
                Prenom = model.Prenom,
                Email = model.Email,
                MotDePasse = model.MotDePasse, 
                Bio = model.Bio,
                Photo = model.Photo,
                LinkedIn = model.LinkedIn,
                GitHub = model.GitHub,
                DateCreation = DateTime.Now
            };

            _personneRepos.Create(nouvellePersonne);
        }
        public List<ProfilIndexViewModel> GetProfilsIndex()
        {
            var personnes = _personneRepos.GetAll();

            return personnes.Select(p => new ProfilIndexViewModel
            {
                Id = p.Id,
                NomComplet = $"{p.Prenom} {p.Nom}",
                Bio = p.Bio,
                Photo = p.Photo
            }).ToList();
        }
        public ProfilDetailsViewModel? GetProfilDetails(int id)
        {
            var p = _personneRepos.Get(id);
            if (p == null) return null;

            return new ProfilDetailsViewModel
            {
                Id = p.Id,
                NomComplet = $"{p.Prenom} {p.Nom}",
                Photo = p.Photo,
                Bio = p.Bio,
                LinkedIn = p.LinkedIn,
                GitHub = p.GitHub
            };
        }
        public List<ProfilIndexViewModel> GetProfilsIndexExcept(int excludedPersonneId)
        {
            var profils = _personneRepos.GetAll()
                .Where(p => p.Id != excludedPersonneId)
                .ToList();

            return profils.Select(p => new ProfilIndexViewModel
            {
                Id = p.Id,
                NomComplet = $"{p.Prenom} {p.Nom}",
                Bio = p.Bio,
                Photo = p.Photo
            }).ToList();
        }

    }
}
