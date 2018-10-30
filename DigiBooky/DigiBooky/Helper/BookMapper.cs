using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky_api.Helper;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Digibooky_services.Authors;

namespace Digibooky_api.DTO
{
    public class BookMapper : IBookMapper
    {
        private readonly IAuthorService _authorService;

        public BookDTO BooksMapperBookToDTO(Book book)
        {
            BookDTO bookDto = new BookDTO
            {
                BookTitle = book.BookTitle,
                Isbn = book.Isbn,
                AuthorFirstName = book.Author.FirstName,
                AuthorLastName = book.Author.LastName,
                BookId = book.Id,
                BookIsRentable = book.BookIsRentable

            };
            return bookDto;
        }

        public Book BooksMapperDTOToBook(BookDTO bookDTO)
        {
            Book book = new Book
            {
                BookTitle = bookDTO.BookTitle,
                Isbn = bookDTO.Isbn,
                AuthorId = _authorService.CheckIfAuthorAlreadyExists(bookDTO.AuthorFirstName, bookDTO.AuthorLastName)
            };
             return book;
        }
    }

}
   





