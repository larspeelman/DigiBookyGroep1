using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Users
{
    public class UserRepository : IUserRepository
    {
       

        public void Save(User userToSave)
        {
            if (IsUniqueUser(userToSave))
            {
                DBUsers.UsersInLibrary.Add(userToSave);
            }
        }

        private bool IsUniqueUser(User userToCheckIfUnique)
        {
            var userInDB = DBUsers.UsersInLibrary.SingleOrDefault(user => user.IdentificationNumber == userToCheckIfUnique.IdentificationNumber || user.Email == userToCheckIfUnique.Email);
            if (userInDB == null)
            {
                return true;
            }
            return false;
        }
    }
}
