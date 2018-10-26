using System;
using System.Collections.Generic;
using System.Text;
using Domain.Authors;

namespace Domain.Books
{
    public class DBBooks: IDBBooks
    {
        private readonly List<Book> _ListofBooks;

        public DBBooks()
        {
            _ListofBooks = new List<Book>();
            InitBooks();
        }

        private void InitBooks()
        {
            Random red = new Random();
            Author[] authorList = new Author[]
            {
                new Author("Jef", "Depaepe"),
                new Author("Jos", "Schuurlink"),
                new Author("Guido", "Gazelle")
            };
            for (int bookCount = 1; bookCount < 50; bookCount++)
            {
                _ListofBooks.Add(new Book { BookTitle = $"BookTitle{bookCount}", Author = authorList[red.Next(0, 3)], Isbn="isbn" + bookCount.ToString()});
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _ListofBooks;
        }

        public Book GetBookById(int id)
        {
            return _ListofBooks.Find(book => book.Id == id);
        }

        public IEnumerable<Book> GetBookByIsbn()
        {
            throw new NotImplementedException();
        }
    }
}
