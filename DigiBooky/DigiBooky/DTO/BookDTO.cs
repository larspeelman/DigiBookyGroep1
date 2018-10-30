using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky_api.DTO
{
    public class BookDTO
    {
        public string BookTitle { get; set; }
        public string Isbn { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int BookId { get; set; }
        public bool BookIsRentable { get; set; }

        public override bool Equals(object obj)
        {
            var dTO = obj as BookDTO;
            return dTO != null &&
                   BookTitle == dTO.BookTitle &&
                   Isbn == dTO.Isbn &&
                   AuthorFirstName == dTO.AuthorFirstName &&
                   AuthorLastName == dTO.AuthorLastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BookTitle, Isbn, AuthorFirstName, AuthorLastName);
        }
    }

   
}
