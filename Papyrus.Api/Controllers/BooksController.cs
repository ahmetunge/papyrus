using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Business.Abstract;
using Papyrus.Entities;
using Papyrus.Entities.Dtos;

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

        [HttpPost]
        public IActionResult Create([FromBody]BookForCreationDto bookForCreationDto)
        {
            //TODO user Automapper here
            Book book = new Book()
            {
                Name = bookForCreationDto.Name,
                Summary = bookForCreationDto.Summary
            };

            var result = _bookService.Add(book);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
    }
}