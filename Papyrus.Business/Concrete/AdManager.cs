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

            _adRepository.Add(ad);
            await _unitOfWork.CompleteAsync();

            return new SuccessResult(Messages.AdCreated,HttpStatusCode.Created);

        }

        public async Task<IDataResult<List<Ad>>> GetListAsync()
        {
            var ads = await _adRepository.GetAllAsync();

            return new SuccessDataResult<List<Ad>>(ads.ToList());
        }

        public async Task<IDataResult<List<MemberAdForListDto>>> GetMemberAdsAsync(Guid memberId)
        {
            var ads = await _adRepository.FindListAsync(a => a.MemberId==memberId);

          var adsToReturn =_mapper.Map<List<MemberAdForListDto>>(ads);

            return new SuccessDataResult<List<MemberAdForListDto>>(adsToReturn,HttpStatusCode.OK);
        }
    }
}