using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Users
{
    public interface IDBUsers
    {
        void Save(User userToSave);
    }
}
