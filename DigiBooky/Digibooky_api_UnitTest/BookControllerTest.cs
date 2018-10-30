using System;
using System.Collections.Generic;
using System.Text;
using Digibooky_api.Controllers;
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Books;
using Digibooky_services.Books;
using NSubstitute;
using Xunit;

namespace DigiBooky_api_UnitTests
{
    public class BookControllerTest
    {
        [Fact]
        public void GivenBookController_WhenAskListofBooks_ThenShouldEnterMethodInService()
        {
            IBookService bookService = Substitute.For<IBookService>();
            IBookMapper bookMapper = Substitute.For<IBookMapper>();

            BookController bookSut = new BookController(bookService, bookMapper);
            List<Func<Book, bool>> delegateFuncs = new List<Func<Book, bool>>();

            bookService.CreateDelegates().Returns(delegateFuncs);
            bookSut.GetAllBooks();
            bookService.Received().GetBookByFilter(delegateFuncs);
        }

        [Fact]
        public void GivenBookController_WhenAskListofBooksWithIsbN_ThenShouldEnterMethodInService()
        {
            List<Func<Book, bool>> delegateFuncs = new List<Func<Book, bool>>();
            delegateFuncs.Add(delegate (Book bk) { return bk.Isbn.Contains("5"); });

            IBookService bookService = Substitute.For<IBookService>();
            IBookMapper bookMapper = Substitute.For<IBookMapper>();

            BookController bookSut = new BookController(bookService, bookMapper);

            bookService.CreateDelegates(isbn: "5").Returns(delegateFuncs);
            bookSut.GetAllBooks(isbn:"5");
            bookService.Received().GetBookByFilter(delegateFuncs);
        }

        [Fact]
        public void GivenBookController_WhenAskListofBooksWithAuthor_ThenShouldEnterMethodInService()
        {
            IBookService bookService = Substitute.For<IBookService>();
            IBookMapper bookMapper = Substitute.For<IBookMapper>();

            BookController bookSut = new BookController(bookService, bookMapper);
            List<Func<Book, bool>> delegateFuncs = new List<Func<Book, bool>>();
            delegateFuncs.Add(delegate (Book bk) { return string.Concat(bk.Author.FirstName, bk.Author.LastName).ToLower().Contains("author"); });

            bookService.CreateDelegates(author: "Author").Returns(delegateFuncs);
            bookSut.GetAllBooks(author: "Author");
            bookService.Received().GetBookByFilter(delegateFuncs);
        }

        [Fact]
        public void GivenBookController_WhenAskListofBooksWithTitle_ThenShouldEnterMethodInService()
        {
            IBookService bookService = Substitute.For<IBookService>();
            IBookMapper bookMapper = Substitute.For<IBookMapper>();

            BookController bookSut = new BookController(bookService, bookMapper);
            List<Func<Book, bool>> delegateFuncs = new List<Func<Book, bool>>();
            delegateFuncs.Add(delegate (Book bk) { return bk.BookTitle.ToLower().Contains("title"); });

            bookService.CreateDelegates(title: "Title").Returns(delegateFuncs);
            bookSut.GetAllBooks(title: "Title");
            bookService.Received().GetBookByFilter(delegateFuncs);
        }

        [Fact]
        public void GivenBookController_WhenShowDetailsOFBook_ThenShouldEnterMEthodOInService()
        {
            IBookService bookService = Substitute.For<IBookService>();
            IBookMapper bookMapper = Substitute.For<IBookMapper>();
            BookController bookController = new BookController(bookService, bookMapper);
            BookDTO testBook = new BookDTO();


            bookController.ShowDetailsOfBook(1);

            bookService.Received().ShowDetailsOfBook(1);
        }
    }
}
