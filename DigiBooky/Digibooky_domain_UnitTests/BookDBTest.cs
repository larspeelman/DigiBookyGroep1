using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Digibooky_domain_UnitTests
{
    public class DBBookRepositoryTests
    {
        [Fact]
        public void GivenBookDB_WhenGetAllBooks_ThenReturnFullDatabase()
        {
            BookRepository dBBooks = new BookRepository();
            DBBooks.ListofBooks.Clear();
            DBAuthors.AuthorDB.Clear();
            Book.CounterOfBooks = 0;
            Author.IdCounter = 0;

            Author[] authorList = new Author[]
            {
                new Author("Jef", "Depaepe"),
                new Author("Jos", "Schuurlink"),
                new Author("Guido", "Gazelle")
            };
            DBAuthors.AuthorDB = authorList.ToList();

            DBBooks.ListofBooks.Add(new Book() { BookTitle = "test", Isbn = "isbnTest", AuthorId = "0"});   
            
            Assert.NotEmpty(DBBooks.ListofBooks.Where(book => book.Isbn == "isbnTest"));
        }

        //[Fact]
        //public void test()
        //{
        //    BookRepository dBBooks = new BookRepository();

        //    DBBooks.ListofBooks = new List<Book> { new Book { BookTitle = "test", Isbn = "isbnTest", AuthorId = "0" } };

        //    DBBooks.ListofBooks.Clear();
        //    DBAuthors.AuthorDB.Clear();
        //    Book.CounterOfBooks = 0;
        //    Author.IdCounter = 0;

        //    Author[] authorList = new Author[]
        //    {
        //        new Author("Jef", "Depaepe"),
        //        new Author("Jos", "Schuurlink"),
        //        new Author("Guido", "Gazelle")
        //    };

        //    DBAuthors.AuthorDB = authorList.ToList();
        //    DBBooks.ListofBooks.Add(new Book() { BookTitle = "test", Isbn = "isbnTest", AuthorId = "0" });
        //    Assert.NotEmpty(DBBooks.ListofBooks.Where(book => book.Isbn == "isbnTest"));
        //}

    }
}
