using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users
{
    public interface IUserRepository
    {
        void Save(User userToSave);
    }
}
