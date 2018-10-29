
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky_domain.Rentals
{
    public interface IDBRentalRepository
    {
        void AddRentalToDB(Rental bookToRent);
    }
}
