using Web_IB.Data;
using Web_IB.Entities;

namespace Web_IB.Repository
{
    public class ProjetRepos
    {
        private readonly MyDbContextPortfolio _db;
        public ProjetRepos(MyDbContextPortfolio db) => _db = db;

        public List<Projet> GetAllByPersonne(int personneId) =>
            _db.Projets.Where(p => p.PersonneId == personneId).ToList();

        public Projet? Get(int id) => _db.Projets.FirstOrDefault(x => x.Id == id);

        public void Create(Projet p) { _db.Projets.Add(p); _db.SaveChanges(); }

        public void Update(Projet p) { _db.Projets.Update(p); _db.SaveChanges(); }

        public void Delete(int id)
        {
            var item = _db.Projets.FirstOrDefault(x => x.Id == id);
            if (item != null) { _db.Projets.Remove(item); _db.SaveChanges(); }
        }
    }
}
