using System;
using System.ComponentModel.DataAnnotations;

namespace pharmaManagement.Modals
{
	public class Admin
	{
        [Key]
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Admin";
    }
}

