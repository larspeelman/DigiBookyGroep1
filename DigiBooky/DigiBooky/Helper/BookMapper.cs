using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helper;
using Domain.Books;

namespace Api.DTO
{
    public class BookMapper: IBookMapper
    {
        public BookDTO BooksMapper(Book book)
        {
            BookDTO bookDto = new BookDTO
            {
                BookTitle = book.BookTitle,
                Isbn = book.Isbn,
                AuthorName = string.Concat(book.Author.FirstName.TrimEnd(), " ", book.Author.LastName.TrimEnd())
            };
            return bookDto;
        }
    }
}
