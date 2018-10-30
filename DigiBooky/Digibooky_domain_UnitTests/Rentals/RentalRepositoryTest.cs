using Digibooky_api.DTO;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Digibooky_domain.Rentals;
using Digibooky_domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Digibooky_domain_UnitTests.Rentals
{
   public class RentalRepositoryTest
    {
        private RentalRepository _rentalRepository;


        private void InitializeRepository()
        {
            _rentalRepository = new RentalRepository();
            DBAuthors.AuthorDB.Add(new Author("testFirstName", "testLastName") { Id = "0"});
            DBBooks.ListofBooks.Add(new Book()
            {
                AuthorId = "0",
                BookTitle = "test",
                Isbn = "isbnTestRentalRepository",
            });
            DBUsers.UsersInLibrary.Add(new User() { FirstName = "testUser", Birthdate = new DateTime(1987, 5, 21), IdentificationNumber = "LP_21051987", Email = "xx@hotmail.com", Id=0 });
        }

        [Fact]
        public void GivenRentalRepository_WhenAddRentalToDB_ThenNewRentalInRentalDB()
        {
            InitializeRepository();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTestRentalRepository", };

            //When
            _rentalRepository.AddRentalToDB(testRental);

            //Then
            Assert.Contains(testRental, DBRentals.DBRental);
            ClearAllDataBasesRentalRepositoryTest();
        }

        [Fact]
        public void GivenRentalRepository_WhenReturnRentalBook_ThenBookIsBackRentable()
        {
            ClearAllDataBasesRentalRepositoryTest();
            InitializeRepository();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTestRentalRepository", RentalId = "0" };
            _rentalRepository.AddRentalToDB(testRental);
            testRental.Book.BookIsRentable = false;

            //When
            testRental = _rentalRepository.ReturnRentalBook(testRental);

            //Then
            Assert.True(testRental.Book.BookIsRentable);
            ClearAllDataBasesRentalRepositoryTest();
        }

        [Fact]
        public void GivenRentalRepository_WhenReturnRentalThatIsNotRented_ThenReturnNull()
        {
            InitializeRepository();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTestRentalRepository" };
            _rentalRepository.AddRentalToDB(testRental);
            testRental.Book.BookIsRentable = true;

            //When
            var expexted = _rentalRepository.ReturnRentalBook(testRental);

            //Then
            Assert.Null(expexted);
            ClearAllDataBasesRentalRepositoryTest();
        }

        private void ClearAllDataBasesRentalRepositoryTest()
        {
            DBRentals.DBRental = null;
            DBRentals.DBRental = new List<Rental>();
            DBUsers.UsersInLibrary = null;
            DBUsers.UsersInLibrary = new List<User>();
            DBBooks.ListofBooks = null;
            DBBooks.ListofBooks = new List<Book>();
            DBAuthors.AuthorDB = null;
            DBAuthors.AuthorDB = new List<Author>();
        }
    }
}
