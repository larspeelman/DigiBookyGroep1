using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;
using System.Text;
using DigiBooky;
using Domain.Books;
using Domain.Authors;
using Api.DTO;
using System.Linq;

namespace DigiBookyTests.Books
{
    public class BookIntegrationTest
    {

        private readonly TestServer _server;
        private readonly HttpClient _client;

        public BookIntegrationTest()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());

            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Fact]
        public async Task GetDetailsOfBook_BookNotFound_ReturnsBadRequest()
        {
            DBBooks.ListofBooks = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    BookTitle = "test",
                    Author = new Author("jef", "vermassen"),
                    Isbn = "53151531"
                }
            };

            var response = await _client.GetAsync("/api/books/1");

            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetDetailsOfBook_BookFound_ReturnsOkForBook()
        {
            DBBooks.ListofBooks = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    BookTitle = "test",
                    Author = new Author("jef", "vermassen"),
                    Isbn = "53151531"
                }
            };

            var response = await _client.GetAsync("/api/book/1");
            var responseString = await response.Content.ReadAsStringAsync();
            var bookInfo = JsonConvert.DeserializeObject<BookDTO>(responseString);

            Assert.Equal("test", bookInfo.BookTitle);

        }

        [Fact]
        public async Task GetAllBooks_ListOfBooksFound_ReturnAllBooks()
        {
            BookMapper bm = new BookMapper();
            List<Book> testListOfBooks = new List<Book>
                 {
                new Book
                {
                    Id = 1,
                    BookTitle = "test",
                    Author = new Author("jef", "vermassen"),
                    Isbn = "53151531"
                }
            };
            DBBooks.ListofBooks = testListOfBooks;

            List<BookDTO> expectedList = testListOfBooks.Select(book =>
            {
                BookDTO newbook = bm.BooksMapper(book);
                return newbook;
            }).ToList();

            var response = await _client.GetAsync("/api/book/GetAllBooks");
            var responseString = await response.Content.ReadAsStringAsync();
            var listofbooks = JsonConvert.DeserializeObject<List<BookDTO>>(responseString);


            Assert.Equal(expectedList, listofbooks);

        }

        
    }
}
