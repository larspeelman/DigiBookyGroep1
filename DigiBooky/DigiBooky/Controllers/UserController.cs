using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digibooky_api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapperUser _mapperUser;

        public UserController(IUserService userService, IMapperUser mapperUser)
        {
            this._userService = userService;
            this._mapperUser = mapperUser;
        }


        // GET: api/User
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IEnumerable<UserDTOWithoutIdentificationNumber> Get()
        {
            return _userService.GetAllUsers().Select(user => _mapperUser.FromUserToUserDTOWithoutId(user));
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        public ActionResult<UserDTOWithoutIdentificationNumber> RegisterNewUser([FromBody] UserDTOWithIdentificationNumber userDTOToCreate)
        {
            var user = _userService.CreateNewUser(_mapperUser.FromUserDTOWithIdToUser(userDTOToCreate));
            if (user == null)
            {
              return BadRequest("BAD INPUT");
            }

            return Ok(_mapperUser.FromUserToUserDTOWithoutId(user));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<UserDTOWithoutIdentificationNumber> RegiserLibarian(int id)
        {
            var user = _userService.SetUserAsLibarian(id);
            if (user == null)
            {
                return BadRequest("BAD INPUT");
            }
            return Ok(_mapperUser.FromUserToUserDTOWithoutId(user));
            
        }

        //// PUT: api/User/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
