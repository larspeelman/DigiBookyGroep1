using Api.DTO;
using Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helper
{
   public interface IBookMapper
    {
        BookDTO BooksMapper(Book book);
    }
}
