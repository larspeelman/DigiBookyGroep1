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

        public IEnumerable<User> GetAllUsers()
        {
            return DBUsers.UsersInLibrary;
        }

        public User SetUserAsLibarian(int id)
        {
            var userInDb = DBUsers.UsersInLibrary.SingleOrDefault(user => user.Id.ToString() == id.ToString());
            if (userInDb != null)
            {
                userInDb.RoleOfThisUser = Roles.Role.Libarian;
            }

            return userInDb;
        }

        private bool IsUniqueUser(User userToCheckIfUnique)
        {
            var userInDb = DBUsers.UsersInLibrary.SingleOrDefault(user => user.IdentificationNumber == userToCheckIfUnique.IdentificationNumber || user.Email == userToCheckIfUnique.Email);
            if (userInDb == null)
            {
                return true;
            }
            return false;
        }
    }
}
