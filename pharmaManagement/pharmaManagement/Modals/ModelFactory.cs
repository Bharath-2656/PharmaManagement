using System;
using System.Net;
using System.Xml.Linq;
using pharmaManagement.DTO;

namespace pharmaManagement.Modals
{
    public class ModelFactory
    {

        public PatientDTO Create(Patient patient)
        {
            return new PatientDTO()
            {
                patientId = patient.patientId,
                Name = patient.FirstName + " " + patient.LastName,
                Age = patient.Age,
                EmailId = patient.EmailId,
                Address = patient.Address,
            };
        }

    }
}

