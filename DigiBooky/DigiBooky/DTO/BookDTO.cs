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
        public string AuthorName { get; set; }
        public int BookId { get; set; }

        public override bool Equals(object obj)
        {
            var dTO = obj as BookDTO;
            return dTO != null &&
                   BookTitle == dTO.BookTitle &&
                   Isbn == dTO.Isbn &&
                   AuthorName == dTO.AuthorName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BookTitle, Isbn, AuthorName);
        }
    }

   
}
