using System;
using System.Collections.Generic;
using System.Text;
using Domain.Books;
using NSubstitute;
using Services.Books;
using Xunit;

namespace DigiBookyTests.Books
{
    public class BookServiceTest
    {
        [Fact]
        public void GivenBookService_WhenGetAllBooks_ThenDBBooksReceiceCall()
        {
            IDBBooks dbBookstub = Substitute.For<IDBBooks>();
            BookService bookService = new BookService(dbBookstub);
            bookService.GetAllBooks();
            dbBookstub.Received().GetAllBooks();
        }

        [Fact]
        public void GivenBookService_WhenGetAllBooks_ThenReturnListofbooks()
        {
            IDBBooks dbBookstub = Substitute.For<IDBBooks>();
            BookService bookService = new BookService(dbBookstub);
            IEnumerable<Book> testList = new List<Book>();
            dbBookstub.GetAllBooks().Returns(testList);

            Assert.Equal(testList, bookService.GetAllBooks());
        }
    }
}
