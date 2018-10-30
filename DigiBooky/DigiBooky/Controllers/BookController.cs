using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Books;
using Digibooky_services.Books;
using Digibooky_services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digibooky_api.Controllers
{
    [Authorize]
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
        //http://localhost:49908/api/book?isbn=7&author=schuur
        [AllowAnonymous]
        [HttpGet]
        //[Route("GetAllBooks")]
        public ActionResult<IEnumerable<BookDTO>> GetAllBooks(string isbn = null, string title = null, string author = null)
        {
            List<Func<Book, bool>> delegateFuncs = _bookService.CreateDelegates(isbn, title, author);
 
            IEnumerable<Book> result = _bookService.GetBookByFilter(delegateFuncs);
            if (!result.Any())
            {
                return BadRequest($"No books found for selection");
            }
            return Ok(result.Select(foundBook => _bookMapper.BooksMapperBookToDTO(foundBook)));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<BookDTO> ShowDetailsOfBook(int id)
        {
            var book = _bookService.ShowDetailsOfBook(id);
            if (book == null)
            {
                return BadRequest($"Book with id: {id} not found");
            }
            return Ok(_bookMapper.BooksMapperBookToDTO(book));
        }

        // POST: api/Book
        [Authorize(Policy = "ModeratorAccess")]
        [HttpPost]
        public ActionResult<BookDTO> RegisterNewBook([FromBody] BookDTO newBook)
        {
            var book = _bookService.RegisterNewBook(_bookMapper.BooksMapperDTOToBook(newBook));
            if (book == null)
            {
                return BadRequest("Bad Input");
            }
            return Ok(_bookMapper.BooksMapperBookToDTO(book));
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