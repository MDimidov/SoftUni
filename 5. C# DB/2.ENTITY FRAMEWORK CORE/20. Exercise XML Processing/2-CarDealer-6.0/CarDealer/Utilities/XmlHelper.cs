using CarDealer.DTOs.Import;
using System.Xml.Serialization;

namespace CarDealer.Utilities;

public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        using StringReader reader = new(inputXml);

        XmlRootAttribute xmlRoot = new(rootName);

        XmlSerializer serializer = new(typeof(T), xmlRoot);

        return (T)serializer
            .Deserialize(reader)!;
    }
}
