using Api.DTO;
using Domain.Users;

namespace Api.Helper
{
    public interface IMapperUser
    {
        User FromDTOUserToUser(UserDTO userDTO);
        UserDTO FromUserToUserDTO(User user);
    }
}