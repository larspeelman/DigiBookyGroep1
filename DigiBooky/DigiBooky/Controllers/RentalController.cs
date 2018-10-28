using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTO;
using Api.Helper;
using Domain.Rentals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Rentals;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IRentalMapper _rentalMapper;

        public RentalController(IRentalService rentalService, IRentalMapper rentalMapper)
        {
            _rentalService = rentalService;
            _rentalMapper = rentalMapper;
        }


        // GET: api/Rental
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rental/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rental
        [HttpPost]
        public ActionResult<RentalDTO> RentABook([FromBody] RentalDTO bookToLend)
        {
            var rental = _rentalService.RentABook(_rentalMapper.FromRentalDTOToRental(bookToLend));
            if (rental == null)
            {
                return BadRequest("bad input");
            }
            return Ok(_rentalMapper.FromRentalToRentalDTO(rental));
        }

        // PUT: api/Rental/5
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
