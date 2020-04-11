using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Api.Extesnsions;
using Papyrus.Business.Abstract;
using Papyrus.Entities.Dtos;

namespace Papyrus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly IAdService _adService;
        public AdsController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAds(Guid memberId)
        {
            IDataResult<List<MemberAdForListDto>> result = await _adService.GetAdsAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("{adId}")]
        public async Task<IActionResult> GetAdDetail(Guid memberId, Guid adId)
        {
            var result = await _adService.GetAdDetails(adId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}