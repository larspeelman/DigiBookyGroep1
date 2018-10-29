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
            Random red = new Random();
            Author[] authorList = new Author[]
            {
                new Author("Jef", "Depaepe"),
                new Author("Jos", "Schuurlink"),
                new Author("Guido", "Gazelle")
            };
            for (int bookCount = 1; bookCount < 50; bookCount++)
            {
                DBBooks.ListofBooks.Add(new Book { BookTitle = $"BookTitle{bookCount}", AuthorId = red.Next(0, 3).ToString(), Isbn = "isbn" + bookCount.ToString() });
            }
            
            Assert.Equal(49, dBBooks.GetAllBooks().Count());
        }

    }
}
