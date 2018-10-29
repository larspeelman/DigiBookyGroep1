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
        public RentalServiceTest()
        {
            _rentalRepositoryStub = Substitute.For<IRentalRepository>();
            _bookRepositoryStub = Substitute.For<IBookRepository>();
            _rentalService = new RentalService(_bookRepositoryStub,_rentalRepositoryStub);
            DBAuthors.AuthorDB.Add(new Author("testFirstName", "testLastName"));
            DBBooks.ListofBooks.Add(new Book()
            {
                AuthorId = "0",
                BookTitle = "test",
                Isbn = "isbnTest",
                BookIsRentable = true
            });
            DBUsers.UsersInLibrary.Add(new User() { FirstName = "testUser", Birthdate = new DateTime(1987, 5, 21), IdentificationNumber = "LP_21051987", Email = "xx@hotmail.com" });

        }

        [Fact]
        public void GivenRentalService_WhenRentABook_ThenRentalRepositoryReceiveCallRentABook()
        {
            //Given
            Rental testRental = new Rental() { UserId = "LP_21051987", Isbn = "isbnTest" };
            _bookRepositoryStub.GetBookByIsbn("isbnTest").Returns(DBBooks.ListofBooks);

            //when
            _rentalService.RentABook(testRental);

            //then
            _rentalRepositoryStub.Received().AddRentalToDB(testRental);
        }

        [Fact]
        public void GivenRentalService_WhenRentABookNotRentable_ThenReturnNull()
        {
            //Given
            Rental testRental = new Rental() { UserId = "LP_21051987", Isbn = "isbnTest" };
            DBBooks.ListofBooks[0].BookIsRentable = false;
            _bookRepositoryStub.GetBookByIsbn("isbnTest").Returns(DBBooks.ListofBooks);

            //when
            _rentalService.RentABook(testRental);

            //then
            Assert.Null(_rentalService.RentABook(testRental));
        }
    }
}
