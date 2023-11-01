using P01_HospitalDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models;

public class Diagnose
{
    [Key]
    public int DiagnoseId { get; set; }

    [Required]
    [MaxLength(ValidateConstraint.DiagnoseNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidateConstraint.DiagnosenCommentsMaxLength)]
    public string? Comments { get; set; }

    [Required]
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
