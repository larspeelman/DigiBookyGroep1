using Domain.Users;
using NSubstitute;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;


namespace DigiBookyTests.Users
{
   public class UserServiceTest
    {
        [Fact]
        public void GivenUniqueIdentificationNumber_WhenIsIdentificationNumberValid_ThenReturnTrue()
        {
            IDBUsers DBUsersStub = Substitute.For<IDBUsers>();
            //Given
            DateTime birthdate = new DateTime(1987, 4, 21);
            string BD = birthdate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);


            string uniqueId = "LP_21041987";
            UserService userService = new UserService(DBUsersStub);

            //When
            bool check = userService.IsIdentificationNumberValid(uniqueId, BD);

            //then
            Assert.True(check);
        }

        [Fact]
        public void GivenUniqueFalseIdentificationNumber_WhenIsIdentificationNumberValid_ThenReturnFalse()
        {
            //Given
            IDBUsers DBUsersStub = Substitute.For<IDBUsers>();
            DateTime birthdate = new DateTime(1987, 4, 21);
            string BD = birthdate.ToString("dd/MM/yyyy");
            string uniqueId = "LP88_21041987";
            UserService userService = new UserService(DBUsersStub);

            //When
            bool check = userService.IsIdentificationNumberValid(uniqueId, BD);

            //then
            Assert.False(check);
        }

        [Fact]
        public void GivenUniqueEmail_WhenIsEmailAdressValid_ThenReturnTrue()
        {
            //Given
            string email = "xxxx@hotmail.com";
            IDBUsers DBUsersStub = Substitute.For<IDBUsers>();
            UserService userService = new UserService(DBUsersStub);

            //When
            bool check = userService.IsEmailAdressValid(email);

            //then
            Assert.True(check);
        }

        [Fact]
        public void GivenFalseUniqueEmail_WhenIsEmailAdressValid_ThenReturnFalse()
        {
            //Given
            IDBUsers DBUsersStub = Substitute.For<IDBUsers>();
            string email = "xxxx@hotmail@com";
            UserService userService = new UserService(DBUsersStub);

            //When
            bool check = userService.IsEmailAdressValid(email);

            //then
            Assert.False(check);
        }

        [Fact]
        public void GivenUserService_WhenCreatingNewUsers_ThenDBUsersReceiveCallRegisterNewUser()
        {
            //Given
            IDBUsers DBUsersStub = Substitute.For<IDBUsers>();
            User testUser = new User();
            testUser.Email = "xxxx@hotmail.com";
            testUser.Birthdate = new DateTime(1987, 4, 21);
            testUser.IdentificationNumber = "LP_21041987";
            UserService userService = new UserService(DBUsersStub);

            //When
            userService.CreateNewUser(testUser);

            //then
            DBUsersStub.Received().Save(testUser);
        }
    }
}
