using System;
using System.Collections.Generic;
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
    }
}
