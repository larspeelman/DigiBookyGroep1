using Domain.Books;
using Domain.Rentals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly IDBBookRepository _bookRepository;


        public Rental RentABook(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
