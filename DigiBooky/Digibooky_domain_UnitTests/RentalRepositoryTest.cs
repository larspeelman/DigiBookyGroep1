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
        public RentalRepositoryTest()
        {
            _rentalRepository = new RentalRepository();
            DBAuthors.AuthorDB.Add(new Author("testFirstName", "testLastName"));
            DBBooks.ListofBooks.Add(new Book()
            {
                AuthorId = "0",
                BookTitle = "test",
                Isbn = "isbnTest",
            });
            DBUsers.UsersInLibrary.Add(new User() { FirstName = "testUser", Birthdate = new DateTime(1987, 5, 21), IdentificationNumber = "LP_21051987", Email="xx@hotmail.com" });
        }

        [Fact]
        public void GivenRentalRepository_WhenAddRentalToDB_ThenNewRentalInRentalDB()
        {
            //Given
            Rental testRental = new Rental() { UserIdNumber = "LP_21051987", Isbn = "isbnTest" };

            //When
            _rentalRepository.AddRentalToDB(testRental);

            //Then
            Assert.Contains(testRental, DBRentals.DBRental);
        }
    }
}
