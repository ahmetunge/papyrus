using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core.Aspects.Autofac.Validation;
using Core.Extensions;
using Core.Utilities.Results;
using Core.Utilities.Security.Identification;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Papyrus.Business.Abstract;
using Papyrus.Business.Constants;
using Papyrus.Business.Validations.FluentValidation;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Concrete.Enums;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Concrete
{
    public class AdManager : IAdService
    {
        private readonly IAdRepository _adRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AdManager(
            IAdRepository adRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _adRepository = adRepository;
        }

        [ValidationAspect(typeof(AdForCreationValidator), Priority = 1)]
        public async Task<IResult> CreateAsync(AdForCreationDto adForCreation)
        {
            Guid memberId = UserIdentification.UserId;

            Ad ad = _mapper.Map<Ad>(adForCreation);
            ad.MemberId = memberId;

            ad.UserAndDateForCreation();

            _adRepository.Add(ad);
            await _unitOfWork.CompleteAsync();

            return new SuccessResult(Messages.AdCreated, HttpStatusCode.Created);

        }

        public async Task<IDataResult<AdForDetailDto>> GetAdDetailsAsync(Guid adId)
        {
            var adFromDb = await _adRepository.GetAdDetailsAsync(adId);

            if (adFromDb == null)
            {
                return new ErrorDataResult<AdForDetailDto>(Messages.AdNotFound, HttpStatusCode.NotFound);
            }

            AdForDetailDto adForDetailDto = _mapper.Map<AdForDetailDto>(adFromDb);

            return new SuccessDataResult<AdForDetailDto>(adForDetailDto, HttpStatusCode.OK);
        }

        public async Task<IDataResult<List<Ad>>> GetListAsync()
        {
            var ads = await _adRepository.GetAllAsync();

            return new SuccessDataResult<List<Ad>>(ads.ToList());
        }

        public async Task<IDataResult<List<MemberAdForListDto>>> GetAdsAsync()
        {
            var ads = await _adRepository.GetAllAsync();

            var adsToReturn = _mapper.Map<List<MemberAdForListDto>>(ads);

            return new SuccessDataResult<List<MemberAdForListDto>>(adsToReturn, HttpStatusCode.OK);
        }

        public async Task<IDataResult<AdDetailForEditDto>> GetAdDetailsForEditAsync(Guid adId)
        {
            var adFromDb = await _adRepository.GetAdDetailsAsync(adId);

            if (adFromDb == null)
            {
                return new ErrorDataResult<AdDetailForEditDto>(Messages.AdNotFound, HttpStatusCode.NotFound);
            }

            AdDetailForEditDto adDetailForEdit = _mapper.Map<AdDetailForEditDto>(adFromDb);

            return new SuccessDataResult<AdDetailForEditDto>(adDetailForEdit, HttpStatusCode.OK);
        }

        public async Task<IResult> EditAsync(AdForCreationDto adForCreation, Guid adId)
        {
            var adFromDb = await _adRepository.GetAdDetailsAsync(adId);

            if (adFromDb == null)
            {
                return new ErrorDataResult<AdForDetailDto>(Messages.AdNotFound, HttpStatusCode.NotFound);
            }

            var adToUpdate = _mapper.Map<AdForCreationDto, Ad>(adForCreation, adFromDb);

            await _unitOfWork.CompleteAsync();

            return new SuccessResult(Messages.AdUpdated, HttpStatusCode.NoContent);
        }
    }
}