using Web_IB.Entities;
using Web_IB.Models;
using Web_IB.Repository;

namespace Web_IB.Services
{
    public class AuthService
    {
        private readonly PersonneRepos _personneRepos;

        public AuthService(PersonneRepos personneRepos)
        {
            _personneRepos = personneRepos;
        }

        public Personne? Login(LoginViewModel model)
        {
            return _personneRepos.GetByEmailAndPassword(model.Email, model.MotDePasse);
        }

    }
            
}
