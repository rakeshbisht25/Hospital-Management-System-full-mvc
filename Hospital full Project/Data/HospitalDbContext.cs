using Hospital_full_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_full_Project.Data
{
    public class HospitalDbContext:DbContext
    
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext>options):base(options)
        {

        }
         public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
