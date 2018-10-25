using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Users
{
    public class User
    {
        public string Id { get; set; }
        public string IdentificationNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public User()
        {

        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user.IdentificationNumber.Equals(IdentificationNumber) && user.Email.Equals(Email);
        }

        public override int GetHashCode()
        {
            return IdentificationNumber.GetHashCode() + Email.GetHashCode();
        }
    }
}
