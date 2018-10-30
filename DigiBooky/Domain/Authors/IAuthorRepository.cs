using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky_domain.Authors
{
    public interface IAuthorRepository
    {
        void AddNewAuthorToDB(Author autor);
        Author GetauthorByName(string firstName, string lastName);
    }
}
