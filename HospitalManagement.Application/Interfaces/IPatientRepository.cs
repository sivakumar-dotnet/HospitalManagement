using HospitalManagement.Domain.Entities;

namespace HospitalManagement.Application.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetPatientsAboveAge(int age);

    }
}
