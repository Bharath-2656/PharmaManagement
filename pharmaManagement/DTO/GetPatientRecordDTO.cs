using System;
namespace pharmaManagement.DTO
{
	public class GetPatientRecordDTO
	{
        public int RecordId { get; set; }
        public int patientId { get; set; }
        public int medicineId { get; set; }
        public int count { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
    }
}

