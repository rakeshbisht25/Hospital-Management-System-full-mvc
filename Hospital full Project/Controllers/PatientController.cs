using Hospital_full_Project.Data;
using Hospital_full_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Hospital_full_Project.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext _context;
        public PatientController(HospitalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var patients = _context.Patients.ToList();

            return View(patients);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }
        
        public IActionResult Details(int id)
        {
            var Patient = _context.Patients.Find(id);
            if(Patient == null)
            {
                return NotFound();
            }
            else
            {
                return View(Patient);
            }   
        }
        public IActionResult Edit(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if(ModelState.IsValid)
            {
                _context.Update(patient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }
        public IActionResult Delete(int id)
        {
            var patient = _context.Patients.Find(id);
            if(patient==null)
            {
                return NotFound();
            }
            return View(patient);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient = _context.Patients.Find(id);
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

