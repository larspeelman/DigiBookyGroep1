using Domain.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Books
{
    class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
    }
}
