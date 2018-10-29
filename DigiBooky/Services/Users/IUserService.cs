using Digibooky_domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Digibooky_services.Users
{
    public interface IUserService
    {
        bool IsIdentificationNumberValid(string identificationNumber, string birthdate);
        bool IsEmailAdressValid(string email);
        User CreateNewUser(User userToCreate);
        IEnumerable<User> GetAllUsers();

        User SetUserAsLibrarian(int id);
        Task<User> Authenticate(string identificationNumber);
    }
}
