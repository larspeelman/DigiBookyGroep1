using Domain.Books;
using Domain.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly IDBBookRepository _bookRepository;
        private readonly IDBRentalRepository _rentalRepository;

        public RentalService(IDBBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Rental RentABook(Rental rental)
        {
            var book = _bookRepository.GetBookByIsbn(rental.Isbn).SingleOrDefault(bookToFind => bookToFind.Isbn == rental.Isbn);
            if (book.BookIsRentable == true)
            {
                rental.EndDate = SetDueDate();
                book.BookIsRentable = false;
                _rentalRepository.AddRentalToDB(rental);
                
               
            }
            return rental;
        }

        private DateTime SetDueDate()
        {
            var dayToday = DateTime.Today;
            return dayToday.AddDays(21);

        }

       
    }
}
