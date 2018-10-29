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
            Random red = new Random();
            Author[] authorList = new Author[]
            {
                new Author("Jef", "Depaepe"){Id="1" },
                new Author("Jos", "Schuurlink"){Id="2" },
                new Author("Guido", "Gazelle"){Id="3" }
            };
            for (int bookCount = 1; bookCount < 50; bookCount++)
            {
                DBBooks.ListofBooks.Add(new Book { BookTitle = $"BookTitle{bookCount}", AuthorId = red.Next(1, 4).ToString(), Isbn = "isbn" + bookCount.ToString() });
            }
            
            Assert.Equal(49, dBBooks.GetAllBooks().Count());
        }

    }
}
