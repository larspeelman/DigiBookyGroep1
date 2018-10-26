using Domain.Rentals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Rentals
{
    public interface IRentalService
    {
        Rental RentABook(Rental rental);
    }
}
