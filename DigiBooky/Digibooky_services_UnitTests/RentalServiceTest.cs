using Digibooky_api.DTO;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Digibooky_domain.Rentals;
using Digibooky_domain.Users;
using Digibooky_services.Rentals;
using NSubstitute;
using System;
using Xunit;

namespace Digibooky_services_UnitTests
{
   public class RentalServiceTest
    {
        private RentalService _rentalService;
        private IRentalRepository _rentalRepositoryStub;
        private IBookRepository _bookRepositoryStub;
        private void Initialize_RentalServiceTest()
        {
            _rentalRepositoryStub = Substitute.For<IRentalRepository>();
            _bookRepositoryStub = Substitute.For<IBookRepository>();
            _rentalService = new RentalService(_bookRepositoryStub,_rentalRepositoryStub);
            DBAuthors.AuthorDB.Clear();
            DBAuthors.AuthorDB.Add(new Author("testFirstName", "testLastName"));
            DBBooks.ListofBooks.Clear();
            DBRentals.DBRental.Clear();
            RentalDTO.rentalCounter = 0;
            DBBooks.ListofBooks.Add(new Book()
            {
                AuthorId = "0",
                BookTitle = "test",
                Isbn = "isbnTest",
                BookIsRentable = true
            });
            DBUsers.UsersInLibrary.Clear();
            DBUsers.UsersInLibrary.Add(new User() { FirstName = "testUser", Birthdate = new DateTime(1987, 5, 21), IdentificationNumber = "LP_21051987", Email = "xx@hotmail.com" });
            _bookRepositoryStub.GetBookByIsbn("isbnTest").Returns(DBBooks.ListofBooks);

        }

        [Fact]
        public void GivenRentalService_WhenRentABook_ThenRentalRepositoryReceiveCallRentABook()
        {
            Initialize_RentalServiceTest();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTest" };

            //when
            _rentalService.RentABook(testRental);

            //then
            _rentalRepositoryStub.Received().AddRentalToDB(testRental);
        }

        [Fact]
        public void GivenRentalService_WhenRentABookNotRentable_ThenReturnNull()
        {
            Initialize_RentalServiceTest();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTest" };
            DBBooks.ListofBooks[0].BookIsRentable = false;

            //when
            _rentalService.RentABook(testRental);

            //then
            Assert.Null(_rentalService.RentABook(testRental));
        }

        [Fact]
        public void GivenRentalService_WhenRentABookThatNotExistInLibrary_ThenReturnNull()
        {
            Initialize_RentalServiceTest();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTestFAKE" };

            //when
            _rentalService.RentABook(testRental);

            //then
            Assert.Null(_rentalService.RentABook(testRental));
        }

        [Fact]
        public void GivenRentalService_WhenReturnARentedBook_ThenReturnRental()
        {
            Initialize_RentalServiceTest();
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTest", RentalId = "0" };
            _rentalService.RentABook(testRental);
            _rentalRepositoryStub.GetAllRentals().Returns(new System.Collections.Generic.List<Rental> { testRental });
            _rentalRepositoryStub.ReturnRentalBook(testRental).Returns(testRental);

            //when
             Rental expected = _rentalService.ReturnRentalBook(testRental, 0);

            //then
            Assert.Equal("LP_21051987", expected.UserIdNumber);
        }
    }
}
