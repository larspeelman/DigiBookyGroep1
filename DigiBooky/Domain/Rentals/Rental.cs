using Domain.Books;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Rentals
{
    public class Rental
    {

        public Book Book => ReturnBookForRental(); 
        public string UserId { get; set; }
        public DateTime EndDate { get; set; }
        public User User =>ReturnUserForThisRental();
        public string RentalId {get; set;}
        private static int rentalCounter;
        public string Isbn { get; set; }

        public Rental()
        {
            RentalId = rentalCounter.ToString();
            rentalCounter++;
        }

        private User ReturnUserForThisRental()
        {
            return DBUsers.UsersInLibrary.SingleOrDefault(user => user.IdentificationNumber == UserId);
        }

        private Book ReturnBookForRental()
        {
            return DBBooks.ListofBooks.SingleOrDefault(book => book.Isbn == Isbn);
        }

        public override bool Equals(object obj)
        {
            var rental = obj as Rental;
            return rental != null &&
                   EqualityComparer<Book>.Default.Equals(Book, rental.Book) &&
                   UserId == rental.UserId &&
                   EndDate == rental.EndDate &&
                   EqualityComparer<User>.Default.Equals(User, rental.User) &&
                   RentalId == rental.RentalId &&
                   Isbn == rental.Isbn;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Book, UserId, EndDate, User, RentalId, Isbn);
        }
    }


}
