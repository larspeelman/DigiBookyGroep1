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
            IDBBookRepository dbBookstub = Substitute.For<IDBBookRepository>();
            BookService bookService = new BookService(dbBookstub);
            bookService.GetAllBooks();
            dbBookstub.Received().GetAllBooks();
        }

        [Fact]
        public void GivenBookService_WhenGetAllBooks_ThenReturnListofbooks()
        {
            IDBBookRepository dbBookstub = Substitute.For<IDBBookRepository>();
            BookService bookService = new BookService(dbBookstub);
            IEnumerable<Book> testList = new List<Book>();
            dbBookstub.GetAllBooks().Returns(testList);

            Assert.Equal(testList, bookService.GetAllBooks());
        }

        [Fact]
        public void GivenBookService_WhenShowDetailsOfBook_ThenReturnBookById()
        {
            IDBBookRepository dbBookstub = Substitute.For<IDBBookRepository>();
            BookService bookService = new BookService(dbBookstub);
            bookService.ShowDetailsOfBook(1);
            Book testBook = new Book { Id = 1, BookTitle = "test" };


            dbBookstub.Received().GetBookById(1);

            
        }
    }
}
