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
        IEnumerable<Book> GetBookByTitle(string title);
        Book ShowDetailsOfBook(int id);
        IEnumerable<Book> GetBookByAuthor(string author);
        //IEnumerable<Book> GetBookBy(string isbn, string title, string author);
        IEnumerable<Book> GetBookByFilter(List<Func<Book, bool>> delegateFuncs);
        Book RegisterNewBook(Book newBook);
    }
}
