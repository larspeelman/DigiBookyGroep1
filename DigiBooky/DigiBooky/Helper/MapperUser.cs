using Api.DTO;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helper
{
    public class MapperUser: IMapperUser
    {
        public MapperUser()
        {
        }

        public User FromUserDTOWithIdToUser(UserDTOWithIdentificationNumber userDTO)
        {

            return new User
            {
                IdentificationNumber = userDTO.UserIdentification,
                Birthdate = userDTO.Birthdate,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                City = userDTO.City,
                PostalCode = userDTO.PostalCode,
                Email = userDTO.Email,
                StreetName = userDTO.StreetName,
                StreetNumber = userDTO.StreetNumber,
                RoleOfThisUser = userDTO.RoleOfThisUser
            };
                
        }

        public UserDTOWithoutIdentificationNumber FromUserToUserDTOWithoutId(User user)
        {

            return new UserDTOWithoutIdentificationNumber
            {
                
                Birthdate = user.Birthdate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                City = user.City,
                PostalCode = user.PostalCode,
                Email = user.Email,
                StreetName = user.StreetName,
                StreetNumber = user.StreetNumber, 
                RoleOfThisUser = user.RoleOfThisUser
            };

        }
        
    }
}
