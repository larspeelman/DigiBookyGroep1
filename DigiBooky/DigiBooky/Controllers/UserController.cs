using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky_api.DTO;
using Digibooky_api.Helper;
using Digibooky_domain.Users;
using Digibooky_services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digibooky_api.Controllers
{
    [Authorize]
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
        //[Authorize(Roles = "Administrator")]
        [Authorize(Policy = "ModeratorAccess")]
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


        //{
        //    "UserIdentification":"LP_21041987",
        //    "Birthdate":"1987-04-21T00:00:00.0000",
        //    "Email":"test@hotmail.Com",
        //    "FirstName":"Lest",
        //    "LastName": "Pest"
        //}
    // POST: api/User
    [AllowAnonymous]
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
        //[Authorize(Roles = "Administrator")]
        [Authorize(Policy = "ModeratorAccess")]
        public ActionResult<UserDTOWithoutIdentificationNumber> RegisterLibrarian(int id)
        {
            var user = _userService.SetUserAsLibrarian(id);
            if (user == null)
            {
                return BadRequest("BAD INPUT");
            }
            return Ok(_mapperUser.FromUserToUserDTOWithoutId(user));
            
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userParam)
        {
            var user = await _userService.Authenticate(userParam.IdentificationNumber);

            if (user == null)
                return BadRequest(new { message = "identificationNumber is incorrect" });

            return Ok(user);
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
