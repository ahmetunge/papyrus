using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Papyrus.Business.Abstract;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;

namespace Papyrus.Business.Concrete
{
    public class AdManager : IAdService
    {
        private readonly IAdRepository _adRepository;
        public AdManager(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public async Task<IDataResult<List<Ad>>> GetListAsync()
        {
            var ads =await _adRepository.GetAllAsync();

            return new SuccessDataResult<List<Ad>>(ads.ToList());
        }
    }
}