using System;
using System.ComponentModel.DataAnnotations;

namespace pharmaManagement.Modals
{
    public class Login
    {
        [Key]
        public string EmailId { get; set; }
        public string Password { get; set; }

    }
}

