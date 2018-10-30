using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Digibooky_services.Books;
using NSubstitute;
using Xunit;

namespace Digibooky_services_UnitTests
{
    public class BookServiceTest
    {
        public BookServiceTest()
        {
            DBAuthors.AuthorDB.Clear();
            DBBooks.ListofBooks.Clear();
        }

        [Fact]
        public void GivenBookService_WhenGetAllBooks_ThenDBBooksReceiceCall()
        {
            IBookRepository dbBookstub = Substitute.For<IBookRepository>();
            BookService bookService = new BookService(dbBookstub);
            bookService.GetAllBooks();
            dbBookstub.Received().GetAllBooks();
        }

        [Fact]
        public void GivenBookService_WhenGetAllBooks_ThenReturnListofbooks()
        {
            IBookRepository dbBookstub = Substitute.For<IBookRepository>();
            BookService bookService = new BookService(dbBookstub);
            IEnumerable<Book> testList = new List<Book>();
            dbBookstub.GetAllBooks().Returns(testList);

            Assert.Equal(testList, bookService.GetAllBooks());
        }

        [Fact]
        public void GivenBookService_WhenShowDetailsOfBook_ThenReturnBookById()
        {
            IBookRepository dbBookstub = Substitute.For<IBookRepository>();
            BookService bookService = new BookService(dbBookstub);
            bookService.ShowDetailsOfBook(1);
            Book testBook = new Book { Id = 1, BookTitle = "test" };
            dbBookstub.Received().GetBookById(1);         
        }


        [Fact]
        public void GivenBookService_WhenSearchForAuthor_ThenReturnListofbooksThatContainsAuthor()
        {
            List<Author> authorList = new List<Author>
            {
                new Author("Jef", "Depaepe"){Id = "1"},
                new Author("Jos", "Schuurlink"){Id = "2"},
                new Author("Guido", "Gazelle"){Id = "3"},
            };
            DBAuthors.AuthorDB = authorList;
            DBBooks.ListofBooks.Add(new Book { BookTitle = $"BookTitle1", AuthorId = "1", Isbn = "isbn1" });
            DBBooks.ListofBooks.Add(new Book { BookTitle = $"BookTitle2", AuthorId = "2", Isbn = "isbn2" });
            DBBooks.ListofBooks.Add(new Book { BookTitle = $"BookTitle3", AuthorId = "2", Isbn = "isbn2" });

            IBookRepository dbBookstub = Substitute.For<IBookRepository>();
            BookService bookService = new BookService(dbBookstub);
            IEnumerable<Book> testList = DBBooks.ListofBooks;

            List<Func<Book, bool>> delegateFuncs = bookService.CreateDelegates(author: "schuur");
            
            Assert.Single(delegateFuncs);
            dbBookstub.GetAllBooks().Returns(testList);
            Assert.Equal(2,bookService.GetBookByFilter(delegateFuncs).Count());
        }

        [Fact]
        public void GivenBookService_WhenCallCreateDelegates_ThenReturnNumberofDelegatesToSearch()
        {
            IBookRepository dbBookstub = Substitute.For<IBookRepository>();
            BookService bookService = new BookService(dbBookstub);

            Assert.Empty(bookService.CreateDelegates());
            Assert.Single(bookService.CreateDelegates(author: "schuur"));
            Assert.Equal(2, bookService.CreateDelegates(author: "schuur", title: "title").Count());
            Assert.Equal(3, bookService.CreateDelegates(author: "schuur", title: "title", isbn: "isbn").Count());
        }

    }
}
