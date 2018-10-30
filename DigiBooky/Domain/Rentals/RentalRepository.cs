
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky_domain.Rentals
{
    public class RentalRepository : IRentalRepository
    {

        public void AddRentalToDB(Rental bookToRent)
        {
            DBRentals.DBRental.Add(bookToRent);
        }

        public List<Rental> GetAllRentals()
        {
            return DBRentals.DBRental;
        }

        public Rental GetRentalBasedOnId(int id)
        {
            return DBRentals.DBRental.SingleOrDefault(rental => rental.RentalId == id.ToString());
        }

        public Rental ReturnRentalBook(Rental rentalToReturn)
        {
            if (rentalToReturn.Book.BookIsRentable == false)
            {
                rentalToReturn.Book.BookIsRentable = true;
                DBRentals.DBRental.Remove(rentalToReturn);
                
                return rentalToReturn;
            }
            return null;
        }
    }
}
