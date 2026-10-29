using Hospital_full_Project.Data;
using Hospital_full_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hospital_full_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalDbContext _context;
        public HomeController(HospitalDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalPatients =
                _context.Patients.Count();

            ViewBag.TotalDoctors =
                _context.Doctors.Count();

            ViewBag.TotalAppointments =
                _context.Appointments.Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
