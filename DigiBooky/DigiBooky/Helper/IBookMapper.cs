
using Digibooky_api.DTO;
using Digibooky_domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky_api.Helper
{
   public interface IBookMapper
    {
        BookDTO BooksMapperBookToDTO(Book book);
        Book BooksMapperDTOToBook(BookDTO bookDTO);
    }
}
