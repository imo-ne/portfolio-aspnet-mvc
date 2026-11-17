using Microsoft.EntityFrameworkCore;
using Web_IB.Data;
using Web_IB.Entities;

namespace Web_IB.Repository
{
    public class MessageRepos
    {
        private readonly MyDbContextPortfolio _db;
        public MessageRepos(MyDbContextPortfolio db) => _db = db;

        public void Create(Message m)
        {
            _db.Messages.Add(m);
            _db.SaveChanges();
        }

        public List<Message> GetInbox(int destinataireId)
        {
            return _db.Messages
                .Include(x => x.Expediteur)
                .Where(x => x.DestinataireId == destinataireId)
                .OrderByDescending(x => x.DateCreation)
                .ToList();
        }
    }
}
