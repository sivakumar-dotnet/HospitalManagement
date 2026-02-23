using HospitalManagement.Application.DTOs;
using HospitalManagement.Application.Interfaces;
using HospitalManagement.Application.Services;
using HospitalManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientsController(PatientService service)
        {
            _patientService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientDto patientDto)
        {
            await _patientService.AddPatientAsync(patientDto);
            return Ok("Patient Created Successfully");
                
        }
        [HttpGet("above-age/{age}")]
        public async Task<IActionResult> GetAboveAge(int age)
        {
            var patients = await _patientService.GetPatientsAboveAgeAsync(age);
            return Ok(patients);
        }


    }
}
