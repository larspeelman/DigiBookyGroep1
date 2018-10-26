using Api.DTO;
using Domain.Users;

namespace Api.Helper
{
    public interface IMapperUser
    {
        UserDTOWithoutIdentificationNumber FromUserToUserDTOWithoutId(User user);
        User FromUserDTOWithIdToUser(UserDTOWithIdentificationNumber userDTO);
    }
}