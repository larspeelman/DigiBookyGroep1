using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Digibooky_domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public static int UserCounter = 0;
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
        public Roles.Role RoleOfThisUser { get; set; }

        public User()
        {
            Id = UserCounter;
            UserCounter++;
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user.IdentificationNumber.ToUpper().Equals(IdentificationNumber.ToUpper()) && user.Email.ToUpper().Equals(Email.ToUpper());
        }

        public override int GetHashCode()
        {
            return IdentificationNumber.GetHashCode() + Email.GetHashCode();
        }
    }
}
