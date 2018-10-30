using Digibooky_domain.Authors;
using Digibooky_domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Digibooky_domain_UnitTests.Users
{
    public class UserRepositoryTest
    {
        public UserRepositoryTest()
        {
            DBUsers.UsersInLibrary.Clear();
        }
        [Fact]
        public void GivenDBUsers_WhenRegisterNewUniqueUser_ThenUserInDB()
        {
            //Given
            UserRepository dbUsers1 = new UserRepository();
            //ClearAllDataBasesUserRepositoryTest();
            User testUser1 = new User();
            testUser1.IdentificationNumber = "LP_21041987";
            testUser1.Email = "xxx@hotmail.com";
            testUser1.Id = 0;

            //When
            dbUsers1.Save(testUser1);

            //Then
            Assert.Contains(testUser1, DBUsers.UsersInLibrary);
            //ClearAllDataBasesUserRepositoryTest();
        }

        [Fact]
        public void GivenDBUsers_WhenRegisterUserWithNoUniqueEmail_ThenUserNotInDB()
        {
            //Given
            UserRepository dbUsers2 = new UserRepository();
            //ClearAllDataBasesUserRepositoryTest();
            User testUser2 = new User();
            testUser2.IdentificationNumber = "LP_21041987";
            testUser2.Email = "xxx@hotmail.com";
            testUser2.Id = 0;
            dbUsers2.Save(testUser2);

            User testUser3 = new User();
            testUser3.IdentificationNumber = "SP_21041987";
            testUser3.Email = "xxx@hotmail.com";
            testUser3.Id = 1;

            //When
            dbUsers2.Save(testUser3);

            //Then
            Assert.DoesNotContain(testUser3, DBUsers.UsersInLibrary);
            //ClearAllDataBasesUserRepositoryTest();
        }

        [Fact]
        public void GivenDBUsers_WhenRegisterUserWithNoUniqueIdentificationNumber_ThenUserNotInDB()
        {
            //Given
            UserRepository dbUsers3 = new UserRepository();
            //ClearAllDataBasesUserRepositoryTest();
            User testUser4 = new User();
            testUser4.IdentificationNumber = "LP_21041987";
            testUser4.Email = "xxx@hotmail.com";
            testUser4.Id = 0;
            dbUsers3.Save(testUser4);

            User testUser5 = new User();
            testUser5.IdentificationNumber = "LP_21041987";
            testUser5.Email = "xxxx@hotmail.com";
            testUser5.Id = 1;

            //When
            dbUsers3.Save(testUser5);

            //Then
            Assert.DoesNotContain(testUser5, DBUsers.UsersInLibrary);
           // ClearAllDataBasesUserRepositoryTest();
        }

        [Fact]
        public void GivenUserRepository_WhenRegisterLibrarianOfExistingUserAndAdministrator_ThenReturnUserAsLibarian()
        {
            //Given
            UserRepository dbUsers4 = new UserRepository();
            //ClearAllDataBasesUserRepositoryTest();
            User testUser6 = new User();
            testUser6.IdentificationNumber = "LP_21041987";
            testUser6.Email = "xxx@hotmail.com";
            testUser6.Id = 0;
            dbUsers4.Save(testUser6);
            //dbUsers4.Save(testUser6);
            //then
            Assert.True(dbUsers4.SetUserAsLibrarian(testUser6.Id).RoleOfThisUser == Roles.Role.Librarian);
            //ClearAllDataBasesUserRepositoryTest();
        }

        //private User GetTestUser(DateTime day, string id)
        //{
        //    User user = new User();
        //    user.Email = "xxx@hotmail.com";
        //    user.Birthdate = day;
        //    return user;
        //}


        //private void ClearAllDataBasesUserRepositoryTest()
        //{
        //    DBUsers.UsersInLibrary = null;
        //    DBUsers.UsersInLibrary = new List<User>();
        //}
    }
}
