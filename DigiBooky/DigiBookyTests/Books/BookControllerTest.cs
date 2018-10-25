using System;
using System.Collections.Generic;
using System.Text;
using Api.Controllers;
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
            BookController bookSut = new BookController(bookService);

            bookSut.GetAllBooks();
            bookService.Received().GetAllBooks();

        }

    }
}
