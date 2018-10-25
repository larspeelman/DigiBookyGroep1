using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Books
{
    public interface IDBBooks
    {
        IEnumerable<Book> GetAllBooks();
    }
}
