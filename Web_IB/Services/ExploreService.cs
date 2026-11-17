using Web_IB.Models;

namespace Web_IB.Services
{
    public class ExploreService
    {
        private readonly ProfilService _profilService;
        private readonly PortfolioService _portfolioService;

        public ExploreService(ProfilService profilService, PortfolioService portfolioService)
        {
            _profilService = profilService;
            _portfolioService = portfolioService;
        }

        public ExploreProfileViewModel? GetExploreProfile(int personneId)
        {
            var profil = _profilService.GetProfilDetails(personneId);
            if (profil == null) return null;

            var portfolio = _portfolioService.GetPortfolio(personneId);

            return new ExploreProfileViewModel
            {
                Profil = profil,
                Portfolio = portfolio
            };
        }
    }
}
