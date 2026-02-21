using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(Guid id);
        Task AddAsync (Patient patient);
        Task UpdateAsync (Patient patient);
        Task DeleteAsync (Guid id);

    }
}
