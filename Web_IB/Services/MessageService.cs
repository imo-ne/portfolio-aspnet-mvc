using Web_IB.Entities;
using Web_IB.Models;
using Web_IB.Repository;

namespace Web_IB.Services
{
    public class MessageService
    {
        private readonly MessageRepos _messageRepos;
        private readonly PersonneRepos _personneRepos;

        public MessageService(MessageRepos messageRepos, PersonneRepos personneRepos)
        {
            _messageRepos = messageRepos;
            _personneRepos = personneRepos;
        }

        public SendMessageViewModel? BuildSendVm(int destinataireId)
        {
            var p = _personneRepos.Get(destinataireId);
            if (p == null) return null;

            return new SendMessageViewModel
            {
                DestinataireId = p.Id,
                DestinataireNom = $"{p.Prenom} {p.Nom}"
            };
        }

        public void Send(int expediteurId, SendMessageViewModel model)
        {
            var msg = new Message
            {
                ExpediteurId = expediteurId,
                DestinataireId = model.DestinataireId,
                Contenu = model.Contenu,
                DateCreation = DateTime.Now
            };

            _messageRepos.Create(msg);
        }

        public List<InboxMessageViewModel> GetInbox(int destinataireId)
        {
            return _messageRepos.GetInbox(destinataireId)
                .Select(m => new InboxMessageViewModel
                {
                    From = m.Expediteur == null ? "Unknown" : $"{m.Expediteur.Prenom} {m.Expediteur.Nom}",
                    Contenu = m.Contenu,
                    Date = m.DateCreation
                }).ToList();
        }
    }
}
