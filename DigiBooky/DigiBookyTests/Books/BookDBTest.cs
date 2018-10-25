using Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DigiBookyTests.Books
{
    public class BookDBTest
    {
        [Fact]
        public void GivenBookDB_WhenGetAllBooks_ThenReturnFullDatabase()
        {
            DBBooks dBBooks = new DBBooks();
            Assert.Equal(49, dBBooks.GetAllBooks().Count());
        }

    }
}
