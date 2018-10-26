using Api.DTO;
using Domain.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helper
{
    public interface IRentalMapper
    {
        RentalDTO FromRentalToRentalDTO(Rental rental);
        Rental FromRentalDTOToRental(RentalDTO rentalDTO);
    }
}
