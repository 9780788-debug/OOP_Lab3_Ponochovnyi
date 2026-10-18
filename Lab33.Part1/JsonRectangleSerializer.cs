using System.Text.Encodings.Web;
using System.Text.Json;

namespace Lab33.Part1;

// JSON-серіалізація через System.Text.Json.
public class JsonRectangleSerializer : IRectangleSerializer
{
    public string Name => "JSON-серіалізація";
    public string Extension => ".json";

    // Гарний вигляд файлу та нормальна кирилиця.
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public void Save(string path, IEnumerable<Rectangle> items) =>
        File.WriteAllText(path, JsonSerializer.Serialize(items.ToList(), Options));

    public List<Rectangle> Load(string path) =>
        JsonSerializer.Deserialize<List<Rectangle>>(File.ReadAllText(path), Options) ?? new List<Rectangle>();
}
