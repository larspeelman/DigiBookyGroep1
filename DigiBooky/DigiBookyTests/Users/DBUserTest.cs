using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DigiBookyTests.Users
{
    public class DBUserTest
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
    }
}
