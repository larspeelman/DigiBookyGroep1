using System;
using System.Collections.Generic;
using System.Text;
using Digibooky_domain.Books;

namespace Digibooky_services.Books
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBookByIsbn(string isbn);
        Book ShowDetailsOfBook(int id);
        IEnumerable<Book> GetBookByFilter(List<Func<Book, bool>> delegateFuncs);
        List<Func<Book, bool>> CreateDelegates(string isbn=null, string title=null, string author=null);
    }
}
