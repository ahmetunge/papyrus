
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Papyrus.Business.Abstract;
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
        public async Task<IActionResult> Get()
        {
            var result =await _bookService.GetListAsync();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]BookForCreationDto bookForCreationDto)
        {
            var result =await _bookService.AddAsync(bookForCreationDto);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var result =await _bookService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook([FromBody]BookForEditDto book, Guid id)
        {
            var result =await _bookService.EditAsync(book, id);

            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);

        }

    }
}