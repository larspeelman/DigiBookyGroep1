using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Digibooky_domain_UnitTests.Books
{
    public class DBBookRepositoryTests
    {
        [Fact]
        public void GivenBookDB_WhenGetAllBooks_ThenReturnFullDatabase()
        {
            BookRepository dBBooks = new BookRepository();
            Book.CounterOfBooks = 0;
            Author.IdCounter = 0;
            ClearAllDataBases();
            
            //DBAuthors.AuthorDB.Add(new Author("test", "test") { Id = "0" });

            //DBBooks.ListofBooks.Add(new Book() { BookTitle = "test", Isbn = "isbnTest", AuthorId = "0"});   
            
            Assert.Empty(dBBooks.GetAllBooks());
            ClearAllDataBases();
        }

        private void ClearAllDataBases()
        {
            DBBooks.ListofBooks = null;
            DBBooks.ListofBooks = new List<Book>();
            DBAuthors.AuthorDB = null;
            DBAuthors.AuthorDB = new List<Author>();
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
