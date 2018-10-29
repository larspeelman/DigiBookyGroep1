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
        public ActionResult<IEnumerable<BookDTO>> GetAllBooks(string isbn = null, string title = null, string author = null)
        {
            IEnumerable<Book> result;
            if (!string.IsNullOrEmpty(isbn))
            {
                result = _bookService.GetBookByIsbn(isbn);
                if (!result.Any())
                {
                    return BadRequest($"No books found for Isbn {isbn}");
                }
                return Ok(result.Select(foundBook => _bookMapper.BooksMapper(foundBook)));
            }
            if (!string.IsNullOrEmpty(title))
            {
                result = _bookService.GetBookByTitle(title);
                if (!result.Any())
                {
                    return BadRequest($"No books found for title {title}");
                }
                return Ok(result.Select(foundBook => _bookMapper.BooksMapper(foundBook)));
            }
            if (!string.IsNullOrEmpty(author))
            {
                result = _bookService.GetBookByAuthor(author);
                if (!result.Any())
                {
                    return BadRequest($"No books found for author {author}");
                }
                return Ok(result.Select(foundBook => _bookMapper.BooksMapper(foundBook)));
            }
            return Ok(_bookService.GetAllBooks().Select(_bookMapper.BooksMapper));
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