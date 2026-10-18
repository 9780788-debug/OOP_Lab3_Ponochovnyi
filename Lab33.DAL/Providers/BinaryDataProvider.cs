namespace Lab33.DAL.Providers;

// Бінарний провайдер (BinaryWriter/BinaryReader + рефлексія по властивостях).
public class BinaryDataProvider<T> : DataProvider<T> where T : class, new()
{
    public override string Extension => ".bin";

    public override void Write(string path, List<T> items)
    {
        using var writer = new BinaryWriter(File.Open(path, FileMode.Create));
        // Спочатку кількість об'єктів.
        writer.Write(items.Count);
        foreach (T item in items)
            foreach (var prop in PropertyMap<T>.Properties)
                WriteValue(writer, prop.PropertyType, prop.GetValue(item));
    }

    public override List<T> Read(string path)
    {
        using var reader = new BinaryReader(File.Open(path, FileMode.Open));
        int count = reader.ReadInt32();
        var result = new List<T>();
        for (int i = 0; i < count; i++)
        {
            // Новий об'єкт і читання властивостей у тому ж порядку.
            var item = new T();
            foreach (var prop in PropertyMap<T>.Properties)
                prop.SetValue(item, ReadValue(reader, prop.PropertyType));
            result.Add(item);
        }
        return result;
    }

    // Запис значення за його типом.
    private static void WriteValue(BinaryWriter w, Type type, object? value)
    {
        if (type == typeof(string)) w.Write((string?)value ?? "");
        else if (type == typeof(int)) w.Write((int)value!);
        else if (type == typeof(double)) w.Write((double)value!);
        else if (type == typeof(bool)) w.Write((bool)value!);
        else throw new NotSupportedException($"Тип {type.Name} не підтримується.");
    }

    // Читання значення за його типом.
    private static object ReadValue(BinaryReader r, Type type)
    {
        if (type == typeof(string)) return r.ReadString();
        if (type == typeof(int)) return r.ReadInt32();
        if (type == typeof(double)) return r.ReadDouble();
        if (type == typeof(bool)) return r.ReadBoolean();
        throw new NotSupportedException($"Тип {type.Name} не підтримується.");
    }
}
