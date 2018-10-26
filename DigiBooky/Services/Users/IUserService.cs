using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Users
{
    public interface IUserService
    {
        bool IsIdentificationNumberValid(string identificationNumber, string birthdate);
        bool IsEmailAdressValid(string email);
        User CreateNewUser(User userToCreate);
        IEnumerable<User> GetAllUsers();

        User SetUserAsLibarian(int id);
    }
}
