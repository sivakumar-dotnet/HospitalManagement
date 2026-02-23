using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly List<Patient> _patients = new();

        public PatientRepository(ApplicationDbContext context)
            : base(context)
        {
        }
        public async Task<IEnumerable<Patient>> GetPatientsAboveAge(int age)
        {
            return await _context.Patients
                                 .Where(p => p.Age > age)
                                 .ToListAsync();
        }
    }
}
