using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto;

[XmlType("Shell")]
public class ImportShellDto
{
    [XmlElement]
    [Required]
    [Range(ValidationConstants.ShellWeightMinRange, ValidationConstants.ShellWeightMaxRange)]
    public double ShellWeight { get; set; }

    [XmlElement("Caliber")]
    [Required]
    [MinLength(ValidationConstants.ShellCaliberMinLength)]
    [MaxLength(ValidationConstants.ShellCaliberMaxLength)]
    public string Caliber { get; set; } = null!;
}
