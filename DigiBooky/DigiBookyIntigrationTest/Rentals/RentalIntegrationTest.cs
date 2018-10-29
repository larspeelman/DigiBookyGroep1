using Digibooky_api;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Digibooky_domain.Rentals;
using Digibooky_domain.Users;
using Digibooky_services.Rentals;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Digibooky_IntigrationTest.Rentals
{
    public class RentalIntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public RentalIntegrationTest()
        {
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());

            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private RentalService _rentalService;
        private IRentalRepository _rentalRepositoryStub;
        private IBookRepository _bookRepositoryStub;
        private void Initialize_RentalServiceTest()
        {
            _rentalRepositoryStub = new RentalRepository();
            _bookRepositoryStub = new BookRepository();
            _rentalService = new RentalService(_bookRepositoryStub, _rentalRepositoryStub);
            DBAuthors.AuthorDB.Clear();
            DBAuthors.AuthorDB.Add(new Author("testFirstName", "testLastName"));
            DBBooks.ListofBooks.Clear();
            DBBooks.ListofBooks.Add(new Book()
            {
                AuthorId = "0",
                BookTitle = "test",
                Isbn = "isbnTest",
                BookIsRentable = true
            });
            DBUsers.UsersInLibrary.Clear();
            DBUsers.UsersInLibrary.Add(new User() { FirstName = "testUser", Birthdate = new DateTime(1987, 5, 21), IdentificationNumber = "LP_21051987", Email = "xx@hotmail.com" });
        }

        [Fact]
        public async Task RentABook_BookExist_ReturnsGoodRequest()
        {
            //    DBBooks.ListofBooks = new List<Book>
            //    {
            //        new Book
            //        {
            //            Id = 1,
            //            BookTitle = "test",
            //            Isbn = "53151531"

            //        }
            //    };

            //    var response = await _client.PostAsync("/api/rental/1", new Rental() { UserIdNumber = "LP_21051987", Isbn = "53151531" });

            //    Assert.False(response.IsSuccessStatusCode);
            //}
        }
    }
}
