using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rentals
{
    interface IDBRentalRepository
    {
        void AddRentalToDB(Rental bookToRent);
    }
}
