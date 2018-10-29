using System;
using System.Collections.Generic;
using System.Text;
using Digibooky_api.Controllers;
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Users;
using Digibooky_services.Users;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace DigiBooky_api_UnitTests
{
   public class UserControllerTest
    {

        private User GetTestUser()
        {
            User user = new User();
            user.IdentificationNumber = "LP_21041987";
            user.Email = "xxx@hotmail.com";
            user.Birthdate = new DateTime(1987, 4, 21);
            return user;
        }


        //[Fact]
        //public void GivenUserController_WhenRegisterNewUser_ThenUserServiceReceiveCallToCreateUser()
        //{
        //    //Given
        //    IUserService userService = Substitute.For<IUserService>();
        //    IMapperUser mapperUser = new MapperUser();
        //    UserController userController = new UserController(userService, mapperUser);
        //    UserDTOWithIdentificationNumber testUser = new UserDTOWithIdentificationNumber();

        //    //When
        //    userController.RegisterNewUser(testUser);
        //    User user = mapperUser.FromUserDTOWithIdToUser(testUser);

        //    //then
        //    userService.Received().CreateNewUser(user);
        //}

        [Fact]
        public void GivenUserController_WhenRegisterNewUniqueUser_ThenReturnOk()
        {
            //Given
            IUserService userService = Substitute.For<IUserService>();
            IMapperUser mapperUser = Substitute.For<IMapperUser>();
            UserController userController = new UserController(userService, mapperUser);
            UserDTOWithIdentificationNumber testUser = new UserDTOWithIdentificationNumber();
            User user = new User();
            user.IdentificationNumber = "LP_21041987";
            user.Email = "xxx@hotmail.com";
            mapperUser.FromUserDTOWithIdToUser(testUser).Returns(user);
            userService.CreateNewUser(user).Returns(user);


            //When
            var check = userController.RegisterNewUser(testUser).Result;


            //then
            Assert.IsType<OkObjectResult>(check);
        }

        [Fact]
        public void GivenUserController_WhenRegisterNotUniqueUser_ThenReturnBadRequest()
        {
            //Given
            IUserService userService = Substitute.For<IUserService>();
            IMapperUser mapperUser = Substitute.For<IMapperUser>();
            UserController userController = new UserController(userService, mapperUser);
            UserDTOWithIdentificationNumber testUser = new UserDTOWithIdentificationNumber();
            User user = new User();
            user.IdentificationNumber = "LP_21041987";
            user.Email = "xxx@hotmail.com";
            user = null;
            testUser = null;
            mapperUser.FromUserDTOWithIdToUser(testUser).Returns(user);
            userService.CreateNewUser(user).Returns(user);


            //When
            var check = userController.RegisterNewUser(testUser).Result;


            //then
            Assert.IsType<BadRequestObjectResult>(check);
        }

        [Fact]
        public void GivenUserController_WhenRegisterLiberianOfExistingUserAndAdministrator_ThenReturnOk()
        {
            //Given
            IUserService userService = Substitute.For<IUserService>();
            IMapperUser mapperUser = Substitute.For<IMapperUser>();
            UserController userController = new UserController(userService, mapperUser);
            UserDTOWithIdentificationNumber testUser = new UserDTOWithIdentificationNumber();
            User user = GetTestUser();
            user.Id = 1;
            user.RoleOfThisUser = Roles.Role.Libarian;
            
            mapperUser.FromUserDTOWithIdToUser(testUser).Returns(user);
            userService.SetUserAsLibarian(1).Returns(user);


            //When
            var check = userController.RegiserLibarian(1).Result;


            //then
            Assert.IsType<OkObjectResult>(check);
        }

        [Fact]
        public void GivenUserController_WhenRegisterLiberianOfNonExistingUserAndAdministrator_ThenReturnBadRequest()
        {
            //Given
            IUserService userService = Substitute.For<IUserService>();
            IMapperUser mapperUser = Substitute.For<IMapperUser>();
            UserController userController = new UserController(userService, mapperUser);
            UserDTOWithIdentificationNumber testUser = new UserDTOWithIdentificationNumber();
            User user = GetTestUser();
            user.Id = 1;
            user.RoleOfThisUser = Roles.Role.Libarian;

            mapperUser.FromUserDTOWithIdToUser(testUser).Returns(user);
            userService.SetUserAsLibarian(1).ReturnsNull();


            //When
            var check = userController.RegiserLibarian(1).Result;


            //then
            Assert.IsType<BadRequestObjectResult>(check);

        }
    }
}
