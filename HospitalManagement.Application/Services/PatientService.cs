using AutoMapper;
using HospitalManagement.Application.DTOs;
using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }  
        public async Task AddPatientAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientResponseDto>>(patients);
        }

        public async Task<PatientResponseDto?> GetPatientByIdAsync(Guid id)
        {
           var patient= await _patientRepository.GetByIdAsync(id);
            return _mapper.Map<PatientResponseDto>(patient);
        }

        public async Task AddPatientAsync(CreatePatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            patient.Id = Guid.NewGuid(); // since Guid PK

            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PatientResponseDto>> GetPatientsAboveAgeAsync(int age)
        {
            var patients = await _patientRepository.GetPatientsAboveAge(age);
            return _mapper.Map<IEnumerable<PatientResponseDto>>(patients);
        }
    }
}
