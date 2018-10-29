using Digibooky_domain.Authors;
using Digibooky_domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Digibooky_domain_UnitTests
{
    public class UserRepositoryTest
    {
        [Fact]
        public void GivenDBUsers_WhenRegisterNewUniqueUser_ThenUserInDB()
        {
            //Given
            UserRepository dbUsers = new UserRepository();
            User testUser = new User();
            testUser.IdentificationNumber = "LP_21041987";
            testUser.Email = "xxx@hotmail.com";

            //When
            dbUsers.Save(testUser);

            //Then
            Assert.Contains(testUser, DBUsers.UsersInLibrary);
        }

        [Fact]
        public void GivenDBUsers_WhenRegisterUserWithNoUniqueEmail_ThenUserNotInDB()
        {
            //Given
            UserRepository dbUsers = new UserRepository();
            User testUser = new User();
            testUser.IdentificationNumber = "LP_21041987";
            testUser.Email = "xxx@hotmail.com";
            dbUsers.Save(testUser);

            User testUser2 = new User();
            testUser2.IdentificationNumber = "SP_21041987";
            testUser2.Email = "xxx@hotmail.com";

            //When
            dbUsers.Save(testUser2);

            //Then
            Assert.DoesNotContain(testUser2, DBUsers.UsersInLibrary);
        }

        [Fact]
        public void GivenDBUsers_WhenRegisterUserWithNoUniqueIdentificationNumber_ThenUserNotInDB()
        {
            //Given
            DBUsers.UsersInLibrary.Clear();

            UserRepository dbUsers = new UserRepository();
            User testUser = new User();
            testUser.IdentificationNumber = "LP_21041987";
            testUser.Email = "xxx@hotmail.com";
            dbUsers.Save(testUser);

            User testUser2 = new User();
            testUser2.IdentificationNumber = "LP_21041987";
            testUser2.Email = "xxxx@hotmail.com";

            //When
            dbUsers.Save(testUser2);

            //Then
            Assert.DoesNotContain(testUser2, DBUsers.UsersInLibrary);
        }

        [Fact]
        public void GivenUserRepository_WhenRegisterLibrarianOfExistingUserAndAdministrator_ThenReturnUserAsLibarian()
        {
            //Given
            UserRepository userRepository = new UserRepository();
            DBUsers.UsersInLibrary.Clear();
            User testUser3 = GetTestUser(new DateTime (1987, 5,21), "LP_21051987");
            userRepository.Save(testUser3);
            DBAuthors.AuthorDB = FakedataAuthor();
            //then
            Assert.True(userRepository.SetUserAsLibrarian(testUser3.Id).RoleOfThisUser == Roles.Role.Libarian);
        }

        private User GetTestUser(DateTime day, string id)
        {
            User user = new User();
            user.IdentificationNumber = id;
            user.Email = "xxx@hotmail.com";
            user.Birthdate = day;
            return user;
        }

        public List<Author> FakedataAuthor()
        {
            List<Author> authorList = new List<Author>
            {
                new Author("Jef", "Depaepe"),
                new Author("Jos", "Schuurlink"),
                new Author("Guido", "Gazelle"),
            };
            return authorList;
        }
    }
}
