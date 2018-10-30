using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky_api.Helper;
using Digibooky_domain.Books;

namespace Digibooky_api.DTO
{
    public class BookMapper: IBookMapper
    {
        public BookDTO BooksMapper(Book book)
        {
            BookDTO bookDto = new BookDTO
            {
                BookTitle = book.BookTitle,
                Isbn = book.Isbn,
                AuthorName = string.Concat(book.Author.FirstName.TrimEnd(), " ", book.Author.LastName.TrimEnd()),
                BookId = book.Id,
                BookIsRentable = book.BookIsRentable
                
            };
            return bookDto;
        }
    }
}
