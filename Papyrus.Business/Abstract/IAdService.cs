using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Abstract
{
    public interface IAdService
    {
        Task<IDataResult<List<Ad>>> GetListAsync();

        Task<IResult> CreateAsync(AdForCreationDto adForCreation);
        Task<IDataResult<List<MemberAdForListDto>>> GetAdsAsync();

        Task<IDataResult<AdForDetailDto>> GetAdDetails(Guid adId);
    }
}