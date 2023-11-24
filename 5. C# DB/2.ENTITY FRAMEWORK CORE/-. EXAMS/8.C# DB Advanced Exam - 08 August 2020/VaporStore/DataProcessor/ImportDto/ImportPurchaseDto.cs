using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Common;

namespace VaporStore.DataProcessor.ImportDto;

[XmlType("Purchase")]
public class ImportPurchaseDto
{
    [Required]
    [XmlAttribute("title")]
    public string Title { get; set; } = null!;

    [Required]
    [XmlElement]
    public string Type { get; set; } = null!;

    [Required]
    [XmlElement]
    [RegularExpression(ValidationConstants.PurchaseProductKeyRegex)]
    public string Key { get; set; } = null!;

    [Required]
    [XmlElement]
    [RegularExpression(ValidationConstants.CardNumberRegex)]
    public string Card { get; set; } = null!;

    [Required]
    [XmlElement]
    public string Date { get; set; } = null!;

}