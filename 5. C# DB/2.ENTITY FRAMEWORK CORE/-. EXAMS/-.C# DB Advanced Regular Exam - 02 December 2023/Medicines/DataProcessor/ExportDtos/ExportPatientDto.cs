using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType("Patient")]
public class ExportPatientDto
{
    [XmlAttribute]
    public string Gender { get; set; } = null!;

    [XmlElement]
    public string Name { get; set; } = null!;

    [XmlElement]
    public string AgeGroup { get; set; } = null!;

    [XmlArray]
    public ExportMedicineDto[] Medicines { get; set; } = null!;
}

