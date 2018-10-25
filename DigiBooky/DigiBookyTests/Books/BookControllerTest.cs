using System;
using System.Collections.Generic;
using System.Text;
using Api.Controllers;
using Api.DTO;
using Api.Helper;
using NSubstitute;
using Services.Books;
using Xunit;

namespace DigiBookyTests.Books
{
    public class BookControllerTest
    {
        [Fact]
        public void GivenBookController_WhenAskListofBooks_ThenShouldEnterMethodInService()
        {
            IBookService bookService = Substitute.For<IBookService>();
            IBookMapper bookMapper = Substitute.For<IBookMapper>();

            BookController bookSut = new BookController(bookService, bookMapper);

            bookSut.GetAllBooks();
            bookService.Received().GetAllBooks();

        }

        [Fact]
        public void GivenBookController_WhenShowDetailsOFBook_ThenShouldEnterMEthodOInService()
        {
            IBookService bookService = Substitute.For<IBookService>();
            IBookMapper bookMapper = Substitute.For<IBookMapper>();
            BookController bookController = new BookController(bookService, bookMapper);
            BookDTO testBook = new BookDTO();
            

            bookController.ShowDetailsOfBook(testBook);


        }

    }
}
