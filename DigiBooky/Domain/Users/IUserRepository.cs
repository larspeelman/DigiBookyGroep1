using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users
{
    public interface IUserRepository
    {
        void Save(User userToSave);
        IEnumerable<User> GetAllUsers();
        User SetUserAsLibarian(int id);
    }
}
