using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Books
{
    public class DBBookRepository :IDBBookRepository
    {

        public IEnumerable<Book> GetAllBooks()
        {
            return DBBooks.ListofBooks;
        }

        public Book GetBookById(int id)
        {
            return DBBooks.ListofBooks.Find(book => book.Id == id);
        }

        public IEnumerable<Book> GetBookByIsbn()
        {
            throw new NotImplementedException();
        }
    }
}
