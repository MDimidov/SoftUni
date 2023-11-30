using SoftJail.Common;
using SoftJail.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto;

[XmlType("Officer")]
public class ImportOfficerDto
{
    [Required]
    [XmlElement]
    [MinLength(ValidationConstants.OfficerFullNameMinLength)]
    [MaxLength(ValidationConstants.OfficerFullNameMaxLength)]
    public string Name { get; set; } = null!;


    [Required]
    [XmlElement]
    [Range(ValidationConstants.OfficerSalaryMinRange, ValidationConstants.OfficerSalaryMaxRange)]
    public decimal Money { get; set; }

    [Required]
    [XmlElement]
    public string Position { get; set; } = null!;

    [Required]
    [XmlElement]
    public string Weapon { get; set; } = null!;

    [Required]
    [XmlElement]
    public int DepartmentId { get; set; }

    [XmlArray("Prisoners")]
    public ImportPrisonerIdDTO[] Prisoners { get; set; } = null!;
}

[XmlType("Prisoner")]
public class ImportPrisonerIdDTO
{
    [Required]
    [XmlAttribute("id")]
    public int Id { get; set; }
}
