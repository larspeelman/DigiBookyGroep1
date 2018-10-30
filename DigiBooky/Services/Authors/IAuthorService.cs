using Digibooky_domain.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky_services.Authors
{
    public interface IAuthorService
    {
        string CheckIfAuthorAlreadyExists(string firstName, string lastName);
    }
}
