
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky_domain.Users
{
    public interface IUserRepository
    {
        void Save(User userToSave);
        IEnumerable<User> GetAllUsers();
        User SetUserAsLibrarian(int id);
    }
}
