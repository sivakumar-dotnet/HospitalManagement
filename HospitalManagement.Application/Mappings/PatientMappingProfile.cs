using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Application.DTOs;

namespace HospitalManagement.Application.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile() {

            CreateMap<Patient, PatientResponseDto>();
            CreateMap<CreatePatientDto, Patient>();
        
        }
    }
}
