
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky_domain.Rentals
{
    public class RentalRepository : IRentalRepository
    {
        public void AddRentalToDB(Rental bookToRent)
        {
            DBRentals.DBRental.Add(bookToRent);
        }
    }
}
