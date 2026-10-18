namespace Lab33.DAL.Providers;

// Користувацький провайдер: власний текстовий формат [Тип] + рядки Name=Value.
public class CustomDataProvider<T> : DataProvider<T> where T : class, new()
{
    public override string Extension => ".custom";

    public override void Write(string path, List<T> items)
    {
        var lines = new List<string> { "# custom format" };
        foreach (T item in items)
        {
            // Заголовок об'єкта.
            lines.Add($"[{typeof(T).Name}]");
            // Кожна властивість окремим рядком.
            foreach (var prop in PropertyMap<T>.Properties)
                lines.Add($"{prop.Name}={PropertyMap<T>.ToText(prop.GetValue(item))}");
        }
        File.WriteAllLines(path, lines);
    }

    public override List<T> Read(string path)
    {
        var result = new List<T>();
        T? current = null;
        foreach (string line in File.ReadLines(path))
        {
            // Коментарі і порожні рядки пропускаємо.
            if (line.Length == 0 || line.StartsWith('#')) continue;
            // Заголовок починає новий об'єкт.
            if (line.StartsWith('['))
            {
                current = new T();
                result.Add(current);
                continue;
            }
            if (current == null) throw new FormatException("Файл починається не з заголовка об'єкта.");
            // Розбір рядка Name=Value.
            int eq = line.IndexOf('=');
            if (eq < 0) throw new FormatException($"Некоректний рядок: {line}");
            string name = line[..eq];
            string value = line[(eq + 1)..];
            // Невідомі властивості ігноруємо.
            var prop = PropertyMap<T>.Properties.FirstOrDefault(p => p.Name == name);
            prop?.SetValue(current, PropertyMap<T>.FromText(prop.PropertyType, value));
        }
        return result;
    }
}
