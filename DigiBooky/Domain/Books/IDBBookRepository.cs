using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky_domain.Books
{
    public interface IDBBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        IEnumerable<Book> GetBookByIsbn(string isbn);
    }
}
