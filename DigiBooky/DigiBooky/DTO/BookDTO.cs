using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTO
{
    public class BookDTO
    {
        public string BookTitle { get; set; }
        public string Isbn { get; set; }
        public string AuthorName { get; set; }
    }
}
