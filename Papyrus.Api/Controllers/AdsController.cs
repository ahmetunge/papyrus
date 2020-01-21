using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Business.Abstract;

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
    }
}