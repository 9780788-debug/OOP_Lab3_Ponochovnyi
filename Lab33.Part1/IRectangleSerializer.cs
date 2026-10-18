namespace Lab33.Part1;

// Спільний інтерфейс для всіх способів серіалізації.
public interface IRectangleSerializer
{
    // Назва способу для виводу.
    string Name { get; }
    // Розширення файлу.
    string Extension { get; }
    // Записує будь-яку послідовність (масив або колекцію) у файл.
    void Save(string path, IEnumerable<Rectangle> items);
    // Зчитує об'єкти з файлу.
    List<Rectangle> Load(string path);
}
