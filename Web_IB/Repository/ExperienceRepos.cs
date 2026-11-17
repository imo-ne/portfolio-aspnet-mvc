using Web_IB.Data;
using Web_IB.Entities;

namespace Web_IB.Repository
{
    public class ExperienceRepos
    {
        private readonly MyDbContextPortfolio _db;
        public ExperienceRepos(MyDbContextPortfolio db) => _db = db;

        public List<Experience> GetAllByPersonne(int personneId) =>
            _db.Experiences.Where(e => e.PersonneId == personneId).ToList();

        public Experience? Get(int id) => _db.Experiences.FirstOrDefault(x => x.Id == id);

        public void Create(Experience e) { _db.Experiences.Add(e); _db.SaveChanges(); }

        public void Update(Experience e) { _db.Experiences.Update(e); _db.SaveChanges(); }

        public void Delete(int id)
        {
            var item = _db.Experiences.FirstOrDefault(x => x.Id == id);
            if (item != null) { _db.Experiences.Remove(item); _db.SaveChanges(); }
        }
    }
}
