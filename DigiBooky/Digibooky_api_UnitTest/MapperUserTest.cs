
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DigiBooky_api_UnitTests
{
   public class MapperUserTest
    {
        [Fact]
        public void GivenMapper_WhenFromDtoToUser_ThenReturningUser()
        {
            //Given
            MapperUser mapperUser = new MapperUser();

            //When
            var testUser = mapperUser.FromUserDTOWithIdToUser(new UserDTOWithIdentificationNumber());
            User user1 = new User();
            //then
            Assert.IsType(user1.GetType(), testUser);
        }

        [Fact]
        public void GivenMapper_WhenFromUserToDto_ThenReturningUserDTO()
        {
            //Given
            MapperUser mapperUser = new MapperUser();

            //When
            var testUser = mapperUser.FromUserToUserDTOWithoutId(new User());
            UserDTOWithoutIdentificationNumber user1 = new UserDTOWithoutIdentificationNumber();
            //then
            Assert.IsType(user1.GetType(), testUser);
        }
    }
}
