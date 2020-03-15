using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Business.Abstract;

namespace Papyrus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IPropertyService _propertyService;
        public CategoriesController(ICategoryService categoryService, IPropertyService propertyService)
        {
            _propertyService = propertyService;
            _categoryService = categoryService;
        }


        [HttpGet("ad")]
        public async Task<IActionResult> GetListForAd()
        {
            var result = await _categoryService.GetCategoriesIncludePropertiesAsync();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result);
        }

        [HttpGet("{id}/properties")]
        public async Task<IActionResult> GetPropertiesByCategoryId(Guid id)
        {
            var result = await _propertyService.GetPropertiesByCategoryId(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);

        }
    }
}