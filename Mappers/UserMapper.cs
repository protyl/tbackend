using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.Models;
using api.DTOs.User;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToUserDTO(this User SomeUser)
        {
            return new UserDTO
            {
                Name = SomeUser.Name,
                Email = SomeUser.Email
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDTO UserDTO)
        {
            return new User
            {
                Name = UserDTO.Name,
                Email = UserDTO.Email,
                Password = UserDTO.Password
            };
        }
    }
}