using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Authors
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        private static int IdCounter { get; set; }


        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = IdCounter.ToString();
            IdCounter++;

        }
    }
}
