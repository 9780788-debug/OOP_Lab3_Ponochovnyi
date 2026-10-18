using System.Xml.Serialization;

namespace Lab33.DAL.Providers;

// XML-провайдер (XmlSerializer).
public class XmlDataProvider<T> : DataProvider<T> where T : class, new()
{
    public override string Extension => ".xml";

    // Серіалізатор для списку об'єктів типу T.
    private readonly XmlSerializer _serializer = new(typeof(List<T>));

    public override void Write(string path, List<T> items)
    {
        using var stream = File.Create(path);
        _serializer.Serialize(stream, items);
    }

    public override List<T> Read(string path)
    {
        using var stream = File.OpenRead(path);
        return (List<T>)_serializer.Deserialize(stream)!;
    }
}
