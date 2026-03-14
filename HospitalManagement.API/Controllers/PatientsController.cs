using HospitalManagement.Application.Common;
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
        public async Task<IActionResult> GetAll([FromQuery] PatientQueryParameters queryParameters)
        {
            var patients = await _patientService.GetAllPatientsAsync(queryParameters);
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientDto patientDto)
        {
           var createdPatient= await _patientService.AddPatientAsync(patientDto);
            return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.Id }, createdPatient);                           
        }
        [HttpGet("above-age/{age}")]
        public async Task<IActionResult> GetAboveAge(int age)
        {
            var patients = await _patientService.GetPatientsAboveAgeAsync(age);
            return Ok(patients);
        }


    }
}
