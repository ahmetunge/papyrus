using Papyrus.Business.Abstract;
using Papyrus.DataAccess.Abstract;

namespace Papyrus.Business.Concrete
{
    public class AdManager : IAdService
    {
        private readonly IAdRepository _adRepository;
        public AdManager(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }
    }
}