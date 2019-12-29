
using System;
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
            var result = _bookService.Add(bookForCreationDto);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("{id}")]
        public IActionResult GetBook(Guid id)
        {
            var result = _bookService.GetBookById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult EditBook([FromBody]BookForEditDto book, Guid id)
        {
            var result = _bookService.Edit(book, id);

            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);

        }

    }
}