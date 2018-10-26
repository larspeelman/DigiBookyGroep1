using Domain.Users;
using NSubstitute;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NSubstitute.ReturnsExtensions;
using Xunit;


namespace DigiBookyTests.Users
{
   public class UserServiceTest
    {
        [Fact]
        public void GivenUniqueIdentificationNumber_WhenIsIdentificationNumberValid_ThenReturnTrue()
        {
            IUserRepository DBUsersStub = Substitute.For<IUserRepository>();
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
            IUserRepository DBUsersStub = Substitute.For<IUserRepository>();
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
            IUserRepository DBUsersStub = Substitute.For<IUserRepository>();
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
            IUserRepository DBUsersStub = Substitute.For<IUserRepository>();
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
            IUserRepository DBUsersStub = Substitute.For<IUserRepository>();
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

        [Fact]
        public void GivenUserService_WhenRegisterLiberianOfExistingUserAndAdministrator_ThenReturnUserAsLibarian()
        {
            //Given
            IUserRepository repositoryUserStub = Substitute.For<IUserRepository>();
            User testUser = GetTestUser();
            testUser.RoleOfThisUser = Roles.Role.Libarian;
            UserService userService = new UserService(repositoryUserStub);
            repositoryUserStub.SetUserAsLibarian(1).Returns(testUser);

            //then
            Assert.True(userService.SetUserAsLibarian(1).RoleOfThisUser==Roles.Role.Libarian);
        }

        [Fact]
        public void GivenUserService_WhenRegisterLiberianOfNonExistingUserAndAdministrator_ThenReturnNull()
        {
            //Given
            IUserRepository repositoryUserStub = Substitute.For<IUserRepository>();
            User testUser = GetTestUser();
            testUser.RoleOfThisUser = Roles.Role.Libarian;
            UserService userService = new UserService(repositoryUserStub);
            repositoryUserStub.SetUserAsLibarian(1).ReturnsNull();

            //then
            Assert.Null(userService.SetUserAsLibarian(1));
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
