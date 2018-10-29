using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Books;
using Digibooky_services.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digibooky_api.Controllers
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
        //[Route("GetAllBooks")]
        public IEnumerable<BookDTO> GetAllBooks()
        {
            return _bookService.GetAllBooks().Select(_bookMapper.BooksMapper);
        }

        // GET: api/Book/GetOneBook/5
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBookByIsbn([FromQuery] string isbn)
        {
            var result = _bookService.GetBookByIsbn(isbn);
            if (result.Count() == 0)
            {
                return BadRequest($"No books found for title {isbn}");
            }
            return Ok(result.Select(foundBook => _bookMapper.BooksMapper(foundBook)));
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBookTitle([FromQuery (Name = "title")] string title)
        {
            var result = _bookService.GetBookByTitle(title);
            if (result.Count() == 0)
            {
                return BadRequest($"No books found for title {title}");
            }
            return Ok(result.Select(foundBook => _bookMapper.BooksMapper(foundBook)));
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBookByAuthor([FromQuery(Name ="author")]string author)
        {
            var result = _bookService.GetBookByAuthor(author);
            if (result.Count() == 0)
            {
                return BadRequest($"No books found for author {author}");
            }
            return Ok(result.Select(foundBook => _bookMapper.BooksMapper(foundBook)));
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> ShowDetailsOfBook(int id)
        {
            var book = _bookService.ShowDetailsOfBook(id);
            if (book == null)
            {
                return BadRequest($"Book with id: {id} not found");
            }
            return Ok(_bookMapper.BooksMapper(book));
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
