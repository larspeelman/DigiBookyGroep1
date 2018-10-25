using System;
using System.Collections.Generic;
using System.Text;
using Domain.Authors;

namespace Domain.Books
{
    public class Book
    {
        public string Id { get; set; }
        public string BookTitle { get; set; }
        public string Isbn { get; set; }
        public Author Author { get; set; }

        public Book(string bookTitle, string isbn, Author author)
        {
            Id = Guid.NewGuid().ToString();
            BookTitle = bookTitle;
            Isbn = isbn;
            Author = author;
        }

    }
}
