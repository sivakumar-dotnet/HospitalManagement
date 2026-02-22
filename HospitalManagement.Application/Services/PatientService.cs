using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository) 
        {
            _patientRepository=patientRepository;
        }
        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
            => await _patientRepository.GetAllAsync();
        public async Task<Patient> GetPatientByIdAsync(Guid id)
            => await _patientRepository.GetByIdAsync(id);
        public async Task AddAsync (Patient patient)
            => await _patientRepository.AddAsync(patient);
        public async Task UpdateAsync  (Patient patient)
            => await _patientRepository.UpdateAsync(patient);
        public async Task DeleteAsync (Guid id)
            => await _patientRepository.DeleteAsync(id);
    }
}
