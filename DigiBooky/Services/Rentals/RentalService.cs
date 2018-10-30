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

        public List<Rental> GetAllRentals()
        {
            return _rentalRepository.GetAllRentals();
        }

        public Rental GetRentalBasedOnId(int id)
        {
            return _rentalRepository.GetRentalBasedOnId(id);
        }

        public bool IsRentalReturnedOnTime(DateTime endDate)
        {
            return endDate > DateTime.Today;
        }

        public Rental RentABook(Rental rental)
        {
            var book = _bookRepository.GetBookByIsbn(rental.Isbn).SingleOrDefault(bookToFind => bookToFind.Isbn == rental.Isbn);
            if (book != null && book.BookIsRentable == true)
            {
                book.BookIsRentable = false;
                _rentalRepository.AddRentalToDB(rental);
                return rental;

            }
            return null;
        }

        public Rental ReturnRentalBook(int id)
        {
            var rentalToReturn = _rentalRepository.GetRentalBasedOnId(id);
            if (rentalToReturn != null)
            {
                return _rentalRepository.ReturnRentalBook(rentalToReturn);
            }
            return null;
        }
    }
}
