using Api.DTO;
using Domain.Rentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helper
{
    public class RentalMapper : IRentalMapper
    {

        public RentalDTO FromRentalToRentalDTO(Rental rental)
        {
            return new RentalDTO
            {
                Isbn = rental.Isbn,
                UniqueRentalId = rental.RentalId,
                UserIdNumber = rental.UserId,
                EndDate = rental.EndDate
            };
        }

        public Rental FromRentalDTOToRental(RentalDTO rentalDTO)
        {
            return new Rental
            {
                Isbn = rentalDTO.Isbn,
                RentalId = rentalDTO.UniqueRentalId,
                UserId = rentalDTO.UserIdNumber,
                EndDate = rentalDTO.EndDate
            };
        }
    }
}
