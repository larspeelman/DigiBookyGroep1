using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTO
{
    public class RentalDTO
    {
        public string Isbn { get; set; }
        public DateTime EndDate { get; set; }
        public string UserIdNumber { get; set; }
        public string UniqueRentalId { get; set; }
    }
}
