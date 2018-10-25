using System;
using System.Collections.Generic;
using System.Text;
using Domain.Books;

namespace Services.Books
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookByIsdn(string isbn);
    }
}
