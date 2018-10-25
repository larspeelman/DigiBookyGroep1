using Domain.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rentals
{
    class Rental
    {
        public Book Book { get; set; }
        public DateTime EndDate { get; set; }
    }
}
