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
            BookMapper bookMapper= new BookMapper();
            Book book = new Book("test","ISD",new Author("Test","Test"));
            Assert.IsType<BookDTO>(bookMapper.BooksMapper(book));
        }

    }
}
