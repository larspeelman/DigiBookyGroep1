using Digibooky_domain.Books;
using Digibooky_domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Digibooky_domain.Rentals
{
    public class Rental
    {

        public string UserIdNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public string RentalId {get; set;}
        public string Isbn { get; set; }
        public Book Book => ReturnBookForRental(); 
        public User User =>ReturnUserForThisRental();
        public static int rentalCounter;


        public Rental()
        {
            RentalId = rentalCounter.ToString();
            rentalCounter++;
            EndDate = SetDueDate();
        }

        private User ReturnUserForThisRental()
        {
            return DBUsers.UsersInLibrary.SingleOrDefault(user => user.IdentificationNumber == UserIdNumber);
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
                   UserIdNumber == rental.UserIdNumber &&
                   EndDate == rental.EndDate &&
                   EqualityComparer<User>.Default.Equals(User, rental.User) &&
                   RentalId == rental.RentalId &&
                   Isbn == rental.Isbn;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Book, UserIdNumber, EndDate, User, RentalId, Isbn);
        }

        private DateTime SetDueDate()
        {
            var dayToday = DateTime.Today;
            return dayToday.AddDays(21);

        }
    }


}
