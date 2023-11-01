using P01_HospitalDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            Prescriptions = new HashSet<PatientMedicament>();
            Diagnoses = new HashSet<Diagnose>();
            Visitations = new HashSet<Visitation>();
        }


        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(ValidateConstraint.PatientNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ValidateConstraint.PatientNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(ValidateConstraint.PatientAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(ValidateConstraint.PatientEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        public bool HasInsurance { get; set; } 

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}