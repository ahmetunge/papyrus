using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Business.Abstract;

namespace Papyrus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        public CatalogsController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _catalogService.GetCatalogsIncludeGenresAsync();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

    }
}