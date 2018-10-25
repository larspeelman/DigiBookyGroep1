using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Users
{
    public class DBUser : IDBUsers
    {
        public List<User> UserDB = new List<User>();

        public void Save(User userToSave)
        {
            if (IsUniqueUser(userToSave))
            {
                UserDB.Add(userToSave);
            }
        }

        private bool IsUniqueUser(User userToCheckIfUnique)
        {
            var userInDB = UserDB.SingleOrDefault(user => user.IdentificationNumber == userToCheckIfUnique.IdentificationNumber || user.Email == userToCheckIfUnique.Email);
            if (userInDB == null)
            {
                return true;
            }
            return false;
        }
    }
}
