using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharmaManagement.DTO
{
	public class PatientRecordDTO
	{
        public int RecordId { get; set; }
        public int patientId { get; set; }
        public int medicineId { get; set; }
        public int count { get; set; }
    }
}

