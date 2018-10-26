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
            Assert.Equal(49, dBBooks.GetAllBooks().Count());
        }

    }
}
