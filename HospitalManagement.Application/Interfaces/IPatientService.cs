using HospitalManagement.Application.DTOs;
using HospitalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync();
        Task<PatientResponseDto?> GetPatientByIdAsync(Guid id);
        Task<PatientResponseDto> AddPatientAsync(CreatePatientDto patientDto);
        Task<IEnumerable<PatientResponseDto>> GetPatientsAboveAgeAsync(int age);
    }
}
