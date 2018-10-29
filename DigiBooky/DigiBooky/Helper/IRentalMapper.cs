
using Digibooky_api.DTO;
using Digibooky_domain.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky_api.Helper
{
    public interface IRentalMapper
    {
        RentalDTO FromRentalToRentalDTO(Rental rental);
        Rental FromRentalDTOToRental(RentalDTO rentalDTO);
    }
}
