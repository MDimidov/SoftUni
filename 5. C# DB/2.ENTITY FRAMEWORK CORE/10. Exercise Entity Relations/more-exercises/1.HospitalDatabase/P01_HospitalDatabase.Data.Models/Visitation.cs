using P01_HospitalDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models;

public class Visitation
{
    [Key]
    public int VisitationId { get; set; }

    [Required]
    public DateTime Date { get; set;}

    [MaxLength(ValidateConstraint.VisitationCommentsMaxLength)]
    public string? Comments { get; set;}

    [Required]
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set;}

    public virtual Patient Patient { get; set; } = null!;

}
