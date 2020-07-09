using System;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Api.Extesnsions;
using Papyrus.Business.Abstract;
using Papyrus.Entities.Dtos;

namespace Papyrus.Api.Controllers
{
    [ApiController]
    [Route("api/members/{memberId}/ads")]
    public class MemberAdsController : ControllerBase
    {
        private readonly IAdService _adService;
        public MemberAdsController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAd(Guid memberId, [FromBody] AdForCreationDto adForCreation)
        {
            if (!User.CheckAuthorization(memberId))
                return BadRequest(new UnauthorizedErrorResult());

            IResult result = await _adService.CreateAsync(adForCreation);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("{id}/edit")]
        public async Task<IActionResult> GetAdToEdit(Guid memberId, Guid id)
        {
            if (!User.CheckAuthorization(memberId))
                return BadRequest(new UnauthorizedErrorResult());

            IDataResult<AdDetailForEditDto> result = await _adService.GetAdDetailsForEditAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{adId}")]
        public async Task<IActionResult> UpdateAd(Guid memberId, Guid adId, [FromBody] AdForCreationDto adForEditDto)
        {
            if (!User.CheckAuthorization(memberId))
                return BadRequest(new UnauthorizedErrorResult());

            IResult result = await _adService.EditAsync(adForEditDto, adId);
            return Ok();
        }
    }
}