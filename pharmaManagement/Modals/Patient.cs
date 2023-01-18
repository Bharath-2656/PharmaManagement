using System;
using System.ComponentModel.DataAnnotations;

namespace pharmaManagement.Modals
{
    public class Patient
    {
        [Required]
        [Key]
        public int patientId { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }
    }
}

