
using Digibooky_api.DTO;
using Digibooky_domain.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky_api.Helper
{
    public class RentalMapper : IRentalMapper
    {

        public RentalDTO FromRentalToRentalDTO(Rental rental)
        {
            return new RentalDTO
            {
                Isbn = rental.Isbn,
                UniqueRentalId = rental.RentalId,
                UserIdNumber = rental.UserIdNumber,
                EndDate = rental.EndDate
            };
        }

        public Rental FromRentalDTOToRental(RentalDTO rentalDTO)
        {
            return new Rental
            {
                Isbn = rentalDTO.Isbn,
                RentalId = rentalDTO.UniqueRentalId,
                UserIdNumber = rentalDTO.UserIdNumber,
                EndDate = rentalDTO.EndDate
            };
        }
    }
}
