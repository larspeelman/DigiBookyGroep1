using Digibooky_domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky_domain.Books
{
    public class BookRepository :IBookRepository
    {

        public IEnumerable<Book> GetAllBooks()
        {
            return DBBooks.ListofBooks;
        }

        public Book GetBookById(int id)
        {
            return DBBooks.ListofBooks.Find(book => book.Id == id);
        }

        public IEnumerable<Book> GetBookByIsbn(string isbn)
        {
            return DBBooks.ListofBooks.Where(book => book.Isbn == isbn);
        }
    }
}
