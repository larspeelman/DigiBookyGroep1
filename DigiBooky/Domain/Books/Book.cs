using System;
using System.Collections.Generic;
using System.Text;
using Domain.Authors;

namespace Domain.Books
{
    public class Book
    {
        public static int CounterOfBooks = 0;
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string Isbn { get; set; }
        public Author Author { get; set; }

        public Book()
        {
            Id = CounterOfBooks;
            CounterOfBooks++;
        }

        public override bool Equals(object obj)
        {
            var book = obj as Book;
            return book != null &&
                   Id == book.Id &&
                   Isbn == book.Isbn;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Isbn);
        }
    }
}
