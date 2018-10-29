using Digibooky_api.DTO;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Digibooky_domain.Rentals;
using Digibooky_domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Digibooky_domain_UnitTests
{
   public class RentalRepositoryTest
    {
        private RentalRepository _rentalRepository;


        private void InitializeRepository()
        {
            _rentalRepository = new RentalRepository();
            DBBooks.ListofBooks.Clear();
            DBAuthors.AuthorDB.Clear();
            DBRentals.DBRental.Clear();
            DBUsers.UsersInLibrary.Clear();

            RentalDTO.rentalCounter = 0;
            Book.CounterOfBooks = 0;
            Author.IdCounter = 0;

            DBAuthors.AuthorDB.Add(new Author("testFirstName", "testLastName"));
            DBBooks.ListofBooks.Add(new Book()
            {
                AuthorId = "0",
                BookTitle = "test",
                Isbn = "isbnTest",
            });
            DBUsers.UsersInLibrary.Add(new User() { FirstName = "testUser", Birthdate = new DateTime(1987, 5, 21), IdentificationNumber = "LP_21051987", Email = "xx@hotmail.com" });
        }

        [Fact]
        public void GivenRentalRepository_WhenAddRentalToDB_ThenNewRentalInRentalDB()
        {
            InitializeRepository();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTest", };

            //When
            _rentalRepository.AddRentalToDB(testRental);

            //Then
            Assert.Contains(testRental, DBRentals.DBRental);
        }

        [Fact]
        public void GivenRentalRepository_WhenReturnRentalBook_ThenBookIsBackRentable()
        {
            InitializeRepository();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTest", RentalId = "0" };
            _rentalRepository.AddRentalToDB(testRental);
            testRental.Book.BookIsRentable = false;

            //When
            testRental = _rentalRepository.ReturnRentalBook(testRental);

            //Then
            Assert.True(testRental.Book.BookIsRentable);
        }

        [Fact]
        public void GivenRentalRepository_WhenReturnRentalThatIsNotRented_ThenReturnNull()
        {
            InitializeRepository();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTest" };
            _rentalRepository.AddRentalToDB(testRental);
            testRental.Book.BookIsRentable = true;

            //When
            var expexted = _rentalRepository.ReturnRentalBook(testRental);

            //Then
            Assert.Null(expexted);
        }
    }
}
