using Digibooky_api.Controllers;
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Digibooky_domain.Rentals;
using Digibooky_domain.Users;
using Digibooky_services.Rentals;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Digibooky_api_UnitTests
{
   public class RentalControllerTest
    {
        private RentalController rentalController;
        private IRentalService rentalServiceStub;
        private IRentalMapper rentalMapperStub;

        private void Initialize_RentalIntegrationTest()
        {
            IRentalRepository rentalRepository = Substitute.For<IRentalRepository>();
            IBookRepository bookRepository = Substitute.For<IBookRepository>();
            rentalMapperStub = Substitute.For<IRentalMapper>();
            rentalServiceStub = Substitute.For<IRentalService>(bookRepository, rentalRepository);
            rentalController = new RentalController(rentalServiceStub, rentalMapperStub);

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

        public void GivenRentalController_WhenRentAExistingBook_ThenReturnRentalDto()
        {
            //Given
            RentalDTO testRentalDTO = new RentalDTO() { UserIdNumber = "LP_21051987", Isbn = "isbnTest" };
            Rental testRental = new Rental();
            rentalMapperStub.FromRentalDTOToRental(testRentalDTO).Returns(testRental);
            rentalServiceStub.RentABook(testRental).Returns(testRental);

            //When
            rentalController.RentABook(testRentalDTO);

            //
            rentalServiceStub.Received().RentABook(testRental);
        }
    }
}
