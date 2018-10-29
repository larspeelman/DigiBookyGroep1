using Digibooky_domain.Books;
using Digibooky_domain.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky_services.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IBookRepository bookRepository, IRentalRepository rentalRepository)
        {
            _bookRepository = bookRepository;
            _rentalRepository = rentalRepository;

        }

        public Rental RentABook(Rental rental)
        {
            var book = _bookRepository.GetBookByIsbn(rental.Isbn).SingleOrDefault(bookToFind => bookToFind.Isbn == rental.Isbn);
            if (book.BookIsRentable == true && book != null)
            {
                rental.EndDate = SetDueDate();
                book.BookIsRentable = false;
                _rentalRepository.AddRentalToDB(rental);
                return rental;

            }
            return null;
        }

        private DateTime SetDueDate()
        {
            var dayToday = DateTime.Today;
            return dayToday.AddDays(21);

        }

       
    }
}
