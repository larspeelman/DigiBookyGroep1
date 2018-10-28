using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rentals
{
    public interface IDBRentalRepository
    {
        void AddRentalToDB(Rental bookToRent);
    }
}
