using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(Guid id);
        Task AddAsync (Patient patient);
        Task UpdateAsync (Patient patient);
        Task DeleteAsync (Guid id);

    }
}
