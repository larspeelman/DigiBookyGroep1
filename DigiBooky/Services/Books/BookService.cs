using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Books;

namespace Services.Books
{
    public class BookService: IBookService
    {
        private readonly IDBBooks _dbBook;

        public BookService(IDBBooks dbBook)
        {
            _dbBook = dbBook;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _dbBook.GetAllBooks();
        }

        public Book GetBookByIsdn(string isbn)
        {
            return _dbBook.GetAllBooks().SingleOrDefault(bk => bk.Isbn.Contains(isbn));
        }

        public Book ShowDetailsOfBook(int id)
        {
            return _dbBook.GetBookById(id);
        }
    }
}
