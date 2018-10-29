using System;
using System.Collections.Generic;
using System.Text;
using Digibooky_api.DTO;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using NSubstitute;
using Xunit;

namespace DigiBooky_api_UnitTests
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
