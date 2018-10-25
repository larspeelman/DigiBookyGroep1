using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTO;
using Api.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Users;

namespace Api.Controllers
{
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<UserDTO> RegisterNewUser([FromBody] UserDTO userDTOToCreate)
        {                
            if (_userService.CreateNewUser(_mapperUser.FromDTOUserToUser(userDTOToCreate)) == null)
            {
              return BadRequest("BAD INPUT");
            }
            return Ok(User);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
