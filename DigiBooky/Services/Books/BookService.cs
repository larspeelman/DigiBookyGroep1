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

        public List<Func<Book, bool>> CreateDelegates(string isbn=null, string title=null, string author=null)
        {
                List<Func<Book, bool>> delegateFuncs = new List<Func<Book, bool>>();
                if (!string.IsNullOrEmpty(isbn))
                    delegateFuncs.Add(delegate (Book bk) { return bk.Isbn.Contains(isbn); });
                if (!string.IsNullOrEmpty(title))
                    delegateFuncs.Add(delegate (Book bk) { return bk.BookTitle.ToLower().Contains(title.ToLower()); });
                if (!string.IsNullOrEmpty(author))
                    delegateFuncs.Add(delegate (Book bk) { return string.Concat(bk.Author.FirstName, bk.Author.LastName).ToLower().Contains(author.ToLower()); });
                return delegateFuncs;
        }
    }
}
