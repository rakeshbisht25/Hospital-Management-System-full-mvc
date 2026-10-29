using System.ComponentModel.DataAnnotations;

namespace Hospital_full_Project.Models
{
    public class Appointment
    {
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "peding";
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
