using Web_IB.Data;
using Web_IB.Entities;

namespace Web_IB.Repository
{
    public class PersonneRepos
    {
        private readonly MyDbContextPortfolio _db;

        public PersonneRepos(MyDbContextPortfolio context)
        {
            _db = context;
        }

        public bool Create(Personne personne)
        {
            _db.Personnes.Add(personne);
            _db.SaveChanges();
            return true;
        }

        public List<Personne> GetAll()
        {
            return _db.Personnes.ToList();
        }

        public Personne? Get(int id)
        {
            return _db.Personnes.FirstOrDefault(p => p.Id == id);
        }
        public Personne? GetByNomAndPassword(string nom, string motDePasse)
        {
            return _db.Personnes.FirstOrDefault(p => p.Nom == nom && p.MotDePasse == motDePasse);
        }
        public Personne? GetByEmailAndPassword(string email, string motDePasse)
        {
            return _db.Personnes.FirstOrDefault(p => p.Email == email && p.MotDePasse == motDePasse);
        }

    }
}
