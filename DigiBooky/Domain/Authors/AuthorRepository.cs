using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky_domain.Authors
{
    public class AuthorRepository : IAuthorRepository
    {
        public void AddNewAuthorToDB(Author author)
        {
            DBAuthors.AuthorDB.Add(author);
        }

        public Author GetauthorByName(string firstName, string lastName)
        {
            var authorToFind = DBAuthors.AuthorDB.SingleOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (authorToFind != null)
            {
                return authorToFind;
            }
            return null;
        }
    }
}
