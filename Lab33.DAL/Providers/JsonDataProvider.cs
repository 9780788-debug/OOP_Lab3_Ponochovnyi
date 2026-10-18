using System.Text.Encodings.Web;
using System.Text.Json;

namespace Lab33.DAL.Providers;

// JSON-провайдер (System.Text.Json).
public class JsonDataProvider<T> : DataProvider<T> where T : class, new()
{
    public override string Extension => ".json";

    // Відступи і нормальна кирилиця у файлі.
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public override void Write(string path, List<T> items) =>
        File.WriteAllText(path, JsonSerializer.Serialize(items, Options));

    public override List<T> Read(string path) =>
        JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path), Options) ?? new List<T>();
}
