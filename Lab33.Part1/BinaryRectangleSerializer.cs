namespace Lab33.Part1;

// Бінарна серіалізація через BinaryWriter/BinaryReader (BinaryFormatter застарів).
public class BinaryRectangleSerializer : IRectangleSerializer
{
    public string Name => "Бінарна серіалізація";
    public string Extension => ".bin";

    public void Save(string path, IEnumerable<Rectangle> items)
    {
        var list = items.ToList();
        using var writer = new BinaryWriter(File.Open(path, FileMode.Create));
        // Спочатку кількість об'єктів.
        writer.Write(list.Count);
        foreach (var r in list)
        {
            // Поля пишемо в фіксованому порядку.
            writer.Write(r.FillColor);
            writer.Write(r.OutlineColor);
            writer.Write(r.Width);
            writer.Write(r.Height);
        }
    }

    public List<Rectangle> Load(string path)
    {
        using var reader = new BinaryReader(File.Open(path, FileMode.Open));
        // Читаємо кількість, потім поля в тому самому порядку.
        int count = reader.ReadInt32();
        var result = new List<Rectangle>();
        for (int i = 0; i < count; i++)
        {
            string fill = reader.ReadString();
            string outline = reader.ReadString();
            double width = reader.ReadDouble();
            double height = reader.ReadDouble();
            result.Add(new Rectangle(fill, outline, width, height));
        }
        return result;
    }
}
