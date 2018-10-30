using Digibooky_domain.Rentals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky_services.Rentals
{
    public interface IRentalService
    {
        Rental RentABook(Rental rental);
        List<Rental> GetAllRentals();
        Rental ReturnRentalBook(int id);
        Rental GetRentalBasedOnId(int id);
        bool IsRentalReturnedOnTime(DateTime endDate);
    }
}
