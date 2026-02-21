using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly List<Patient> _patients = new();

        public Task<IEnumerable<Patient>> GetAllPatientsAsync()
         => Task.FromResult(_patients.AsEnumerable());

        public Task<Patient?> GetPatientByIdAsync(Guid id)        
            => Task.FromResult(_patients.FirstOrDefault(p => p.Id == id));
        public Task AddAsync(Patient patient)
        {
            _patients.Add(patient);
            return Task.CompletedTask;
        }
        public Task DeleteAsync(Guid id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient != null)
            {
                _patients.Remove(patient);
            }
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Patient patient)
        {
            var existing= _patients.FirstOrDefault(p=> p.Id == patient.Id);
            if(existing != null)
            {
                existing.FirstName = patient.FirstName;
                existing.LastName = patient.LastName;
                existing.Email = patient.Email;
                existing.DateOfBirth = patient.DateOfBirth;
                
            }
            return Task.CompletedTask;
        }
    }
}
