using Lab33.DAL.Providers;

namespace Lab33.DAL.Context;

// Контекст "бази даних": створення, відкриття, оновлення, закриття і видалення файлу.
public class EntityContext<T> where T : class, new()
{
    // Провайдер, що вміє читати/писати потрібний формат.
    private readonly DataProvider<T> _provider;

    // Шлях до файлу БД (його передає рівень представлення).
    public string FilePath { get; }
    // Дані, зчитані з файлу.
    public List<T> Items { get; private set; } = new();
    // Чи відкритий файл.
    public bool IsOpen { get; private set; }

    public EntityContext(DataProvider<T> provider, string filePath)
    {
        _provider = provider;
        FilePath = filePath;
    }

    // Чи існує файл на диску.
    public bool Exists() => File.Exists(FilePath);

    // Створює порожній файл БД.
    public void Create()
    {
        EnsureDirectory();
        Items = new List<T>();
        _provider.Write(FilePath, Items);
        IsOpen = true;
    }

    // Відкриває файл і зчитує дані.
    public void Open()
    {
        if (!Exists()) throw new FileNotFoundException($"Файл не знайдено: {FilePath}");
        Items = _provider.Read(FilePath);
        IsOpen = true;
    }

    // Перезаписує файл новими даними.
    public void Update(List<T> items)
    {
        EnsureDirectory();
        _provider.Write(FilePath, items);
        Items = items;
    }

    // Закриває файл (очищає дані в пам'яті).
    public void Close()
    {
        Items = new List<T>();
        IsOpen = false;
    }

    // Видаляє файл з диска.
    public void Delete()
    {
        Close();
        if (Exists()) File.Delete(FilePath);
    }

    // Створює папку, якщо шлях містить її.
    private void EnsureDirectory()
    {
        string? dir = Path.GetDirectoryName(Path.GetFullPath(FilePath));
        if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
    }
}
