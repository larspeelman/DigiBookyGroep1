using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Users;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly IDBUsers _dbUsers;

        public UserService(IDBUsers _dbUsers)
        {
            this._dbUsers = _dbUsers;
        }

        public bool IsIdentificationNumberValid(string identificationNumber, string birthdate)
        {
            string initialsId = identificationNumber.Split('_')[0];
            if (!(initialsId.Length == 2))
            {
                return false;
            }
            if (!Regex.IsMatch(initialsId, @"^[a-zA-Z]+$"))
            {
                return false;
            }
            string birthdateId = identificationNumber.Split('_')[1];

            if (!(birthdateId == birthdate.ToString().Replace("/", string.Empty)))
            {
                return false;
            }
            return true;
        }

        public bool IsEmailAdressValid(string email)
        {
            return Regex.IsMatch(email.ToUpperInvariant(), @"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}");
        }

        public User CreateNewUser(User userToCreate)
        {
            if (IsEmailAdressValid(userToCreate.Email)
                && IsIdentificationNumberValid(userToCreate.IdentificationNumber, userToCreate.Birthdate.ToString("dd/MM/yyyy")))
            {
                _dbUsers.Save(userToCreate);
                return userToCreate;
            }
            
            return null;
        }
    }
}
