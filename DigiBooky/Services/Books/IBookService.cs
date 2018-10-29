using System;
using System.Collections.Generic;
using System.Text;
using Digibooky_domain.Books;

namespace Digibooky_services.Books
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookByIsdn(string isbn);
        Book ShowDetailsOfBook(int id);
    }
}
