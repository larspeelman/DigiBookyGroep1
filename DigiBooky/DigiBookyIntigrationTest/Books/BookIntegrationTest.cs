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
using System.Linq;
using Digibooky_domain.Books;
using Digibooky_domain.Authors;
using Digibooky_api.DTO;
using Digibooky_api;

namespace Digibooky_IntigrationTest.Books
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

        private void Initialize()
        {
            DBBooks.ListofBooks.Clear();
            DBAuthors.AuthorDB.Clear();
            Book.CounterOfBooks = 0;
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
                    Isbn = "53151531"
                    
                }
            };

            var response = await _client.GetAsync("/api/books/1");

            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetDetailsOfBook_BookFound_ReturnsOkForBook()
        {
            Initialize();
            DBAuthors.AuthorDB = FakedataAuthor();
            DBBooks.ListofBooks = new List<Book>
            {
                new Book
                {
                    BookTitle = "test",
                    AuthorId = DBAuthors.AuthorDB[0].Id.ToString(),
                    Isbn = "53151531"
                }
            };

            var count = Book.CounterOfBooks;

            var response = await _client.GetAsync("/api/book/0");
            var responseString = await response.Content.ReadAsStringAsync();
            var bookInfo = JsonConvert.DeserializeObject<BookDTO>(responseString);

            Assert.Equal("test", bookInfo.BookTitle);

        }

        [Fact]
        public async Task GetAllBooks_ListOfBooksFound_ReturnAllBooks()
        {
            DBAuthors.AuthorDB = FakedataAuthor();
            List<Book> testListOfBooks = new List<Book>
                 {
                new Book
                {
                    BookTitle = "test",
                    AuthorId = DBAuthors.AuthorDB[0].Id.ToString(),
                    Isbn = "53151531"
                }
            };
            DBBooks.ListofBooks = testListOfBooks;
            var response = await _client.GetAsync("/api/book");
            var responseString = await response.Content.ReadAsStringAsync();
            var listofbooks = JsonConvert.DeserializeObject<List<BookDTO>>(responseString);

            Assert.Single(listofbooks);

        }

        public  List<Author> FakedataAuthor()
        {
            List<Author> authorList = new List<Author>
            {
                new Author("Jef", "Depaepe"),
                new Author("Jos", "Schuurlink"),
                new Author("Guido", "Gazelle"),
            };
            return authorList;
        }

        
    }
}
