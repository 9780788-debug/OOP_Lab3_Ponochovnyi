namespace Lab33.DAL.Providers;

// Абстракція провайдера: один спосіб серіалізації = один нащадок.
public abstract class DataProvider<T> where T : class, new()
{
    // Розширення файлу цього формату.
    public abstract string Extension { get; }
    // Записує список об'єктів у файл.
    public abstract void Write(string path, List<T> items);
    // Зчитує список об'єктів з файлу.
    public abstract List<T> Read(string path);
}
