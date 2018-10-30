
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky_domain.Rentals
{
    public interface IRentalRepository
    {
        void AddRentalToDB(Rental bookToRent);
        List<Rental> GetAllRentals();
        Rental ReturnRentalBook(Rental rentalToReturn);
    }
}
