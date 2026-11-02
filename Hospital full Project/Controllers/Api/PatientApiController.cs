using Hospital_full_Project.Data;
using Hospital_full_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_full_Project.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientApiController : Controller
    {
        private readonly HospitalDbContext _context;
        public PatientApiController(HospitalDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllPatient()
        {
            var Patient = _context.Patients.ToList();
            return Ok(Patient);
        }
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _context.Patients.Find(id);
            if(patient==null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpPost]
        public IActionResult CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return Ok(patient);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, Patient patient)
        {
            var existing = _context.Patients.Find(id);

            if (existing == null)
                return NotFound();

            existing.Name = patient.Name;
            existing.Age = patient.Age;
            existing.Gender = patient.Gender;

            _context.SaveChanges();

            return Ok(existing);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
                return NotFound();

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return Ok("Delete Patient Sucessfully");
        }
    }
}
