using Hospital_full_Project.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hospital_full_Project.Models
{
    public class Patient
    {

        public int PatientId { get; set; }

        [Required]

        public string Name { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public int Phone { get; set; } 
        [Required]
        public string Address { get; set; } = string.Empty;
        public ICollection<Appointment>? Appointments { get; set; }
    }
}