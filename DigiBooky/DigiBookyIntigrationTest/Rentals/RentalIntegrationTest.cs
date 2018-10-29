using Digibooky_api;
using Digibooky_api.Controllers;
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Digibooky_domain.Rentals;
using Digibooky_domain.Users;
using Digibooky_services.Rentals;
using System;
using Xunit;

namespace Digibooky_IntigrationTest.Rentals
{
    public class RentalIntegrationTest
    {
        private RentalController rentalController;
        private void Initialize_RentalIntegrationTest()
        {
            RentalRepository rentalRepository = new RentalRepository();
            BookRepository bookRepository = new BookRepository();
            RentalMapper rentalMapper = new RentalMapper();
            RentalService rentalService = new RentalService(bookRepository, rentalRepository);
            rentalController = new RentalController(rentalService, rentalMapper);

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
        public void RentABook_BookExist_ThenRentalIsInDBRentals()
        {
            Initialize_RentalIntegrationTest();
            RentalDTO testRental = new RentalDTO() { UserIdNumber = "LP_21051987", Isbn = "isbnTest" };
            rentalController.RentABook(testRental);

            //Then
            Assert.Single(DBRentals.DBRental);
        }
    }
}
