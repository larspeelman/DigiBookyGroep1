using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digibooky_domain.Books;

namespace Digibooky_services.Books
{
    public class BookService: IBookService
    {
        private readonly IDBBookRepository _IDBBookRepository;

        public BookService(IDBBookRepository dbBook)
        {
            _IDBBookRepository = dbBook;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _IDBBookRepository.GetAllBooks();
        }

        public Book GetBookByIsdn(string isbn)
        {
            return _IDBBookRepository.GetAllBooks().SingleOrDefault(bk => bk.Isbn.Contains(isbn));
        }

        public Book ShowDetailsOfBook(int id)
        {
            return _IDBBookRepository.GetBookById(id);
        }
    }
}
