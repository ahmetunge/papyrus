using Microsoft.AspNetCore.Mvc;
using Papyrus.Business.Abstract;

namespace Papyrus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _bookService.GetBooks();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }
    }
}