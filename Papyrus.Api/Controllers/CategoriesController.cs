using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Business.Abstract;

namespace Papyrus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("ad")]
        public async Task<IActionResult> GetListForAd()
        {
            var result = await _categoryService.GetListAsync();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }
    }
}