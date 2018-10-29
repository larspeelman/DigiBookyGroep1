
using Digibooky_api.DTO;
using Digibooky_domain.Users;


namespace Digibooky_api.Helper
{
    public interface IMapperUser
    {
        UserDTOWithoutIdentificationNumber FromUserToUserDTOWithoutId(User user);
        User FromUserDTOWithIdToUser(UserDTOWithIdentificationNumber userDTO);
    }
}