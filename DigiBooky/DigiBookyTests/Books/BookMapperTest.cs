using System;
using System.Collections.Generic;
using System.Text;
using Api.DTO;
using Domain.Authors;
using Domain.Books;
using Xunit;

namespace DigiBookyTests.Books
{
    public class BookMapperTest
    {
        [Fact]
        public void GivenBookMapper_WhenMapToBookDto_ThenReturnListWithBookDto()
        {
            DBAuthors.AuthorDB = FakedataAuthor();
            BookMapper bookMapper= new BookMapper();
            Book book = new Book{ BookTitle = "test", Isbn = "5", AuthorId ="1" };
            Assert.IsType<BookDTO>(bookMapper.BooksMapper(book));
        }

        public List<Author> FakedataAuthor()
        {
            List<Author> authorList = new List<Author>
            {
                new Author("Jef", "Depaepe"),
                new Author("Jos", "Schuurlink"),
                new Author("Guido", "Gazelle"),
            };
            return authorList;
        }

    }
}
