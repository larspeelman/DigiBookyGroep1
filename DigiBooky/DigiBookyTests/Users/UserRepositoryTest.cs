using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DigiBookyTests.Users
{
    public class UserRepositoryTest
    {
        [Fact]
        public void GivenDBUsers_WhenRegisterNewUniqueUser_ThenUserInDB()
        {
            //Given
            UserRepository dbUsers = new Domain.Users.UserRepository();
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
        public void GivenUserService_WhenRegisterLiberianOfExistingUserAndAdministrator_ThenReturnUserAsLibarian()
        {
            //Given
            UserRepository userRepository = new UserRepository();
            User testUser = GetTestUser();
            userRepository.Save(testUser);
            //then
            Assert.True(userRepository.SetUserAsLibarian(1).RoleOfThisUser == Roles.Role.Libarian);
        }

        private User GetTestUser()
        {
            User user = new User();
            user.IdentificationNumber = "LP_21041987";
            user.Email = "xxx@hotmail.com";
            user.Birthdate = new DateTime(1987, 4, 21);
            user.Id = 1;
            return user;
        }
    }
}
