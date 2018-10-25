using Domain.Books;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rentals
{
    class Rental
    {
        public Book Book { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
    }
}
