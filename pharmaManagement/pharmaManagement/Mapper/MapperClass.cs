using System;
using AutoMapper;
using pharmaManagement.DTO;
using pharmaManagement.Modals;

namespace pharmaManagement.Mapper
{
	public class MapperClass : Profile
	{
        public MapperClass()
        {
            CreateMap<Patient, PatientDTO>().ForMember(dest =>
            dest.Name,
            opt => opt.MapFrom(src => src.FirstName+ " " +src.LastName));
      
        }
    }
}

