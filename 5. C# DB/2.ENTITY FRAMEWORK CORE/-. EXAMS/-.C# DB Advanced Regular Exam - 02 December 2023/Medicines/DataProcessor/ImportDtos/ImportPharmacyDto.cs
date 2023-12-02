using Medicines.Common;
using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType("Pharmacy")]
public class ImportPharmacyDto
{
    [Required]
    [XmlAttribute("non-stop")]
    public string IsNonStop { get; set; } = null!;

    [Required]
    [XmlElement]
    [MinLength(ValidationConstants.PharmacyNameMinLength)]
    [MaxLength(ValidationConstants.PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement]
    [MaxLength(ValidationConstants.PharmacyPhoneNumberLength)]
    [RegularExpression(ValidationConstants.PharmacyPhoneRegex)]
    public string PhoneNumber { get; set; } = null!;

    [XmlArray]
    public ImportMedicineDto[] Medicines { get; set; } = null!;
}

[XmlType("Medicine")]
public class ImportMedicineDto
{
    [Required]
    [XmlAttribute("category")]
    [Range(0, 4)]
    public int Category { get; set; }

    [Required]
    [XmlElement]
    [MinLength(ValidationConstants.MedicineNameMinLength)]
    [MaxLength(ValidationConstants.MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement]
    [Range(ValidationConstants.MedicinePriceMinRange, ValidationConstants.MedicinePriceMaxRange)]
    public decimal Price { get; set; }

    [Required]
    [XmlElement]
    public string ProductionDate { get; set; } = null!;

    [Required]
    [XmlElement]
    public string ExpiryDate { get; set; } = null!;

    [Required]
    [XmlElement]
    [MinLength(ValidationConstants.MedicineProducerMinLength)]
    [MaxLength(ValidationConstants.MedicineProducerMaxLength)]
    public string Producer { get; set; } = null!;
}
