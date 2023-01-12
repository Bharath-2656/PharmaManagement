using System;
using System.ComponentModel.DataAnnotations;

namespace pharmaManagement.Modals
{
	public class Patient
	{
        [Required]
        [Key]
        public int patientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

        //public static implicit operator Patient(Medicine v)
        //{
        //    throw new NotImplementedException();
        //}

        //public static implicit operator Patient(List<Patient> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

