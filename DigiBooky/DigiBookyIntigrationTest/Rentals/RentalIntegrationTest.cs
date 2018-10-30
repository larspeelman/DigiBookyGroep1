using Digibooky_api;
using Digibooky_api.Controllers;
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Digibooky_domain.Rentals;
using Digibooky_domain.Users;
using Digibooky_services.Rentals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
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
            UserRepository userRepository = new UserRepository();
            RentalService rentalService = new RentalService(bookRepository, rentalRepository, userRepository);
            rentalController = new RentalController(rentalService, rentalMapper);

            DBAuthors.AuthorDB.Clear();
            DBAuthors.AuthorDB.Add(new Author("testFirstName", "testLastName"));
            DBBooks.ListofBooks.Clear();
            DBRentals.DBRental.Clear();
            Rental.rentalCounter = 0;
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

        [Fact]
        public void ReturnABook_BookExist_ThenRentalIsNotAnymoreDBRentals()
        {
            Initialize_RentalIntegrationTest();
            RentalDTO testRental = new RentalDTO() { UserIdNumber = "LP_21051987", Isbn = "isbnTest" };
            rentalController.RentABook(testRental);

            //When
            rentalController.ReturnABook(0);

            //Then
            Assert.Null(DBRentals.DBRental.SingleOrDefault(rental => rental.Isbn == "isbnTest"));
        }

        [Fact]
        public void ReturnABook_UserNotExistWithThisRental_ThenReturnBadRequest()
        {
            Initialize_RentalIntegrationTest();
            RentalDTO testRental = new RentalDTO() { UserIdNumber = "LP_21051987", Isbn = "isbnTest" };
            rentalController.RentABook(testRental);


            //When
            var check = rentalController.ReturnABook(1).Result;


            //then
            Assert.IsType<BadRequestObjectResult>(check);

        }

        [Fact]
        public void ReturnABook_ReturnDateIsLaterThanEndDateRental_ThenReturnOkWithMessageToLate()
        {
            Initialize_RentalIntegrationTest();
            RentalDTO testRental = new RentalDTO() { UserIdNumber = "LP_21051987", Isbn = "isbnTest", EndDate = new DateTime(2018, 01, 01) };
        
            rentalController.RentABook(testRental);


            //When
            var check = (OkObjectResult)rentalController.ReturnABook(0).Result;

            //then
            Assert.Equal(Digibooky_api.Properties.Resources.Rental_ToLate, check.Value.ToString());

        }
    }
}
