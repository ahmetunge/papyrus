using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Business.Abstract;
using Papyrus.Entities.Dtos;

namespace Papyrus.Api.Controllers
{
    [ApiController]
    [Route("api/members/{memberId}/[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly IAdService _adService;
        public AdsController(IAdService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAds()
        {
            var result = await _adService.GetListAsync();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAd(Guid memberId, [FromBody]AdForCreationDto adForCreation)
        {
            // if (memberId != Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //     return Unauthorized();

            IResult result = await _adService.CreateAd(adForCreation);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);

        }
    }
}