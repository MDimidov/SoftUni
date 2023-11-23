using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Serialization;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto;

[XmlType("Project")]
public class ImportProjectDto
{
    [Required]
    [XmlElement]
    [MinLength(ValidationConstants.ProjectNameMinLength)]
    [MaxLength(ValidationConstants.ProjectNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement]
    public string OpenDate { get; set; } = null!;

    [XmlElement]
    public string? DueDate { get; set; }

    [XmlArray]
    public ImportTaskDto[] Tasks { get; set; } = null!;


}
