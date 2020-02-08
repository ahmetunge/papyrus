using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using Papyrus.Business.Abstract;
using Papyrus.Business.Constants;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Concrete
{
    public class AdManager : IAdService
    {
        private readonly IAdRepository _adRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AdManager(IAdRepository adRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _adRepository = adRepository;
        }

        public async Task<IResult> CreateAd(AdForCreationDto adForCreation)
        {
            if (adForCreation == null)
                return new ErrorResult(Messages.AdRequired);
            Ad ad = _mapper.Map<Ad>(adForCreation);

            _adRepository.Add(ad);
            await _unitOfWork.CompleteAsync();
            
            return new SuccessResult(Messages.AdCreated);

        }

        public async Task<IDataResult<List<Ad>>> GetListAsync()
        {
            var ads = await _adRepository.GetAllAsync();

            return new SuccessDataResult<List<Ad>>(ads.ToList());
        }
    }
}