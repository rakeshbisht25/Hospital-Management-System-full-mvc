using Hospital_full_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital_full_Project.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}