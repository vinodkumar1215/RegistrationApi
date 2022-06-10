using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationForm.Models
{
    public class Registration
    {
        [Key]

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public string EmailId { get; set; }

        public string Gender { get; set; }

        public string Country { get; set; }
    }
}
