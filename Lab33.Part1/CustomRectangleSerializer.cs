using System.Globalization;

namespace Lab33.Part1;

// Користувацька серіалізація: власний текстовий формат "fill;outline;width;height".
public class CustomRectangleSerializer : IRectangleSerializer
{
    public string Name => "Користувацька серіалізація";
    public string Extension => ".rect";

    public void Save(string path, IEnumerable<Rectangle> items)
    {
        // Один об'єкт = один рядок, числа в інваріантній культурі.
        var lines = items.Select(r => string.Join(";",
            r.FillColor, r.OutlineColor,
            r.Width.ToString(CultureInfo.InvariantCulture),
            r.Height.ToString(CultureInfo.InvariantCulture)));
        File.WriteAllLines(path, lines);
    }

    public List<Rectangle> Load(string path)
    {
        var result = new List<Rectangle>();
        foreach (string line in File.ReadAllLines(path))
        {
            // Порожні рядки пропускаємо.
            if (string.IsNullOrWhiteSpace(line)) continue;
            // Розбираємо рядок назад у поля.
            string[] p = line.Split(';');
            result.Add(new Rectangle(p[0], p[1],
                double.Parse(p[2], CultureInfo.InvariantCulture),
                double.Parse(p[3], CultureInfo.InvariantCulture)));
        }
        return result;
    }
}
