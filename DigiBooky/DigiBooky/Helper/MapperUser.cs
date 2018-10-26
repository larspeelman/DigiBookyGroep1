﻿using Api.DTO;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helper
{
    public class MapperUser: IMapperUser
    {
        public User FromDTOUserToUser(UserDTO userDTO)
        {

            return new User
            {
                Birthdate = userDTO.Birthdate,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Id = userDTO.Id,
                City = userDTO.City,
                PostalCode = userDTO.PostalCode,
                Email = userDTO.Email,
                StreetName = userDTO.StreetName,
                StreetNumber = userDTO.StreetNumber,
                RoleOfThisUser = userDTO.RoleOfThisUser
            };
                
        }

        public UserDTO FromUserToUserDTO(User user)
        {

            return new UserDTO
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
