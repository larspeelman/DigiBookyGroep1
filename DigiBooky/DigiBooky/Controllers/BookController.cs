using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTO;
using Api.Helper;
using Domain.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Books;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IBookMapper _bookMapper;


        public BookController(IBookService bookService, IBookMapper bookMapper)
        {
            this._bookService = bookService;
            _bookMapper = bookMapper;
        }

        // GET: api/Book/GetAllBooks
        [HttpGet]
        [Route("GetAllBooks")]
        public IEnumerable<BookDTO> GetAllBooks()
        {
            return _bookService.GetAllBooks().Select(_bookMapper.BooksMapper);
        }

        // GET: api/Book/GetOneBook/5
        [HttpGet("{isbn}", Name = "GetBookByIsdn")]
        [Route("GetBookByIsdn")]
        public ActionResult<BookDTO> Get(string isbn)
        {
                Book foundBook = _bookService.GetBookByIsdn(isbn);
                if (foundBook == null)
                {
                    return BadRequest($"Book with id: {isbn} not found");
                }
                return Ok(_bookMapper.BooksMapper(foundBook));
        }

        [HttpGet("{title}", Name = "GetBookTitle")]
        [Route("GetBookTitle")]
        public ActionResult<IEnumerable<BookDTO>> GetBookTitle(string title)
        {
            return BadRequest($"Book with Title: {title} not found");
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] BookDTO newBook)
        {
        }

        // PUT: api/Book/5
        [HttpPut("{isbn}")]
        public void Put(string isbn, [FromBody] BookDTO updateBook)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn}")]
        public void Delete(string isbn)
        {
        }
    }
}
