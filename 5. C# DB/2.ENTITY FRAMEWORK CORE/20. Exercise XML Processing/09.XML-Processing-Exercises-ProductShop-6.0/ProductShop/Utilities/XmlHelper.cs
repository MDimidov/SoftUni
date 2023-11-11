using System.Xml.Serialization;

namespace ProductShop.Utilities;

public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute rootAttribute = new(rootName);

        XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

        using StringReader stringReader = new(inputXml);

        return (T)serializer.Deserialize(stringReader)!;
    }
}
