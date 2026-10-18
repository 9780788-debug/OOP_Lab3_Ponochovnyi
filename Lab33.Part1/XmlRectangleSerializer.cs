using System.Xml.Serialization;

namespace Lab33.Part1;

// XML-серіалізація через XmlSerializer.
public class XmlRectangleSerializer : IRectangleSerializer
{
    public string Name => "XML-серіалізація";
    public string Extension => ".xml";

    // Серіалізатор для списку прямокутників.
    private readonly XmlSerializer _serializer = new(typeof(List<Rectangle>));

    public void Save(string path, IEnumerable<Rectangle> items)
    {
        using var stream = File.Create(path);
        _serializer.Serialize(stream, items.ToList());
    }

    public List<Rectangle> Load(string path)
    {
        using var stream = File.OpenRead(path);
        return (List<Rectangle>)_serializer.Deserialize(stream)!;
    }
}
