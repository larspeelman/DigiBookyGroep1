﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky_domain.Users
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

        public User SetUserAsLibrarian(int id)
        {
            var userInDb = DBUsers.UsersInLibrary.SingleOrDefault(user => user.Id.ToString() == id.ToString());
            if (userInDb != null)
            {
                userInDb.RoleOfThisUser = Roles.Role.Librarian;
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
