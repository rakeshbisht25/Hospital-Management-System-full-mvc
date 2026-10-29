using Hospital_full_Project.Data;
using Hospital_full_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital_full_Project.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HospitalDbContext _context;
        public AppointmentController(HospitalDbContext context)
        {
            _context = context;
        }

       public IActionResult Index()
    {
        var appointments = _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .ToList();

        return View(appointments);
    }
    public IActionResult Create()
        {
            ViewBag.Patients = _context.Patients.ToList();

            ViewBag.Doctors = _context.Doctors.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Patients = _context.Patients.ToList();

            ViewBag.Doctors = _context.Doctors.ToList();

            return View(appointment);
        }
        public IActionResult Details(int id)
        {
            var appointment = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefault(a => a.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        public IActionResult Edit(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }

            ViewBag.Patients = _context.Patients.ToList();
            ViewBag.Doctors = _context.Doctors.ToList();

            return View(appointment);
        }
        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Update(appointment);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Patients = _context.Patients.ToList();
            ViewBag.Doctors = _context.Doctors.ToList();

            return View(appointment);
        }
        public IActionResult Delete(int id)
        {
            var appointment = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefault(a => a.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
