using Digibooky_domain.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky_services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public string CheckIfAuthorAlreadyExists(string firstName, string lastName)
        {
            var authorToFind = _authorRepository.GetauthorByName(firstName, lastName);
            if (authorToFind != null)
            {
                return authorToFind.Id;
            }
            else
            {
                var newAuthor = new Author(firstName, lastName);
                _authorRepository.AddNewAuthorToDB(newAuthor);
                return newAuthor.Id;
                
            }
        }
    }
}
