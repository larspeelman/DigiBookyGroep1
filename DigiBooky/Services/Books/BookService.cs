using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Digibooky_domain.Books;

namespace Digibooky_services.Books
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _IDBBookRepository;

        public BookService(IBookRepository dbBook)
        {
            _IDBBookRepository = dbBook;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _IDBBookRepository.GetAllBooks();
        }

        public IEnumerable<Book> GetBookByIsbn(string isbn)
        {
            return _IDBBookRepository.GetAllBooks().Where(bk => bk.Isbn.Contains(isbn));
        }

        public Book ShowDetailsOfBook(int id)
        {
            return _IDBBookRepository.GetBookById(id);
        }

        public IEnumerable<Book> GetBookByTitle(string title)
        {
            return _IDBBookRepository.GetAllBooks().Where(book => book.BookTitle.Contains(title));
        }

        public IEnumerable<Book> GetBookByAuthor(string author)
        {
            return _IDBBookRepository.GetAllBooks().Where(book => string.Concat(book.Author.FirstName, book.Author.LastName).Contains(author));
        }

        public IEnumerable<Book> GetBookByFilter(List<Func<Book, bool>> delegateFuncs)
        {
            IEnumerable<Book> result = _IDBBookRepository.GetAllBooks();
            foreach (Func<Book, bool> delFunc in delegateFuncs)
            {
                if (result.Any())
                {
                    result = result.Where(delFunc);
                }
            }
            return result;
        }

        //public IEnumerable<Book> GetBookBy(string isbn, string title, string author)
        //{
        //    IEnumerable<Book> result = _IDBBookRepository.GetAllBooks();
        //    if (!string.IsNullOrEmpty(isbn))
        //    {
        //        result = result.Where(bk => bk.Isbn.Contains(isbn));
        //    }
        //    if (result.Any() && !string.IsNullOrEmpty(title))
        //    {
        //        result = result.Where(bk => bk.BookTitle.Contains(title));
        //    }
        //    if (result.Any() && !string.IsNullOrEmpty(author))
        //    {
        //        result = result.Where(bk => string.Concat(bk.Author.FirstName, bk.Author.LastName).Contains(author));
        //    }
        //    return result;
        //}
    }
}
