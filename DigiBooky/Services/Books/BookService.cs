using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Books;

namespace Services.Books
{
    public class BookService: IBookService
    {
        private readonly DBBooks _dbBook;

        public BookService()
        {
            _dbBook = new DBBooks();
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _dbBook.GetAllBooks();
        }

        public Book GetBookByIsdn(string isbn)
        {
            return _dbBook.GetAllBooks().SingleOrDefault(bk => bk.Isbn.Contains(isbn));
        }
    }
}
