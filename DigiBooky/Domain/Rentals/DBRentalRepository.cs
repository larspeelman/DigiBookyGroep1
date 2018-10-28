using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rentals
{
    public class DBRentalRepository : IDBRentalRepository
    {
        public void AddRentalToDB(Rental bookToRent)
        {
            DBRentals.DBRental.Add(bookToRent);
        }
    }
}
