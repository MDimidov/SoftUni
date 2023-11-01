using System.ComponentModel.DataAnnotations;
using P01_HospitalDatabase.Data.Common;

namespace P01_HospitalDatabase.Data.Models;

public class Medicament
{
    public Medicament()
    {
        Prescriptions = new HashSet<PatientMedicament>();
    }

    [Key]
    public int MedicamentId { get; set; }

    [Required]
    [MaxLength(ValidateConstraint.MedicamentNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
}
