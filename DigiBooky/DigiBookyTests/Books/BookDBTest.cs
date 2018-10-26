using Domain.Authors;
using Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DigiBookyTests.Books
{
    public class DBBookRepositoryTests
    {
        [Fact]
        public void GivenBookDB_WhenGetAllBooks_ThenReturnFullDatabase()
        {
            DBBookRepository dBBooks = new DBBookRepository();
            Random red = new Random();
            Author[] authorList = new Author[]
            {
                new Author("Jef", "Depaepe"),
                new Author("Jos", "Schuurlink"),
                new Author("Guido", "Gazelle")
            };
            for (int bookCount = 1; bookCount < 50; bookCount++)
            {
                DBBooks.ListofBooks.Add(new Book { BookTitle = $"BookTitle{bookCount}", Author = authorList[red.Next(0, 3)], Isbn = "isbn" + bookCount.ToString() });
            }
            
            Assert.Equal(49, dBBooks.GetAllBooks().Count());
        }

    }
}
