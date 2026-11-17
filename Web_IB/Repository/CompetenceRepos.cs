using Web_IB.Data;
using Web_IB.Entities;

namespace Web_IB.Repository
{
    public class CompetenceRepos
    {
        private readonly MyDbContextPortfolio _db;
        public CompetenceRepos(MyDbContextPortfolio db) => _db = db;

        public List<Competence> GetAllByPersonne(int personneId) =>
            _db.Competences.Where(c => c.PersonneId == personneId).ToList();

        public Competence? Get(int id) => _db.Competences.FirstOrDefault(x => x.Id == id);

        public void Create(Competence c) { _db.Competences.Add(c); _db.SaveChanges(); }

        public void Update(Competence c) { _db.Competences.Update(c); _db.SaveChanges(); }

        public void Delete(int id)
        {
            var item = _db.Competences.FirstOrDefault(x => x.Id == id);
            if (item != null) { _db.Competences.Remove(item); _db.SaveChanges(); }
        }
    }
}
