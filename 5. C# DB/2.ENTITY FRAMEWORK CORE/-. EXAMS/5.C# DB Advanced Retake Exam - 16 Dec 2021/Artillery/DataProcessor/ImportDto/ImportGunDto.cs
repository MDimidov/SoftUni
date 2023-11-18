using Artillery.Common;
using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto;

public class ImportGunDto
{
    [Required]
    public int ManufacturerId { get; set; }

    [Required]
    [Range(ValidationConstants.GunWeightMinRange, ValidationConstants.GunWeightMaxRange)]
    public int GunWeight { get; set; }

    [Required]
    [Range(ValidationConstants.GunBarrelLengthMinRange, ValidationConstants.GunBarrelLengthMaxRange)]
    public double BarrelLength { get; set; }


    public int? NumberBuild { get; set; }

    [Required]
    [Range(ValidationConstants.GunRangeMinRange, ValidationConstants.GunRangeMaxRange)]
    public int Range { get; set; }

    [Required]
    public string GunType { get; set; } = null!;

    [Required]
    public int ShellId { get; set; }

    public ImportCountryIdDto[] Countries { get; set; } = null!;
}
