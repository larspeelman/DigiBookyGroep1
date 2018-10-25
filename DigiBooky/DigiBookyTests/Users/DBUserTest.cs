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
            DBUser dbUser = new Domain.Users.DBUser();
            User testUser = new User();
            testUser.IdentificationNumber = "LP_21041987";
            testUser.Email = "xxx@hotmail.com";

            //When
            dbUser.Save(testUser);

            //Then
            Assert.Contains(testUser, dbUser.UserDB);
        }

        [Fact]
        public void GivenDBUsers_WhenRegisterUserWithNoUniqueEmail_ThenUserNotInDB()
        {
            //Given
            DBUser dbUser = new DBUser();
            User testUser = new User();
            testUser.IdentificationNumber = "LP_21041987";
            testUser.Email = "xxx@hotmail.com";
            dbUser.Save(testUser);

            User testUser2 = new User();
            testUser2.IdentificationNumber = "SP_21041987";
            testUser2.Email = "xxx@hotmail.com";

            //When
            dbUser.Save(testUser2);

            //Then
            Assert.DoesNotContain(testUser2, dbUser.UserDB);
        }

        [Fact]
        public void GivenDBUsers_WhenRegisterUserWithNoUniqueIdentificationNumber_ThenUserNotInDB()
        {
            //Given
            DBUser dbUser = new DBUser();
            User testUser = new User();
            testUser.IdentificationNumber = "LP_21041987";
            testUser.Email = "xxx@hotmail.com";
            dbUser.Save(testUser);

            User testUser2 = new User();
            testUser2.IdentificationNumber = "LP_21041987";
            testUser2.Email = "xxxx@hotmail.com";

            //When
            dbUser.Save(testUser2);

            //Then
            Assert.DoesNotContain(testUser2, dbUser.UserDB);
        }
    }
}
