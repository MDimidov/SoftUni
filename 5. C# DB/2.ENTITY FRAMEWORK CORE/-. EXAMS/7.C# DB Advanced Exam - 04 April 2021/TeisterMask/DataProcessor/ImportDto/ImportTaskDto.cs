using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto;

[XmlType("Task")]
public class ImportTaskDto
{
    [XmlElement]
    [Required]
    [MinLength(ValidationConstants.TaskNameMinLength)]
    [MaxLength(ValidationConstants.TaskNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement]
    [Required]
    public string OpenDate { get; set; } = null!;

    [XmlElement]
    [Required]
    public string DueDate { get; set; } = null!;

    [XmlElement]
    [Required]
    [Range(0, ValidationConstants.TaskExecutionTypeMaxRnge)]
    public int ExecutionType { get; set; }

    [XmlElement]
    [Required]
    [Range(0, ValidationConstants.TaskLabelTypeMaxRnge)]
    public int LabelType { get; set; }
}
