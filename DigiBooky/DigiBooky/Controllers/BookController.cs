using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Books;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: api/Book
        [HttpGet]
        //[Route("GetAllBooks")]
        public IEnumerable<BookDTO> GetAllBooks()
        {
            return bookService.GetAllBooks().Select(BookMapper.BooksMapper);
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetBook")]
        [Route("GetOneBook")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
