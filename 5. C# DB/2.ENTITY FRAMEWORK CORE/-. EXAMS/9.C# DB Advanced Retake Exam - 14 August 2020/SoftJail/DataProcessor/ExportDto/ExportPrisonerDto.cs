using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto;

[XmlType("Prisoner")]
public class ExportPrisonerDto
{
    [XmlElement]
    public int Id { get; set; }

    [XmlElement]
    public string Name { get; set; } = null!;

    [XmlElement]
    public string IncarcerationDate { get; set; } = null!;

    [XmlArray]
    public EportMailDto[] EncryptedMessages { get; set; } = null!;
}
