using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharmaManagement.Modals
{
	public class PatientRecord
	{
        [Required]
        [Key]
        public int RecordId { get; set; }
        [ForeignKey("patientId")]
        public int patientId { get; set; }
        [ForeignKey("medicineId")]
        public int medicineId { get; set; }

        public int count { get; set; }

		public virtual Patient Patient { get; set; }

        public virtual Medicine Medicine { get; set; }

    }
}

