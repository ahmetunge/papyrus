using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateAd([FromBody]AdForCreationDto adForCreation)
        {

            IResult result = await _adService.CreateAd(adForCreation);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);

        }
    }
}